namespace Yahtzee
{
    partial class ScoreUi
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.score = new System.Windows.Forms.Label();
            this.scoreValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Location = new System.Drawing.Point(13, 13);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(52, 20);
            this.score.TabIndex = 0;
            this.score.Text = "score:";
            // 
            // scoreValue
            // 
            this.scoreValue.AutoSize = true;
            this.scoreValue.Location = new System.Drawing.Point(72, 13);
            this.scoreValue.Name = "scoreValue";
            this.scoreValue.Size = new System.Drawing.Size(0, 20);
            this.scoreValue.TabIndex = 1;
            // 
            // ScoreUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 721);
            this.Controls.Add(this.scoreValue);
            this.Controls.Add(this.score);
            this.Name = "ScoreUi";
            this.Text = "scoreUi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label scoreValue;
    }
}