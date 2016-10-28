using System;
using System.Collections.Generic;

namespace Yahtzee
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void customInitializeMethod()
        {
            // list met dicecontrollersaanmaken
            List<DiceController> dices = new List<DiceController>();

            // Create new instance of scoreboard
            ScoreController score = new ScoreController(dices);
            // score.setDices( dices );

            DiceUpdateBtnUI updateBtn = new DiceUpdateBtnUI();

            updateBtn.Left = score.view.Width;


            for (int i = 0; i < 5; i++)
            {
                // test
                // Create new instance of teerling
                DiceController dice = new DiceController();

                // Add score component as an observer to the dice
                dice.subscribeObserver(score);
                dices.Add(dice);

                // Add the height of the score component to the top of the dice 
                // That way they don't overlap
                dice.view.Top = updateBtn.Height;


                dice.view.Left = score.view.Width * i;
                // Add dice view to form
                this.Controls.Add(dice.view);
            }

            updateBtn.setDices(dices);
            this.Controls.Add(updateBtn);
            this.Controls.Add(score.view);

            // in for loop
            // Dice aanmaken
            // positie voor elke dice wijzigen dmv dice.view.Left = score.view.width * waarde van i;
            // this.Controls.Add(dice.view);
            // einde forloop

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(464, 336);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

