namespace Yahtzee
{
    partial class DiceUI
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
            this.teerlingValue = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // teerlingValue
            // 
            this.teerlingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teerlingValue.Location = new System.Drawing.Point(27, 9);
            this.teerlingValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.teerlingValue.Name = "teerlingValue";
            this.teerlingValue.Size = new System.Drawing.Size(170, 164);
            this.teerlingValue.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Location = new System.Drawing.Point(27, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 44);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Vast zetten";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);

            // 
            // DiceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.teerlingValue);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DiceUI";
            this.Size = new System.Drawing.Size(225, 230);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label teerlingValue;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
