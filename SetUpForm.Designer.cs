namespace RockysTicTacToeGame
{
    partial class SetUpForm
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
            this.clearDataButton = new System.Windows.Forms.Button();
            this.playersLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.howToPlayLinkLabel = new System.Windows.Forms.LinkLabel();
            this.removePlayerButton = new System.Windows.Forms.Button();
            this.choosePlayersComboBox = new System.Windows.Forms.ComboBox();
            this.selectPlayersLabel = new System.Windows.Forms.Label();
            this.makeABetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.makeABetLabel = new System.Windows.Forms.Label();
            this.vsingPlayersListBox = new System.Windows.Forms.ListBox();
            this.createPlayerButton = new System.Windows.Forms.Button();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.newPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.createNewPlayerLabel = new System.Windows.Forms.Label();
            this.addPlayerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.makeABetNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // clearDataButton
            // 
            this.clearDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.clearDataButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearDataButton.Location = new System.Drawing.Point(377, 12);
            this.clearDataButton.Name = "clearDataButton";
            this.clearDataButton.Size = new System.Drawing.Size(95, 35);
            this.clearDataButton.TabIndex = 27;
            this.clearDataButton.Text = "Clear All Data";
            this.clearDataButton.UseVisualStyleBackColor = false;
            this.clearDataButton.Click += new System.EventHandler(this.clearDataButton_Click);
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLabel.Location = new System.Drawing.Point(223, 26);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(65, 21);
            this.playersLabel.TabIndex = 26;
            this.playersLabel.Text = "Players";
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.startGameButton.Location = new System.Drawing.Point(227, 198);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(240, 96);
            this.startGameButton.TabIndex = 25;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // howToPlayLinkLabel
            // 
            this.howToPlayLinkLabel.AutoSize = true;
            this.howToPlayLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToPlayLinkLabel.Location = new System.Drawing.Point(388, 305);
            this.howToPlayLinkLabel.Name = "howToPlayLinkLabel";
            this.howToPlayLinkLabel.Size = new System.Drawing.Size(79, 17);
            this.howToPlayLinkLabel.TabIndex = 24;
            this.howToPlayLinkLabel.TabStop = true;
            this.howToPlayLinkLabel.Text = "How To Play";
            // 
            // removePlayerButton
            // 
            this.removePlayerButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePlayerButton.Location = new System.Drawing.Point(341, 161);
            this.removePlayerButton.Name = "removePlayerButton";
            this.removePlayerButton.Size = new System.Drawing.Size(131, 31);
            this.removePlayerButton.TabIndex = 23;
            this.removePlayerButton.Text = "Remove Selected";
            this.removePlayerButton.UseVisualStyleBackColor = true;
            this.removePlayerButton.Click += new System.EventHandler(this.removePlayerButton_Click);
            // 
            // choosePlayersComboBox
            // 
            this.choosePlayersComboBox.FormattingEnabled = true;
            this.choosePlayersComboBox.Location = new System.Drawing.Point(18, 176);
            this.choosePlayersComboBox.Name = "choosePlayersComboBox";
            this.choosePlayersComboBox.Size = new System.Drawing.Size(180, 29);
            this.choosePlayersComboBox.TabIndex = 22;
            // 
            // selectPlayersLabel
            // 
            this.selectPlayersLabel.AutoSize = true;
            this.selectPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPlayersLabel.Location = new System.Drawing.Point(14, 152);
            this.selectPlayersLabel.Name = "selectPlayersLabel";
            this.selectPlayersLabel.Size = new System.Drawing.Size(174, 21);
            this.selectPlayersLabel.TabIndex = 21;
            this.selectPlayersLabel.Text = "Select Players 1 and 2";
            // 
            // makeABetNumericUpDown
            // 
            this.makeABetNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.makeABetNumericUpDown.Location = new System.Drawing.Point(18, 276);
            this.makeABetNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.makeABetNumericUpDown.Name = "makeABetNumericUpDown";
            this.makeABetNumericUpDown.Size = new System.Drawing.Size(95, 29);
            this.makeABetNumericUpDown.TabIndex = 20;
            // 
            // makeABetLabel
            // 
            this.makeABetLabel.AutoSize = true;
            this.makeABetLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeABetLabel.Location = new System.Drawing.Point(14, 251);
            this.makeABetLabel.Name = "makeABetLabel";
            this.makeABetLabel.Size = new System.Drawing.Size(99, 21);
            this.makeABetLabel.TabIndex = 19;
            this.makeABetLabel.Text = "Make a Bet!";
            // 
            // vsingPlayersListBox
            // 
            this.vsingPlayersListBox.FormattingEnabled = true;
            this.vsingPlayersListBox.ItemHeight = 21;
            this.vsingPlayersListBox.Location = new System.Drawing.Point(227, 49);
            this.vsingPlayersListBox.Name = "vsingPlayersListBox";
            this.vsingPlayersListBox.Size = new System.Drawing.Size(245, 109);
            this.vsingPlayersListBox.TabIndex = 18;
            // 
            // createPlayerButton
            // 
            this.createPlayerButton.Location = new System.Drawing.Point(18, 108);
            this.createPlayerButton.Name = "createPlayerButton";
            this.createPlayerButton.Size = new System.Drawing.Size(180, 29);
            this.createPlayerButton.TabIndex = 17;
            this.createPlayerButton.Text = "Create Player";
            this.createPlayerButton.UseVisualStyleBackColor = true;
            this.createPlayerButton.Click += new System.EventHandler(this.createPlayerButton_Click);
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(14, 49);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(99, 21);
            this.playerNameLabel.TabIndex = 16;
            this.playerNameLabel.Text = "Player Name";
            // 
            // newPlayerNameTextBox
            // 
            this.newPlayerNameTextBox.Location = new System.Drawing.Point(18, 73);
            this.newPlayerNameTextBox.Name = "newPlayerNameTextBox";
            this.newPlayerNameTextBox.Size = new System.Drawing.Size(180, 29);
            this.newPlayerNameTextBox.TabIndex = 15;
            // 
            // createNewPlayerLabel
            // 
            this.createNewPlayerLabel.AutoSize = true;
            this.createNewPlayerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewPlayerLabel.Location = new System.Drawing.Point(14, 25);
            this.createNewPlayerLabel.Name = "createNewPlayerLabel";
            this.createNewPlayerLabel.Size = new System.Drawing.Size(150, 21);
            this.createNewPlayerLabel.TabIndex = 14;
            this.createNewPlayerLabel.Text = "Create New Player";
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Location = new System.Drawing.Point(18, 211);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(180, 37);
            this.addPlayerButton.TabIndex = 28;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // SetUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 329);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.clearDataButton);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.howToPlayLinkLabel);
            this.Controls.Add(this.removePlayerButton);
            this.Controls.Add(this.choosePlayersComboBox);
            this.Controls.Add(this.selectPlayersLabel);
            this.Controls.Add(this.makeABetNumericUpDown);
            this.Controls.Add(this.makeABetLabel);
            this.Controls.Add(this.vsingPlayersListBox);
            this.Controls.Add(this.createPlayerButton);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.newPlayerNameTextBox);
            this.Controls.Add(this.createNewPlayerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetUpForm";
            this.Text = "SetUpForm";
            ((System.ComponentModel.ISupportInitialize)(this.makeABetNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearDataButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.LinkLabel howToPlayLinkLabel;
        private System.Windows.Forms.Button removePlayerButton;
        private System.Windows.Forms.ComboBox choosePlayersComboBox;
        private System.Windows.Forms.Label selectPlayersLabel;
        private System.Windows.Forms.NumericUpDown makeABetNumericUpDown;
        private System.Windows.Forms.Label makeABetLabel;
        private System.Windows.Forms.ListBox vsingPlayersListBox;
        private System.Windows.Forms.Button createPlayerButton;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.TextBox newPlayerNameTextBox;
        private System.Windows.Forms.Label createNewPlayerLabel;
        private System.Windows.Forms.Button addPlayerButton;
    }
}