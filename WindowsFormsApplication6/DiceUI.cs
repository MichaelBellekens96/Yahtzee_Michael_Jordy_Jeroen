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
    public partial class DiceUI : UserControl
    {
        private DiceController controller;

        public DiceUI( DiceController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newValue = this.controller.throwDice();

            this.teerlingValue.Text = newValue.ToString();
        }
    }
}
