namespace RockysTicTacToeGame
{
    partial class GruWithHoseForm
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
            this.components = new System.ComponentModel.Container();
            this.stopTimer = new System.Windows.Forms.Timer(this.components);
            this.gruWithAHosePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gruWithAHosePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // stopTimer
            // 
            this.stopTimer.Enabled = true;
            this.stopTimer.Interval = 3500;
            this.stopTimer.Tick += new System.EventHandler(this.stopTimer_Tick);
            // 
            // gruWithAHosePictureBox
            // 
            this.gruWithAHosePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gruWithAHosePictureBox.Image = global::RockysTicTacToeGame.Properties.Resources.WaterHoseGru;
            this.gruWithAHosePictureBox.Location = new System.Drawing.Point(0, 0);
            this.gruWithAHosePictureBox.Name = "gruWithAHosePictureBox";
            this.gruWithAHosePictureBox.Size = new System.Drawing.Size(411, 253);
            this.gruWithAHosePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gruWithAHosePictureBox.TabIndex = 0;
            this.gruWithAHosePictureBox.TabStop = false;
            // 
            // GruWithHoseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 253);
            this.ControlBox = false;
            this.Controls.Add(this.gruWithAHosePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GruWithHoseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GruWithHoseForm";
            ((System.ComponentModel.ISupportInitialize)(this.gruWithAHosePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gruWithAHosePictureBox;
        private System.Windows.Forms.Timer stopTimer;
    }
}