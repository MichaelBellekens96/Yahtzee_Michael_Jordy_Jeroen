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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Werp";
            this.toolTip1.SetToolTip(this.button1, "Werp de dobbelstenen die niet vast staan");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DiceUpdateBtnUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DiceUpdateBtnUI";
            this.Size = new System.Drawing.Size(200, 63);
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
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
