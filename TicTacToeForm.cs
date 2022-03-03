using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TicTacToeLibrary.DataAccess;
using TicTacToeLibrary.Models;

namespace RockysTicTacToeGame
{
    public partial class TicTacToeForm : Form
    {
        private PlayerModel updatePlayer1 = SetUpForm.player1Model;
        private PlayerModel updatePlayer2 = SetUpForm.player2Model;
        private List<PlayerModel> dudeFigureThisOut = GlobalConfig.Connection.GetAllPlayers();
        private bool player1Turn = true;
        private bool player2Turn = false;
        private readonly SkillsModel player1Skills = new SkillsModel();
        private readonly SkillsModel player2Skills = new SkillsModel();
        private int[,] score = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int[,] player1StartGameScore = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int[,] player2StartGameScore = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        //private int[,] clearScore = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };


        public TicTacToeForm()
        {
            InitializeComponent();
            
            player1Label.Text = SetUpForm.playerOneName;
            player2Label.Text = SetUpForm.playerTwoName;
            amountBettingNumericUpDown.Value = SetUpForm.playersBet;
            totalWinningsP1TextBox.Text = SetUpForm.player1Model.AmountOfMoneyWon.ToString();
            totalWinningsP2TextBox.Text = SetUpForm.player2Model.AmountOfMoneyWon.ToString();
            winLossRatioP1TextBox.Text = SetUpForm.player1Model.WinLoseRatio.ToString();
            winLossRatioP2TextBox.Text = SetUpForm.player2Model.WinLoseRatio.ToString();


        }

        private void ClickedOnBoard(object sender, EventArgs e)
        {
            //UpdateScoreBoard();
            //FigureOutAWinWithSwitchs();
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
            {
                return;
            }

            if (player1Turn)
            {
                p.Image = player1PictureBox.Image;
                PlayerTurnFunction();
                //p.Image = player1PictureBox.Image;
                UpdateScoreBoard();
                FigureOutAWinWithSwitchs();
                return;
            }

            if (player2Turn)
            {
                p.Image = player2PictureBox.Image;
                PlayerTurnFunction();
                UpdateScoreBoard();
                FigureOutAWinWithSwitchs();
                return;
            }
        }
        private void UpdateScoreBoard()
        {
            int j = 0;

            PictureBox[,] boxes =
         {
                {ticTacToeBox7, ticTacToeBox8, ticTacToeBox9 },
                { ticTacToeBox4, ticTacToeBox5, ticTacToeBox6 },
                { ticTacToeBox1, ticTacToeBox2, ticTacToeBox3 } 
            };
            for (int i = 0; i <= 2; i++)
            {

                if (boxes[i,j].Image == player1PictureBox.Image)
                {
                    player1StartGameScore[i,j] = 1;

                }
                if (boxes[i, j].Image == player2PictureBox.Image)
                {
                    player2StartGameScore[i, j] = 1;

                }
                if (i == 2)
                {
                    j++;
                    i=-1;
                    if (j == 3)
                    {
                        return;
                    }
                }

            }
        }

        private void FlameThrowerGru()
        {

            FlameThrowerGru fire = new FlameThrowerGru();
 /*           if (player2Skills.ClearBoard == true)
            {
                MessageBox.Show($"{player2Label.Text} you already used this Skill!");
                return;
            }
            else
            {*/
                ClearBoard();
                fire.ShowDialog();
                //player2Skills.ClearBoard = true;
 //           }

        }

        private void clearBoardP2Button_Click(object sender, EventArgs e)
        {
            if (player2Turn || player1Turn)
            {
                FlameThrowerGru();
                clearBoardP2Button.BackColor = Color.LightPink;
            }
            return;

        }

        private void PlayerTurnFunction()
        {
            if (player1Turn)
            {
                player1Turn = false;
                player2Turn = true;
                player1Label.BackColor = Color.White;
                player2Label.BackColor = Color.LightGreen;
                return;
            }
            if (player2Turn)
            {
                player1Turn = true;
                player2Turn = false;
                player2Label.BackColor = Color.White;
                player1Label.BackColor = Color.LightGreen;
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

        private void FigureOutAWinWithSwitchs()
        {
            for (int winner = 0; winner <= 7; winner++)
            {
                switch (winner)
                {
                    case 0:
                        //x1 = score[0, 0];
                        //x2 = score[0, 1];
                        //x3 = score[0, 2];
                        int p1X123 = player1StartGameScore[0, 0] + player1StartGameScore[0, 1] + player1StartGameScore[0, 2];
                        int p2X123 = player2StartGameScore[0, 0] + player2StartGameScore[0, 1] + player2StartGameScore[0, 2];
                        if (p1X123 == 3 || p2X123 == 3)
                        {
                            if (p1X123 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;

                    case 1:
                        //x4 = score[1, 0];
                        //x5 = score[1, 1];
                        //x6 = score[1, 2];
                        int p1X456 = player1StartGameScore[1, 0] + player1StartGameScore[1, 1] + player1StartGameScore[1, 2];
                        int p2X456 = player2StartGameScore[1, 0] + player2StartGameScore[1, 1] + player2StartGameScore[1, 2];
                        if (p1X456 == 3 || p2X456 == 3)
                        {
                            if (p1X456 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 2:
                        //x7 = score[2, 0];
                        //x8 = score[2, 1];
                        //x9 = score[2, 2];
                        int p1X789 = player1StartGameScore[2, 0] + player1StartGameScore[2, 1] + player1StartGameScore[2, 2];
                        int p2X789 = player2StartGameScore[2, 0] + player2StartGameScore[2, 1] + player2StartGameScore[2, 2];
                        if (p1X789 == 3 || p2X789 == 3)
                        {
                            if (p1X789 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 3:                        
                        //x7 = score[0, 0];
                        //x4 = score[1, 0];
                        //x1 = score[2, 0];
                        int p1X741 = player1StartGameScore[0, 0] + player1StartGameScore[1, 0] + player1StartGameScore[2, 0];
                        int p2X741 = player2StartGameScore[0, 0] + player2StartGameScore[1, 0] + player2StartGameScore[2, 0];
                        if (p1X741 == 3 || p2X741 == 3)
                        {
                            if (p1X741 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 4:
                        //x8 = score[0, 1];
                        //x5 = score[1, 1];
                        //x2 = score[2, 1];
                        int p1X852 = player1StartGameScore[0, 1] + player1StartGameScore[1, 1] + player1StartGameScore[2, 1];
                        int p2X852 = player2StartGameScore[0, 1] + player2StartGameScore[1, 1] + player2StartGameScore[2, 1];
                        if (p1X852 == 3 || p2X852 == 3)
                        {
                            if (p1X852 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 5:
                        //x9 = score[0, 2];
                        //x6 = score[1, 2];
                        //x3 = score[2, 2];
                        int p1X963 = player1StartGameScore[0, 2] + player1StartGameScore[1, 2] + player1StartGameScore[2, 2];
                        int p2X963 = player2StartGameScore[0, 2] + player2StartGameScore[1, 2] + player2StartGameScore[2, 2];
                        if (p1X963 == 3 || p2X963 == 3)
                        {
                            if (p1X963 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 6:
                        //x7 = score[0, 0];
                        //x5 = score[1, 1];
                        //x3 = score[2, 2];
                        int p1X753 = player1StartGameScore[0, 0] + player1StartGameScore[1, 1] + player1StartGameScore[2, 2];
                        int p2X753 = player2StartGameScore[0, 0] + player2StartGameScore[1, 1] + player2StartGameScore[2, 2];
                        if (p1X753 == 3 || p2X753 == 3)
                        {
                            if (p1X753 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                    case 7:
                        //x9 = score[0, 2];
                        //x5 = score[1, 1];
                        //x1 = score[2, 0];
                        int p1X951 = player1StartGameScore[0, 2] + player1StartGameScore[1, 1] + player1StartGameScore[2, 0];
                        int p2X951 = player2StartGameScore[0, 2] + player2StartGameScore[1, 1] + player2StartGameScore[2, 0];
                        if (p1X951 == 3 || p2X951 == 3)
                        {
                            if (p1X951 == 3)
                            {
                                MessageBox.Show($"{player1Label.Text} Wins!");
                            }
                            else
                            {
                                MessageBox.Show($"{player2Label.Text} Wins!");
                            }
                        }
                        break;
                }
            }
        }

        private void moveTheirPieceP2Button_Click(object sender, EventArgs e)
        {
        }
    }
}
