using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Yahtzee
{
    public class ScoreController
    {
        private ScoreModel scoreModel;
        private ScoreUI scoreUI;
        private List<DiceController> dices;

        public ScoreController( List<DiceController> dices)
        {
            this.dices = dices;
            this.scoreModel = new ScoreModel();
            this.scoreUI = new ScoreUI();
        }

        // Method that returns view
        public ScoreUI view
        {
            get
            {
                return this.scoreUI;
            }
        }



        // Chance           CHECK   0
        // 1'en             CHECK   1
        // 2'en             CHECK   2
        // 3'en             CHECK   3
        // 4'en             CHECK   4
        // 5'en             CHECK   5
        // 6'en             CHECK   6
        // Three of a kind  CHECK   7
        // Four of a kind   CHECK   8
        // Full House       CHECK   9
        // Small Straight   CHECK   10
        // Large Straight   CHECK   11
        // Yahtzee          CHECK   12

        bool[] statusAllScores = new bool[13];   // Deze array houd bij welke methods al eens zijn gebruikt en welke niet, elke method mag maar 1 keer gebruikt worden
        int[] allScores = new int[13];           // Dit houd voor elke worp alle scores bij die de methods gaan returnen

        public int CalculateThreeOfAKind(int[] myDice)
        {
            int Sum = 0;

            bool ThreeOfAKind = false;

            for (int i = 1; i <= 6; i++)        // We kijken per specifieke waarde hoe vaak deze aanwezig is in de dices
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (myDice[j] == i)
                        Count++;

                    if (Count > 2)              // Vanaf dat er 3 dices dezelfde waarde hebben spreken we van three of a kind
                    {
                        ThreeOfAKind = true;
                        this.scoreModel.besteWorp = "Het is Three of a kind!";
                       
                    }
                }
            }

            if (ThreeOfAKind)                   // We tellen alle waarden van de dices op bij elkaar
            {
                for (int k = 0; k < 5; k++)
                {
                    
                    Sum += myDice[k];
                }
            }

            return Sum;
            
        }
        public int CalculateFourOfAKind(int[] myDice)
        {
            int Sum = 0;

            bool FourOfAKind = false;

            for (int i = 1; i <= 6; i++)        // We controleren voor elke waarde hoeveel dices er die specifieke waarde hebben
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (myDice[j] == i)
                        Count++;

                    if (Count > 3)              // Vanaf dat er 4 dezelfde waarden zijn spreken we van four of a kind
                    {
                        FourOfAKind = true;

                        this.scoreModel.besteWorp = "Het is Four of a kind!";
                       
                    }
                }
            }

            if (FourOfAKind)                    // Aks het four of a kind is tellen we al de waarden van de dices op bij elkaar
            {
                for (int k = 0; k < 5; k++)
                {
                    Sum += myDice[k];
                }
            }

            return Sum;
        }
        public int CalculateFullHouse(int[] myDice)
        {
            int Sum = 0;

            int[] i = new int[5];               // We stopppen alles in een array

            i[0] = myDice[0];
            i[1] = myDice[1];
            i[2] = myDice[2];
            i[3] = myDice[3];
            i[4] = myDice[4];

            Array.Sort(i);                      // We sorteren alle waarden

            if ((((i[0] == i[1]) && (i[1] == i[2])) && // Three of a Kind
                 (i[3] == i[4]) && // Two of a Kind
                 (i[2] != i[3])) ||
                ((i[0] == i[1]) && // Two of a Kind
                 ((i[2] == i[3]) && (i[3] == i[4])) && // Three of a Kind
                 (i[1] != i[2])))
            {

                this.scoreModel.besteWorp = "Het is een Full House!";
                Sum = 25;
            }

            return Sum;
        }
        public int CalculateSmallStraight(int[] myDice)
        {
            int Sum = 0;

            int[] i = new int[5];           // We stoppen alles in array

            i[0] = myDice[0];
            i[1] = myDice[1];
            i[2] = myDice[2];
            i[3] = myDice[3];
            i[4] = myDice[4];

            Array.Sort(i);                  // We sorteren de waarden zodat deze op volgorde staat

            for (int j = 0; j < 4; j++)     // Deze for loops zorgen er voor dat dubbele waarden naar achteren worden gebracht
            {
                int temp = 0;
                if (i[j] == i[j + 1])
                {
                    temp = i[j];

                    for (int k = j; k < 4; k++)
                    {
                        i[k] = i[k + 1];
                    }

                    i[4] = temp;
                }
            }

            if (((i[0] == 1) && (i[1] == 2) && (i[2] == 3) && (i[3] == 4)) ||       // We controleren alle mogelijke combinaties
                ((i[0] == 2) && (i[1] == 3) && (i[2] == 4) && (i[3] == 5)) ||
                ((i[0] == 3) && (i[1] == 4) && (i[2] == 5) && (i[3] == 6)) ||
                ((i[1] == 1) && (i[2] == 2) && (i[3] == 3) && (i[4] == 4)) ||
                ((i[1] == 2) && (i[2] == 3) && (i[3] == 4) && (i[4] == 5)) ||
                ((i[1] == 3) && (i[2] == 4) && (i[3] == 5) && (i[4] == 6)))
            {
                this.scoreModel.besteWorp = "Het is een Small Straight!";
                Sum = 30;
            }

            return Sum;
        }
        public int CalculateLargeStraight(int[] myDice)
        {
            int Sum = 0;

            int[] i = new int[5];       // We stoppen alle waarden van de dices in een array

            i[0] = myDice[0];
            i[1] = myDice[1];
            i[2] = myDice[2];
            i[3] = myDice[3];
            i[4] = myDice[4];

            Array.Sort(i);              // We sorteren de array zodat alle waarden op volgorde staan

            if (((i[0] == 1) &&         // Er zijn maar 2 mogelijkheden en deze controleren we
                 (i[1] == 2) &&
                 (i[2] == 3) &&
                 (i[3] == 4) &&
                 (i[4] == 5)) ||
                ((i[0] == 2) &&
                 (i[1] == 3) &&
                 (i[2] == 4) &&
                 (i[3] == 5) &&
                 (i[4] == 6)))
            {
                this.scoreModel.besteWorp = "Het is een Large Straight!";
                Sum = 40;
            }

            return Sum;
        }
        public int CalculateYahtzee(int[] myDice)
        {
            int Sum = 0;

            for (int i = 1; i <= 6; i++)        // Voor elke nummer controleren of alle dices deze bevatten
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)     // Controleren of alle dices dezelfde waarde hebben
                {
                    if (myDice[j] == i)
                        Count++;

                    if (Count > 4)              // Dit betekent dat er 5 dezelfde dices zijn dus Yahtzee
                    {
                        this.scoreModel.besteWorp = "Yathzee!";
                        Sum = 50;
                    }
                }
            }

            return Sum;
        }
        public int AddUpChance(int[] myDice)
        {
            int Sum = 0;

            for (int i = 0; i < 5; i++)         // Telt alle waarden van alle dobbelstenen op
            {
                Sum += myDice[i];
            }
            this.scoreModel.besteWorp = "Chance!";
            return Sum;
        }
        public int AddUpDice(int DiceNumber, int[] myDice)
        {
            int Sum = 0;

            for (int i = 0; i < 5; i++)         // Telt alle dices op die een specifieke waarde hebben
            {
                if (myDice[i] == DiceNumber)
                {
                    Sum += DiceNumber;
                }
            }
            if (Sum != 0)
            {
                this.scoreModel.besteWorp = DiceNumber + "'en in je worp.";
            }
            return Sum;
        }
        public void GetAllScores(int[] diceValues)   // Berekent elke worp alle mogelijke scores
        {
            allScores[0] = AddUpChance(diceValues);
            allScores[1] = AddUpDice(1, diceValues);
            allScores[2] = AddUpDice(2, diceValues);
            allScores[3] = AddUpDice(3, diceValues);
            allScores[4] = AddUpDice(4, diceValues);
            allScores[5] = AddUpDice(5, diceValues);
            allScores[6] = AddUpDice(6, diceValues);
            allScores[7] = CalculateThreeOfAKind(diceValues);
            allScores[8] = CalculateFourOfAKind(diceValues);
            allScores[9] = CalculateFullHouse(diceValues);
            allScores[10] = CalculateSmallStraight(diceValues);
            allScores[11] = CalculateLargeStraight(diceValues);
            allScores[12] = CalculateYahtzee(diceValues);
        }
        public int HighestScore()    // Geeft de hoogste score terug en zet bijbehorende bool op true omdat deze al gebruikt is
        {
            int highestScore = allScores.Max();                                 // Zoekt het hoogste cijfer in de array
            int indexHighestScore = Array.IndexOf(allScores, highestScore);     // Zoekt de index van het hoogste cijfer in de array
            return allScores[indexHighestScore];
        }


        // Werkt niet in Yahtzee
        /*public void AddDataToPlayer()
        {
            //Hardcoded variables for testing
            string[] playerNames = new string[] { "Jordy", "Michael", "Yelle", "Benny" };
            int[] totalScorePlayers = new int[] { 300, 390, 420, 280 };
            //-------------------------------------------------------------------------------
            int winner = GetWinner(totalScorePlayers);                                              // Roept method op die de index van de winnaar returned
            int allListedPlayersCount = CountPlayers();                                             // Roept method op die het huidig aantal spelers in het bestand returned
            string[,] allPlayerData = ReadPlayerData();                                             // Geeft alle data van alle spelers in het bestand terug
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "myfile.txt");                                 // Bestandsnaam gecombineerd met het pad

            Console.WriteLine("Index winnaar: {0}", winner);
            Console.WriteLine("Alle data van de spelers wordt nu geupdate, een ogenblik aub...");
            for (int i = 0; i < playerNames.Length; i++)                                            // Overloopt alle spelers die aan het spelen waren
            {
                for (int j = 0; j < allListedPlayersCount; j++)                                     // Overloopt alle spelers die in het bestand staan
                {
                    if (playerNames[i] == allPlayerData[j, 0])                                      // True als de speler die aan het spelen is overeenkomt met een speler van het bestand
                    {
                        int highestScore = Int32.Parse(allPlayerData[j, 3]);                        // Zet huidige highscore om naar een int
                        Console.WriteLine("De huidige highscore van {0} is {1}", playerNames[i], allPlayerData[j, 3]);
                        if (highestScore > totalScorePlayers[i])                                    // True als de huidige highscore groter is dan de juist behaalde score
                        {
                            Console.WriteLine("{0} behaalde geen nieuwe highscore dus de huidige highscore wordt opnieuw bewaard.", playerNames[i]);
                            allPlayerData[j, 3] = highestScore.ToString();                          // De highscore wordt terug als string genoteerd in het bestand
                        }
                        else
                        {
                            Console.WriteLine("{0} heeft een nieuwe highscore! De huidige highscore van {1} wordt vervangen door {2}.", playerNames[i], allPlayerData[j, 3], totalScorePlayers[i]);
                            allPlayerData[j, 3] = totalScorePlayers[i].ToString();                  // De huidige highscore wordt vervangen door de nieuwe highscore
                        }
                        if (i == winner)                                                            // True als de index van de speler overeenkomt met de index van de winnaar
                        {
                            Console.WriteLine("De speler {0} heeft gewonnen", playerNames[i]);
                            int currentWins = Int32.Parse(allPlayerData[j, 1]);                     // Zet het totaal aantal keer gewonnen om naar een int
                            currentWins++;                                                          // We tellen bij de het aantal keer gewonnen 1 op
                            allPlayerData[j, 1] = currentWins.ToString();                           // We zetten dit om naar een string en voegen dit terug toe aan de array
                        }
                        else
                        {
                            int currentLosses = Int32.Parse(allPlayerData[j, 2]);                   // Zet het totaal aantal keer verloren om naar een int
                            currentLosses++;                                                        // We tellen bij de het aantal keer verloren 1 op
                            allPlayerData[j, 2] = currentLosses.ToString();                         // We zetten dit om naar een string en voegen dit terug toe aan de array
                        }
                    }
                }
            }
            Console.WriteLine("Alles is up to data en wordt nu weggeschreven naar de savefile...");
            StreamWriter sw = File.CreateText(myfile);                                              // Maakt een streamwriter

            for (int i = 0; i < allListedPlayersCount; i++)                                         // De savefile wordt volledig overschreven met de nieuwe gegevens
            {
                string playerData = "";                                                             // Lege string wordt aangemaakt en hierin wordt de nieuwe data van een speler toegevoegd
                playerData += allPlayerData[i, 0];
                playerData += "-";
                playerData += allPlayerData[i, 1];
                playerData += "-";
                playerData += allPlayerData[i, 2];
                playerData += "-";
                playerData += allPlayerData[i, 3];

                sw.WriteLine(playerData);                                                           // Nadat de string gevuld is wordt deze aan het bestand toegevoegd
            }
            sw.Close();                                                                             // Streamwriter wordt geclosed
            Console.WriteLine("Alles is bewaard!");
        }*/

        // Method that gets executed when the observable is changed
        public void notify( int newDiceValue )
        {
            int score = 0;
            int[] diceValues = new int[5];

            foreach (DiceController dice in this.dices )
            {
                //score += dice.diceModel.value;
                //Elke waarde van elke dice wordt hier opgevraagd dus mss hier eens zien voor de score te fixen
            }

            DiceController[] dicesArray = dices.ToArray();

            for (int i = 0; i < dicesArray.Length; i++)
            {
                diceValues[i] = dicesArray[i].diceModel.value;
            }

            GetAllScores(diceValues);
            score = HighestScore();
            // Update model with new value
            this.scoreModel.score = score;
            
            // Update view with new value
            this.scoreUI.updateScore(score);
            this.scoreUI.updateBesteWorp(this.scoreModel.besteWorp);
        }



        // vanaf hier de code om player.txt te beheren


    }
}
