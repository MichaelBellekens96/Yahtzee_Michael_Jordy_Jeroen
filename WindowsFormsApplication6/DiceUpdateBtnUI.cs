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
    public partial class DiceUpdateBtnUI : UserControl
    {
        UserController usercontroller = new UserController();
        int i = -1;
        int y = 1;



        public DiceUpdateBtnUI()
        {
            InitializeComponent();
            MessageBox.Show("Speler " + y.ToString() + " aan de beurt");
            i++;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.trowAll();
            i++;

            if (i == 3)
            {
                y++;
                MessageBox.Show("Speler " + y.ToString() + " aan de beurt");
                i = 0;
                
            }
            if (y == 4)
            {
                y = 0;
            }
        }
    }
}


