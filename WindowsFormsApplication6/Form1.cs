using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Form1 : Form 
    {

        public Form1()
        {
            
            InitializeComponent();
            customInitializeMethod();
            button1.Text = "Highscores";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void helpUI1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(destination, "Yahtzee_saves.txt");
            Process.Start(path);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
