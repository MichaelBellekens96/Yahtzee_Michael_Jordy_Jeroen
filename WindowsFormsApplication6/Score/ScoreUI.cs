using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class ScoreUI : UserControl
    {

        public ScoreUI( )
        {
            InitializeComponent();
        }

        public void updateScore( int newScore)
        {
            this.scoreValueLabel.Text = newScore.ToString();
        }
    }
}
