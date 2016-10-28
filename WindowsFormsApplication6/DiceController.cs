using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public class DiceController
    {
        private UserControl _diceUI;
        private DiceModel _diceModel;

        public DiceController()
        {
            this._diceUI = new DiceUI( this );
            this._diceModel = new DiceModel();
        }

        public UserControl getView()
        {
            return this._diceUI;
        }

        

        public int throwDice()
        {
            //int randomValue = this._randomGenerator.Next(1,7);
            //this._diceModel.value = randomValue;
            int value = 5;

            return value;
            //return randomValue;
        }

    }
}
