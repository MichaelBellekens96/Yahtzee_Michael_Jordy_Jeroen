using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class ScoreController
    {
        private ScoreModel scoreModel;
        private ScoreUI scoreUI;
        private List<DiceController> dices;

        public ScoreController( List<DiceController> dices)
        {
            this.dices = dices;
            this.scoreModel = new ScoreModel();
            this.scoreUI = new ScoreUI();
        }

        // Method that returns view
        public ScoreUI view
        {
            get
            {
                return this.scoreUI;
            }
        }

        // Method that gets executed when the observable is changed
        public void notify( int newDiceValue )
        {
            int score = 0;

            foreach (DiceController dice in this.dices )
            {
                score += dice.diceModel.value;
            }
            // Update model with new value
            this.scoreModel.score = score;

            // Update view with new value
            this.scoreUI.updateScore(score);
        }



        // updateScore

        // krijgt list met dices als argument
        // loopt over dices
        // haalt uit elke dice de waarde
        // telt deze op bij een voorlpige variabele
    // einde for loop

        // zet nieuwe score in model en eventueel notify hergebruiken

        
    }
}
