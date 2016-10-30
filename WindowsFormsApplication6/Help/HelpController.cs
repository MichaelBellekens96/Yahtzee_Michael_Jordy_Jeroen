using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Yahtzee
{
    public class HelpController
    {
        public HelpController()
        {

        }
        protected void WriteMyFile(string path)
        {
            StreamWriter outputStream =
            File.CreateText(path);
            outputStream.WriteLine("Tijdens een beurt mag een speler de dobbelstenen ten hoogste drie keer werpen.");
            outputStream.WriteLine("Bij de eerste en tweede worp kan hij enkele dobbelstenen opzij leggen en enkel de andere opnieuw werpen.");
            outputStream.WriteLine("Na de derde beurt is hij verplicht om zijn combinatie onder te brengen in een van de dertien categorieën.");
            outputStream.WriteLine("Dit mag ook na de eerste of tweede worp.");
            outputStream.WriteLine("Nadat de speler een categorie ingevuld heeft, is de volgende speler aan de beurt.");
            outputStream.WriteLine("Een speler moet elke categorie één keer invullen tijdens het spel.");
            outputStream.WriteLine("Dit betekent dat het kan gebeuren dat een speler nul punten scoort in een bepaalde categorie.");
            outputStream.WriteLine("Nadat de spelers in alle categorieën een combinatie ingevuld hebben, tellen zij hun punten op.");
            outputStream.WriteLine("De speler met het hoogste aantal punten is de winnaar.");
            outputStream.WriteLine("Er worden ook wedstrijden van vijf ronden gespeeld, waarbij de speler met het hoogste puntentotaal na vijf ronden wordt uitgeroepen tot algehele winnaar.");
            outputStream.WriteLine("Het spel kan ook alleen gespeeld worden.");
            outputStream.WriteLine("");
            outputStream.WriteLine("Combinatie Aantal punten");
            outputStream.WriteLine("Drie gelijke = Totaal aantal ogen");
            outputStream.WriteLine("Vier gelijke = Totaal aantal ogen");
            outputStream.WriteLine("Kleine straat = 30 punten");
            outputStream.WriteLine("Grote straat = 40 punten");
            outputStream.WriteLine("Full House = 25 punten");
            outputStream.WriteLine("Kans = Totaal aantal ogen");
            outputStream.WriteLine("Yahtzee	= 50 punten");

            outputStream.Close();
            Process.Start(path);
        }

        public void getPathString()
        {
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(destination, "Yahtzee Uitleg.txt");
            if (!File.Exists(path))
            {
                WriteMyFile(path);
            }
            else { Process.Start(path); }
        }
    }
}
