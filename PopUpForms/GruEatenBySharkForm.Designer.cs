namespace RockysTicTacToeGame
{
    partial class GruEatenBySharkForm
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
            this.gruEatenByASharkPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gruEatenByASharkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // stopTimer
            // 
            this.stopTimer.Enabled = true;
            this.stopTimer.Interval = 1800;
            this.stopTimer.Tick += new System.EventHandler(this.stopTimer_Tick);
            // 
            // gruEatenByASharkPictureBox
            // 
            this.gruEatenByASharkPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gruEatenByASharkPictureBox.Image = global::RockysTicTacToeGame.Properties.Resources.GruEatenByShark;
            this.gruEatenByASharkPictureBox.Location = new System.Drawing.Point(0, 0);
            this.gruEatenByASharkPictureBox.Name = "gruEatenByASharkPictureBox";
            this.gruEatenByASharkPictureBox.Size = new System.Drawing.Size(426, 243);
            this.gruEatenByASharkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gruEatenByASharkPictureBox.TabIndex = 0;
            this.gruEatenByASharkPictureBox.TabStop = false;
            // 
            // GruEatenBySharkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 243);
            this.ControlBox = false;
            this.Controls.Add(this.gruEatenByASharkPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GruEatenBySharkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GruEatenBySharkForm";
            ((System.ComponentModel.ISupportInitialize)(this.gruEatenByASharkPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gruEatenByASharkPictureBox;
        private System.Windows.Forms.Timer stopTimer;
    }
}