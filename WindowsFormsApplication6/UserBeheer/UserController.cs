using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Yahtzee
{
    class UserController
    {

        public void CheckFile()
        {
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "Yahtzee_saves.txt");                                 // Bestandsnaam gecombineerd met het pad
            if (!File.Exists(myfile))                                                               // Controleert of de file bestaat
            {
                StreamWriter sw = File.CreateText(myfile);                                          // Maakt de file aan indien er nog geen was
                string defaultPlayer = "admin-0-0-0";                                               // Maakt een default player aan
                sw.WriteLine(defaultPlayer);                                                        // Schrijft de default player in het bestand
                sw.Close();                                                                         // Sluit de streamwriter af
            }
        }
        public string[,] ReadPlayerData()
        {
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "Yahtzee_saves.txt");                                 // Bestandsnaam gecombineerd met het pad

            List<string> playerDataList = new List<string>();                                       // Houd de gegevens bij van elke speler met '-' bv "Michael-5-4-320"
            string[] playerDataSplit = new string[] { };                                            // Houd de gevens bij die gesplitst zijn op de '-'

            int playerCount = 0;                                                                    // Telt het aantal spelers in het tekstbestand
            char split = '-';                                                                       // Het teken waar de string geplitst moet worden

            StreamReader inputStream = File.OpenText(myfile);                                       // Creëert een StreamReader die 'myfile' kan lezen

            string inputLine = inputStream.ReadLine();                                              // Leest de eerste lijn in het bestand om de while te doen werken
            while (inputLine != null)                                                               // while blijft doorgaan tot er geen lijnen tekst meer zijn
            {
                if (inputLine != "")                                                                // Controleert of er wel iets geschreven staat op de ingelezen lijn
                {
                    playerDataList.Insert(playerCount, inputLine);                                  // Data wordt toegevoegd aan de lijst 'playerDataList'
                    playerCount++;                                                                  // Per ingelezen lijn tellen we er een speler bij
                }
                inputLine = inputStream.ReadLine();                                                 // Leest de volgende lijn tekst in

            }
            string[,] allPlayerData = new string[playerCount, 4];                                   // 2D array die wordt aangemaakt die alle spelers met hun gegevens bijhoud
            string[] playerData = playerDataList.ToArray();                                         // Convert de List naar een array

            for (int i = 0; i < playerCount; i++)                                                   // For loop die de 2D array vult met alle gegevens
            {
                playerDataSplit = playerData[i].Split(split);                                       // String wordt gesplitst op de '-'
                for (int j = 0; j < 4; j++)                                                         // For loop die voor elke speler de gegevens invult
                {
                    allPlayerData[i, j] = playerDataSplit[j];                                       // Gegevens worden toegevoegd
                }
            }
            inputStream.Close();                                                                    // De StreamReader wordt afgesloten
            Console.WriteLine("Lijst met alle gegevens van de spelers is aangemaakt.");
            return allPlayerData;                                                                   // De 2D array met alle data van alle spelers wordt gereturned
        }
        public int CountPlayers()
        {
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "Yahtzee_saves.txt");                                 // Bestandsnaam gecombineerd met het pad
            int playerCount = 0;                                                                    // Houd het aantal spelers bij
            StreamReader inputStream = File.OpenText(myfile);                                       // Creëert een StreamReader die 'myfile' kan lezen

            string inputLine = inputStream.ReadLine();                                              // Leest de eerste lijn in het bestand om de while te doen werken
            while (inputLine != null)                                                               // while blijft doorgaan tot er geen lijnen tekst meer zijn
            {
                if (inputLine != "")                                                                // Controleert of de ingelezen lijn wel data bevat
                {
                    playerCount++;                                                                  // Telt er een speler bij
                }
                inputLine = inputStream.ReadLine();                                                 // Leest de volgende lijn tekst in
            }
            inputStream.Close();                                                                    // Sluit streamreader af
            Console.WriteLine("Het aantal spelers in het bestand is geteld. Er zijn momenteel {0} spelers in de lijst", playerCount);
            return playerCount;                                                                     // returned het totaal aantal spelers in het bestand
        }
        public void AddNewPlayer(List<string> newPlayers)
        {
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "Yahtzee_saves.txt");                                 // Bestandsnaam gecombineerd met het pad
            int newPlayerCount = newPlayers.Count;                                                  // Telt het aantal namen dat de gebruikers hebben ingegeven
            string defaultData = "-0-0-0";                                                          // Default data dat aan de naam wordt toegevoegd
            StreamWriter sw = File.AppendText(myfile);                                              // Opent streamwriter
            //sw.WriteLine("\n");                                                                     // Zorgt er voor dat de data op een nieuwe lijn komt
            for (int i = 0; i < newPlayerCount; i++)                                                // For loop voor alle namen toe te voegen
            {
                sw.WriteLine(newPlayers[i] + defaultData);                                          // Schrijft de data in het bestand
                Console.WriteLine(newPlayers[i] + defaultData + " is aan het bestand toegevoegd.");
            }
            sw.Close();                                                                             // Sluit streamwriter af
            Console.WriteLine("Alle nieuwe spelers zijn toegevoegd!");
        }
        public void CheckNewplayer(string[] playerNames)
        {
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // Het pad naar de map 'Mijn Documenten'
            string myfile = Path.Combine(sourcepath, "Yahtzee_saves.txt");                                 // Bestandsnaam gecombineerd met het pad
            int playerCount = CountPlayers();                                                       // Geeft het huidig aantal spelers in het bestand terug
            string[,] allPlayerData = ReadPlayerData();                                             // Geeft alle data van de spelers in het bestand terug
            bool playerInList;                                                                      // Bool voor te controleren of een speler in het bestand zit
            string tempName;                                                                        // String die tijdelijk de naam van een speler bijhoudt
            List<string> newPlayers = new List<string>();                                           // List voor de spelers die aan het bestand toegevoegd moeten worden

            for (int i = 0; i < playerNames.Length; i++)                                            // For loop loopt voor elke ingegeven naam
            {
                playerInList = false;                                                               // Reset bool
                tempName = "";                                                                      // Reset string
                for (int j = 0; j < playerCount; j++)                                               // Gaat elke speler in het bestand af
                {
                    if (playerNames[i] == allPlayerData[j, 0])                                       // Kijkt of de ingegeven naam overeenkomt met een naam in het bestand
                    {
                        Console.WriteLine("De speler '{0}' bestaat al in het tekstbestand!", playerNames[i]);
                        playerInList = true;                                                        // Bool wordt true omdat de speler in het bestand zit
                    }
                    tempName = playerNames[i];                                                      // Naam van die speler wordt in de string gestopt
                }
                if (playerInList == false)                                                          // Kijkt of de speler in het bestand staat
                {
                    Console.WriteLine("De speler '{0}' staat niet in de lijst maar wordt aangemaakt...", tempName);
                    newPlayers.Add(tempName);                                                       // Voegt de speler toe aan de lijst
                }
            }
            AddNewPlayer(newPlayers);                                                               // Roept functie die de nieuwe spelers aam het bestand toevoegt
        }
        [STAThread]
       public static void Main()
        {


            
            int nbrPlayers = 4; // zet aantal om in int 

            string[] players = new string[nbrPlayers]; // player array

            string player1 = Prompt.ShowDialog("Enter player one's name", "Player"); // player naam 1   
            players[0] = player1; // in array players steken

            string player2 = Prompt.ShowDialog("Enter player two's name", "Player"); // player naam 2
            players[1] = player2; // in array players steken


            if (nbrPlayers == 3) // als er 3 spelers zijn, derde naam vragen
            {
                string player3 = Prompt.ShowDialog("Enter player three's name", "Player");
            }
            else if (nbrPlayers == 4) // als er 4 spelers zijn derde en vierde naam vragen
            {
                string player3 = Prompt.ShowDialog("Enter player three's name", "Player");
                string player4 = Prompt.ShowDialog("Enter player four's name", "Player");
                players[2] = player3; // in array players steken
                players[3] = player4; // in array players steken

            }


            int[] playerTotal = new int[nbrPlayers]; // totaalplayer score
            UserController usercontroller = new UserController();

            usercontroller.CheckFile();
            usercontroller.CheckNewplayer(players);
            Application.EnableVisualStyles();
            Application.Run(new Form1());


          
    }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption) // maakt de inputvelden en form aan voor spelernamen op te vragen
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 180,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen // centreerd de form
                };
                Label textLabel = new Label() { Left = 50, Top = 40, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 80, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 40, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
}
