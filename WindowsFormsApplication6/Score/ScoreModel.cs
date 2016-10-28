using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class ScoreModel
    {
        protected int _score;

        public ScoreModel()
        {
            this._score = 0;
        }

        public int score {
            get {
                return this._score;
            }
            set
            {
                this._score = value;
            }
        }

    }
}
