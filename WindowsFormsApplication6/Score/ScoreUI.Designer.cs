namespace Yahtzee
{
    partial class ScoreUI
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
            this.scoreTextLabel = new System.Windows.Forms.Label();
            this.scoreValueLabel = new System.Windows.Forms.Label();
            this.lblGegooid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreTextLabel
            // 
            this.scoreTextLabel.AutoSize = true;
            this.scoreTextLabel.Location = new System.Drawing.Point(21, 18);
            this.scoreTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreTextLabel.Name = "scoreTextLabel";
            this.scoreTextLabel.Size = new System.Drawing.Size(49, 17);
            this.scoreTextLabel.TabIndex = 0;
            this.scoreTextLabel.Text = "Score:";
            // 
            // scoreValueLabel
            // 
            this.scoreValueLabel.AutoSize = true;
            this.scoreValueLabel.Location = new System.Drawing.Point(77, 18);
            this.scoreValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreValueLabel.Name = "scoreValueLabel";
            this.scoreValueLabel.Size = new System.Drawing.Size(16, 17);
            this.scoreValueLabel.TabIndex = 1;
            this.scoreValueLabel.Text = "0";
            // 
            // lblGegooid
            // 
            this.lblGegooid.AutoSize = true;
            this.lblGegooid.Location = new System.Drawing.Point(21, 46);
            this.lblGegooid.Name = "lblGegooid";
            this.lblGegooid.Size = new System.Drawing.Size(139, 17);
            this.lblGegooid.TabIndex = 2;
            this.lblGegooid.Text = "Wat heb je gegooid?";
            // 
            // ScoreUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGegooid);
            this.Controls.Add(this.scoreValueLabel);
            this.Controls.Add(this.scoreTextLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ScoreUI";
            this.Size = new System.Drawing.Size(340, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreTextLabel;
        private System.Windows.Forms.Label scoreValueLabel;
        private System.Windows.Forms.Label lblGegooid;
    }
}
