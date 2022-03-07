namespace RockysTicTacToeGame
{
    partial class VectorKeyboardForm
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
            this.closeFormTimer = new System.Windows.Forms.Timer(this.components);
            this.keyboardVectorClearPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardVectorClearPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeFormTimer
            // 
            this.closeFormTimer.Enabled = true;
            this.closeFormTimer.Interval = 2000;
            this.closeFormTimer.Tick += new System.EventHandler(this.keyboardVectorClearTimer);
            // 
            // keyboardVectorClearPictureBox
            // 
            this.keyboardVectorClearPictureBox.Image = global::RockysTicTacToeGame.Properties.Resources.butt_rubbing_keyboard;
            this.keyboardVectorClearPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.keyboardVectorClearPictureBox.Name = "keyboardVectorClearPictureBox";
            this.keyboardVectorClearPictureBox.Size = new System.Drawing.Size(498, 270);
            this.keyboardVectorClearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.keyboardVectorClearPictureBox.TabIndex = 0;
            this.keyboardVectorClearPictureBox.TabStop = false;
            // 
            // VectorKeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 267);
            this.ControlBox = false;
            this.Controls.Add(this.keyboardVectorClearPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VectorKeyboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VectorKeyboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.keyboardVectorClearPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer closeFormTimer;
        private System.Windows.Forms.PictureBox keyboardVectorClearPictureBox;
    }
}