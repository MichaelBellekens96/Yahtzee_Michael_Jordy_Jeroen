using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class DiceModel
    {

        private int _ValueType;
        private bool _isFixed;

        public int ValueType
        {
            get
            {
                return this._ValueType;
            }

            set
            {
                this._ValueType = value;
            }
        }

        public bool IsFixed
        {
            get
            {
                return this._isFixed;
            }

            set
            {
                this._isFixed = value;
            }
        }
    }
}
