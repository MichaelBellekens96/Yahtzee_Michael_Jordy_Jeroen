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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.controller.diceModel.IsFixed = true;
            }
            else
            {
                this.controller.diceModel.IsFixed = false;
            }
        }
    }
}
