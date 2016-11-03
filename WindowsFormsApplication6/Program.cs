using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string[] players = new string[4]; // player array
           
            string nbrPlayersStr = Prompt.ShowDialog("2, 3 or 4 players", "Player"); // vraagt het aantal spelers
            int nbrPlayers = Int32.Parse(nbrPlayersStr); // zet aantal om in int 

            string player1 = Prompt.ShowDialog("Enter player one's name", "Player"); // player naam 1   
            players[0] = player1; // in array players steken
            
            string player2 = Prompt.ShowDialog("Enter player two's name", "Player"); // player naam 2
            players[1] = player2; // in array players steken


            if (nbrPlayers==3) // als er 3 spelers zijn, derde naam vragen
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
    

