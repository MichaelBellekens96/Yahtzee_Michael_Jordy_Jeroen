using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class DiceController
    {
        protected DiceUI diceUI;
        protected DiceModel diceModel;
        protected Random randomGenerator;

        public DiceController()
        {
            // Create dice model
            this.diceModel = new DiceModel();

            // Create dice UI and inject controller (= this)
            // Injection is necessary in order for the UI to notify something has happened
            this.diceUI = new DiceUI( this );

            // Create new random generator using seed (for absolute random generation)
            this.randomGenerator = new Random(Guid.NewGuid().GetHashCode());
        }

        // Method that returns instance of the view
        public DiceUI view
        {
            get {
                return this.diceUI;
            }
        }

        // Method that throws dice by generating new random number
        public int throwDice()
        {
            // Generate new random number
            int randomNumber = this.randomGenerator.Next(1, 7);

            // Update the model
            this.diceModel.value = randomNumber;

            // Return the value
            return randomNumber;
        }
    }
}
