using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLibrary.DataAccess;
using TicTacToeLibrary.Models;

namespace RockysTicTacToeGame
{
    public partial class TicTacToeForm : Form
    {
        private PlayerModel updatePlayer1 = SetUpForm.player1Model;
        private PlayerModel updatePlayer2 = SetUpForm.player1Model;
        private List<PlayerModel> dudeFigureThisOut = GlobalConfig.Connection.GetAllPlayers();
        private bool player1turn = true;
        private bool player2turn = false;
        private readonly SkillsModel player1Skills = new SkillsModel();
        private readonly SkillsModel player2Skills = new SkillsModel();

        public TicTacToeForm()
        {
            InitializeComponent();
            player1Label.Text = SetUpForm.playerOneName;
            player2Label.Text = SetUpForm.playerTwoName;
            amountBettingNumericUpDown.Value = SetUpForm.playersBet;
            
            
        }

        private void ClickedOnBoard(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
            {
                return;
            }

            if (player1turn)
            {
                PlayerTurnFunction();

                totalWinningsP1TextBox.Text = "$100";
                p.Image = player1PictureBox.Image;
                CalculateWin();
                return;
            }

            if (player2turn)
            {
                PlayerTurnFunction();
                //player2Label.Text = "Cora"; // TODO - Get this information from SetUpForm
                totalWinningsP2TextBox.Text = "$101";
                p.Image = player2PictureBox.Image;
                CalculateWin();
                return;
            }
            // EnteredPlayersModel em = new EnteredPlayersModel();
            // Calculations.RandomizeWhoStarts(em);
        }
        private void CalculateWin()
        {
            // TODO - Move this method to it's own class.
            int[,] win = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] board = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] player1StartGame = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            int[,] player2StartGame = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            int count = 0;

            PictureBox[] boxes =
         {
                ticTacToeBox1, ticTacToeBox2, ticTacToeBox3,
                ticTacToeBox4, ticTacToeBox5, ticTacToeBox6,
                ticTacToeBox7, ticTacToeBox8, ticTacToeBox9
            };
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].Image != player1PictureBox.Image)
                {
                    count++;

                }

            }
            MessageBox.Show($"{count}");
        }

        private void FlameThrowerGru()
        {

            FlameThrowerGru fire = new FlameThrowerGru();
            if (player2Skills.ClearBoard == true)
            {
                MessageBox.Show($"{player2Label.Text} you already used this Skill!");
                return;
            }
            else
            {
                ClearBoard();
                fire.ShowDialog();
                player2Skills.ClearBoard = true;
            }

        }

        private void clearBoardP2Button_Click(object sender, EventArgs e)
        {
            if (player2turn)
            {
                FlameThrowerGru();
                clearBoardP2Button.BackColor = Color.LightPink;
            }
            return;

        }

        private void PlayerTurnFunction()
        {
            if (player1turn)
            {
                player1turn = false;
                player2turn = true;
                return;
            }
            if (player2turn)
            {
                player1turn = true;
                player2turn = false;
                return;
            }
        }
        private void ClearBoard()
        {
            PictureBox[] boxes =
           {
                ticTacToeBox1, ticTacToeBox2, ticTacToeBox3,
                ticTacToeBox4, ticTacToeBox5, ticTacToeBox6,
                ticTacToeBox7, ticTacToeBox8, ticTacToeBox9
            };
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Image = null;
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            foreach (PlayerModel p in dudeFigureThisOut)
            {
                // TODO - Add a UpdatePlayer Method instead of creating a new player!
                if (p.DisplayName == updatePlayer1.DisplayName)
                {
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }
                if (p.DisplayName == updatePlayer2.DisplayName)
                {
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }
                
                
            }
            this.Close();
            /*            ClearBoard();
                        player1turn = true;
                        player2turn = false;
                        player2Skills.ClearBoard = false;
                        player1Label.Text = "Player 1";
                        totalWinningsP1TextBox.Text = " ";
                        player2Label.Text = "Player 2";
                        totalWinningsP2TextBox.Text = " ";
                        clearBoardP2Button.BackColor = Color.White;*/

        }
    }
}
