using System;
using System.Collections.Generic;

namespace Yahtzee
{
    partial class DiceUpdateBtnUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Werp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DiceUpdateBtnUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Name = "DiceUpdateBtnUI";
            this.Size = new System.Drawing.Size(225, 79);
            this.ResumeLayout(false);

        }

        private List<DiceController> dices;

        public void setDices( List<DiceController> dices )
        {
            this.dices = dices;
        }

        public void trowAll()
        {
            //loop over dices en voer throw uit
            foreach (DiceController dice in this.dices)
            {
                if (dice.diceModel.IsFixed == false)
                {
                    dice.throwDice();
                }
            }
            Console.WriteLine("qsdf");
        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}
