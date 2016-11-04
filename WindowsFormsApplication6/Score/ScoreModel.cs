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

        protected string _besteWorp;
        public string besteWorp
        {
            get
            {
                return this._besteWorp;
            }
            set
            {
                this._besteWorp = value;
            }
        }
        protected string _hoogstMogelijkeScore;
        public string hoogstMogelijkeScore
        {
            get
            {
                return this._hoogstMogelijkeScore;
            }
            set
            {
                this._hoogstMogelijkeScore = value;
            }
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
