using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToeLibrary.DataAccess;
using TicTacToeLibrary.Models;

namespace RockysTicTacToeGame
{
    public partial class SetUpForm : Form
    {

        private List<PlayerModel> availablePlayers = GlobalConfig.Connection.GetAllPlayers();
        private List<PlayerModel> selectedPlayers = new List<PlayerModel>();
        public static PlayerModel player1Model = new PlayerModel();
        public static PlayerModel player2Model = new PlayerModel();
        public static string playerOneName = null;
        public static string playerTwoName = null;
        public static decimal playersBet = 0;
        private const string PlayerFile = "PlayerModels.csv";
        public SetUpForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        /// <summary>
        /// A button that creates a new player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPlayerButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewPlayer())
            {
                PlayerModel p = new PlayerModel();
                p.Name = newPlayerNameTextBox.Text;
                p.Wins = 0;
                p.WinLoseRatio = 0;
                p.GamesPlayed = 0;
                p.AmountOfMoneyWon = decimal.Zero;

                p = GlobalConfig.Connection.CreatePlayer(p);

                selectedPlayers.Add(p);

                WireUpLists();

                newPlayerNameTextBox.Text = "";
            }
            else
            {
                MessageBox.Show($"When Creating a new Player you forgot to enter a name.");
            }

        }


        /// <summary>
        /// Sample data for testing
        /// </summary>
        private void CreateSampleData()
        {
            availablePlayers.Add(new PlayerModel { Id = 1, Name = "Rocky", WinLoseRatio = 2.4, AmountOfMoneyWon = 1234 });
            availablePlayers.Add(new PlayerModel { Id = 2, Name = "Cora", WinLoseRatio = 0.8, AmountOfMoneyWon = 231 });

            selectedPlayers.Add(new PlayerModel { Id = 1, Name = "Bob", WinLoseRatio = 0.1, AmountOfMoneyWon = 4 });
        }


        /// <summary>
        /// Adds the datasorces to the listbox and ComboBox
        /// </summary>
        private void WireUpLists()
        {
            choosePlayersComboBox.DataSource = null;
            choosePlayersComboBox.DataSource = availablePlayers;
            choosePlayersComboBox.DisplayMember = "DisplayName";


            vsingPlayersListBox.DataSource = null;
            vsingPlayersListBox.DataSource = selectedPlayers;
            vsingPlayersListBox.DisplayMember = "PlayerDisplayName";
        }


        /// <summary>
        /// Bool that checks if a player has a valid name
        /// </summary>
        /// <returns></returns>
        private bool ValidateNewPlayer()
        {
            if (newPlayerNameTextBox.Text.Length == 0)
            {
                return false;
            }
            return true;


        }

        /// <summary>
        /// Adds the selected player to the VsingListBox and removes it from the comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            PlayerModel p = (PlayerModel)choosePlayersComboBox.SelectedItem;

            if (p != null)
            {
                availablePlayers.Remove(p);

                selectedPlayers.Add(p);

                WireUpLists();

            }
        }


        /// <summary>
        /// Removes the selected player from the Listbox and adds it to the Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removePlayerButton_Click(object sender, EventArgs e)
        {
            PlayerModel p = (PlayerModel)vsingPlayersListBox.SelectedItem;

            if (p != null)
            {
                selectedPlayers.Remove(p);

                availablePlayers.Add(p);

                WireUpLists();
            }
        }

        /// <summary>
        /// Refreshes the Listbox and dropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshDataButton_Click(object sender, EventArgs e)
        {
            RefreshTheData();
            WireUpLists();
        }

        /// <summary>
        /// Starts a new game of TicTacToe and Updates Player1 and Player2 for the TicTacToeForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void startGameButton_Click(object sender, EventArgs e)
        {
            if (CheckNumberOfPlayers())
            {
                return;
            }
            int count = 0;
            foreach (PlayerModel player in vsingPlayersListBox.Items)
            {
                count++;

                if (count == 1)
                {
                    player1Model = player;
                    playerOneName = player.Name;
                }
                if (count == 2)
                {
                    player2Model = player;
                    playerTwoName = player.Name;

                }
            }       
                playersBet = makeABetNumericUpDown.Value;
                TicTacToeForm startgame = new TicTacToeForm();
                startgame.ShowDialog();
        }

        /// <summary>
        /// A bool that checks the number of players in the Vsing ListBox.
        /// </summary>
        /// <returns></returns>
        public bool CheckNumberOfPlayers()
        {
            if (vsingPlayersListBox.Items.Count == 0)
            {
                MessageBox.Show("Please add 2 players.");
                return true;
            }
            if (vsingPlayersListBox.Items.Count <= 1)
            {
                MessageBox.Show("Please add 2 players.");
                return true;
            }
            if (vsingPlayersListBox.Items.Count >= 3)
            {
                MessageBox.Show("You can only have 2 players.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the collection of object from the vsingPlayers Listbox and refreshes
        /// </summary>
        private void RefreshTheData()
        {
            availablePlayers = GlobalConfig.Connection.GetAllPlayers();

            foreach (PlayerModel p in vsingPlayersListBox.Items)
            {
                selectedPlayers.Remove(p);
            }
        }


        /// <summary>
        /// Deletes the PlayerFile Textfile and refreshes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllDataButton_Click(object sender, EventArgs e)
        {
            TextConnectorProcessor.DeletePlayerFile(PlayerFile);
            RefreshTheData();
            WireUpLists();
        }
    }
}
