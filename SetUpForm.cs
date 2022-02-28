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
        public SetUpForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }

        private void createPlayerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
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

        private void CreateSampleData()
        {
            availablePlayers.Add(new PlayerModel { Id = 1, Name = "Rocky", WinLoseRatio = 2.4, AmountOfMoneyWon = 1234 });
            availablePlayers.Add(new PlayerModel { Id = 2, Name = "Cora", WinLoseRatio = 0.8, AmountOfMoneyWon = 231 });

            selectedPlayers.Add(new PlayerModel { Id = 1, Name = "Bob", WinLoseRatio = 0.1, AmountOfMoneyWon = 4 });
        }

        private void WireUpLists()
        {
            choosePlayersComboBox.DataSource = null;
            choosePlayersComboBox.DataSource = availablePlayers;
            choosePlayersComboBox.DisplayMember = "DisplayName";


            vsingPlayersListBox.DataSource = null;
            vsingPlayersListBox.DataSource = selectedPlayers;
            vsingPlayersListBox.DisplayMember = "PlayerDisplayName";
        }



        private bool ValidateForm()
        {
            if (newPlayerNameTextBox.Text.Length == 0)
            {
                return false;
            }
            return true;


        }

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

        private void clearDataButton_Click(object sender, EventArgs e)
        {
            // TODO - Delete all TextFiles with a push of this button. 
            throw new NotImplementedException();
        }

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
    }
}
