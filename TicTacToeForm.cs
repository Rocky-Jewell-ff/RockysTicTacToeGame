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
        private PlayerModel updatePlayer2 = SetUpForm.player2Model;
        private List<PlayerModel> dudeFigureThisOut = GlobalConfig.Connection.GetAllPlayers();
        private bool player1Turn = true;
        private bool player2Turn = false;
        private readonly SkillsModel player1Skills = new SkillsModel();
        private readonly SkillsModel player2Skills = new SkillsModel();
        private int[,] score = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int[,] player1StartGameScore = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int[,] player2StartGameScore = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };


        public TicTacToeForm()
        {
            InitializeComponent();
            
            player1Label.Text = SetUpForm.playerOneName;
            player2Label.Text = SetUpForm.playerTwoName;
            amountBettingNumericUpDown.Value = SetUpForm.playersBet;
            totalWinningsP1TextBox.Text = SetUpForm.player1Model.AmountOfMoneyWon.ToString();
            totalWinningsP2TextBox.Text = SetUpForm.player2Model.AmountOfMoneyWon.ToString();
            totalWinsP1TextBox.Text = SetUpForm.player1Model.Wins.ToString();
            totalWinsP2TextBox.Text = SetUpForm.player2Model.Wins.ToString();


        }

        private void ClickedOnBoard(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
            {
                return;
            }

            if (player1Turn)
            {
                p.Image = player1PictureBox.Image;
                PlayerTurnFunction();
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
            Array.Clear(player1StartGameScore, 0, player1StartGameScore.Length);
            Array.Clear(player2StartGameScore, 0, player2StartGameScore.Length);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            foreach (PlayerModel p in dudeFigureThisOut)
            {
                // TODO - Add a UpdatePlayer Method instead of creating a new player!
                if (p.DisplayName == updatePlayer1.DisplayName)
                {
                    //TODO - if Player 1 wins --  p.Wins++, p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.Wins ++;
                    p.GamesPlayed++;
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.WinLoseRatio = p.Wins / p.GamesPlayed;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }
                if (p.DisplayName == updatePlayer2.DisplayName)
                {
                    //TODO - if Player 2 wins --  p.Wins++, p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.Wins ++;
                    p.GamesPlayed ++;
                    p.WinLoseRatio = p.Wins / p.GamesPlayed;
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }
                
                
            }
            this.Close();


        }

        private void FigureOutAWinWithSwitchs()
        {
            for (int winner = 0; winner <= 7; winner++)
            {
                switch (winner)
                {
                    case 0:

                        int p1X123 = player1StartGameScore[0, 0] + player1StartGameScore[0, 1] + player1StartGameScore[0, 2];
                        int p2X123 = player2StartGameScore[0, 0] + player2StartGameScore[0, 1] + player2StartGameScore[0, 2];
                        
                        WinMessageBox(p1X123, p2X123);
                        
                        break;

                    case 1:

                        int p1X456 = player1StartGameScore[1, 0] + player1StartGameScore[1, 1] + player1StartGameScore[1, 2];
                        int p2X456 = player2StartGameScore[1, 0] + player2StartGameScore[1, 1] + player2StartGameScore[1, 2];
                        
                        WinMessageBox(p1X456, p2X456);
                        
                        break;
                    case 2:

                        int p1X789 = player1StartGameScore[2, 0] + player1StartGameScore[2, 1] + player1StartGameScore[2, 2];
                        int p2X789 = player2StartGameScore[2, 0] + player2StartGameScore[2, 1] + player2StartGameScore[2, 2];
                        
                        WinMessageBox(p1X789, p2X789);
                        
                        break;
                    case 3:                        

                        int p1X741 = player1StartGameScore[0, 0] + player1StartGameScore[1, 0] + player1StartGameScore[2, 0];
                        int p2X741 = player2StartGameScore[0, 0] + player2StartGameScore[1, 0] + player2StartGameScore[2, 0];
                        
                        WinMessageBox(p1X741, p2X741);
                        
                        break;
                    case 4:

                        int p1X852 = player1StartGameScore[0, 1] + player1StartGameScore[1, 1] + player1StartGameScore[2, 1];
                        int p2X852 = player2StartGameScore[0, 1] + player2StartGameScore[1, 1] + player2StartGameScore[2, 1];
                        
                        WinMessageBox(p1X852, p2X852);
                        
                        break;
                    case 5:
                        int p1X963 = player1StartGameScore[0, 2] + player1StartGameScore[1, 2] + player1StartGameScore[2, 2];
                        int p2X963 = player2StartGameScore[0, 2] + player2StartGameScore[1, 2] + player2StartGameScore[2, 2];                        
                        WinMessageBox(p1X963, p2X963);                       
                        break;

                    case 6:
                        int p1X753 = player1StartGameScore[0, 0] + player1StartGameScore[1, 1] + player1StartGameScore[2, 2];
                        int p2X753 = player2StartGameScore[0, 0] + player2StartGameScore[1, 1] + player2StartGameScore[2, 2];
                        WinMessageBox(p1X753, p2X753);
                        break;

                    case 7:

                        int p1X951 = player1StartGameScore[0, 2] + player1StartGameScore[1, 1] + player1StartGameScore[2, 0];
                        int p2X951 = player2StartGameScore[0, 2] + player2StartGameScore[1, 1] + player2StartGameScore[2, 0];
                        WinMessageBox(p1X951, p2X951);
                        break;

                }
            }
        }
        private void WinMessageBox(int xP1, int xP2)
        {
            if (xP1 == 3 || xP2 == 3)
            {
                if (xP1 == 3)
                {
                    MessageBox.Show($"{player1Label.Text} Wins!");
                }
                else
                {
                    MessageBox.Show($"{player2Label.Text} Wins!");
                } 
            }
        }

        private void DotProductForTheWin()
        {
            UpdateScoreBoard();
            int i = 0;
            int j = 0;
            // if this (1 x 8) matrixs cycels its 0's to 1's and we do the dot product on WinMatrix if the output ever equals 3 win?????????
            int[] IdentityMatrix = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[,] WinMatrix = { {1, 2, 3 },{ 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2,5,8 }, {3,6,9}, { 3,5,7 }, { 1,5,9 } };
            for (i = 0;  i < IdentityMatrix.Length; i++)
            {
                Array.Clear(IdentityMatrix,0,IdentityMatrix.Length);
                IdentityMatrix[i] = 1;
                int[] win = { 0, 0, 0 };
                win[0] = IdentityMatrix[i] * WinMatrix[j, i];
                j = 1;
                win[1] = IdentityMatrix[i] * WinMatrix[j, i];
                j=2;
                win[2] = IdentityMatrix[i] * WinMatrix[j, i];
                Array.IndexOf(WinMatrix, i);
                j = 0;
                if (win[i] == Array.IndexOf(WinMatrix,i))
                {
                    //AHHHHH RAWRRRRRR!
                }
                // TODO - Come back to this...
            }
            player1StartGameScore[i, j] = 0;
            player2StartGameScore[i, j] = 0;
        }
    }
}
