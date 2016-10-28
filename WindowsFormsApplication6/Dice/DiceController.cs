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
        public DiceModel diceModel;
        protected Random randomGenerator;
        protected List<dynamic> observers = new List<dynamic>();

        public DiceController()
        {
            // Create dice model
            this.diceModel = new DiceModel();

            // Create dice UI and inject controller (= this)
            // Injection is necessary in order for the UI to notify the controller something has happened
            this.diceUI = new DiceUI(this);

            // Create new random generator using seed (for absolute random generation)
            this.randomGenerator = new Random(Guid.NewGuid().GetHashCode());
        }

        // Method that returns instance of the view
        public DiceUI view
        {
            get
            {
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
            this.notifyObservers();

            this.diceUI.teerlingValue.Text = randomNumber.ToString();
            // Return the value
            return randomNumber;

        }

        // Add observer to observer list
        public void subscribeObserver(dynamic observer)
        {
            this.observers.Add(observer);
        }

        // Loop over observers and execute method that needs to be run 
        // when observable (= dice in this case) changes
        protected void notifyObservers()
        {
            foreach ( dynamic observer in this.observers)
            {
                observer.notify( this.diceModel.value ); 
            }
        }
    }
}