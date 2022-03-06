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
        private int countScoreBest2of3_P1 = 0;
        private int countScoreBest2of3_P2 = 0;
        private PlayerModel updatePlayer1 = SetUpForm.player1Model;
        private PlayerModel updatePlayer2 = SetUpForm.player2Model;
        private List<PlayerModel> dudeFigureThisOut = GlobalConfig.Connection.GetAllPlayers();
        private bool player1Turn = true;
        private bool player2Turn = false;
        private readonly SkillsModel player1Skills = new SkillsModel();
        private readonly SkillsModel player2Skills = new SkillsModel();
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
            if (overRideP1Button.BackColor == Color.LightGreen && p.Image == null)
            {
                return;
            }
            if (overRideP2Button.BackColor == Color.LightGreen && p.Image == null)
            {
                return;
            }

            if (player1Turn)
            {
                p.Image = player1PictureBox.Image;
                PlayerTurnFunction();
                UpdateScoreBoard();
                //FigureOutAWinWithSwitchs();
                DotProductForTheWin();
                return;
            }

            if (player2Turn)
            {
                p.Image = player2PictureBox.Image;
                PlayerTurnFunction();
                UpdateScoreBoard();
                //FigureOutAWinWithSwitchs();
                DotProductForTheWin();
                return;
            }
        }

        private void DoubleClickedOnBoard_DoubleClick(object sender, EventArgs e)
        {

            PictureBox p = sender as PictureBox;
            if (p == null)
            {
                return;

            }
            if (overRideP2Button.BackColor != Color.LightGreen && p.Image != player2PictureBox.Image)
            {
                return;
            }
            if (overRideP1Button.BackColor != Color.LightGreen && p.Image != player1PictureBox.Image)
            {
                return;
            }


            if (overRideP2Button.BackColor == Color.LightGreen && p.Image != player2PictureBox.Image)
            {
                OverRide(p);
                DotProductForTheWin();


                return;
            }
            if (overRideP1Button.BackColor == Color.LightGreen && p.Image != player1PictureBox.Image)
            {
                OverRide(p);
                DotProductForTheWin();
                return;
            }
            return;
        }



        #region Useful Methods 
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

                if (boxes[i, j].Image == player1PictureBox.Image)
                {
                    player1StartGameScore[i, j] = 1;

                }
                if (boxes[i, j].Image == player2PictureBox.Image)
                {
                    player2StartGameScore[i, j] = 1;

                }
                if (i == 2)
                {
                    j++;
                    i = -1;
                    if (j == 3)
                    {
                        return;
                    }
                }

            }
        }
        private void KeyboardDanceVector()
        {
            VectorKeyboardForm keyboard = new VectorKeyboardForm();
            if (player2Skills.ClearBoard == true)
            {
                MessageBox.Show($"{player2Label.Text} you already used this Skill!");
                return;
            }
            else
            {
                ClearBoard();
                keyboard.ShowDialog();
                player2Skills.ClearBoard = true;
            }
        }

        private void FlameThrowerGru()
        {

            FlameThrowerGru fire = new FlameThrowerGru();
            if (player1Skills.ClearBoard == true)
            {
                MessageBox.Show($"{player2Label.Text} you already used this Skill!");
                return;
            }
            else
            {
                ClearBoard();
                fire.ShowDialog();
                player1Skills.ClearBoard = true;
            }

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


        /// <summary>
        /// This is the Message Box popup if a win case is hit while using WinMessageBoxForDotProductWin.
        /// </summary>
        private void WinMessageBoxForDotProductWin()
        {
            if (!player1Turn)
            {
                countScoreBest2of3_P1++;
                if (countScoreBest2of3_P1 == 2)
                {
                    MessageBox.Show($"{player1Label.Text} Wins!");
                    UpdateThePlayerModelData(updatePlayer1);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show($"{player1Label.Text} Wins that round! \n\n{player1Label.Text}'s Score: {countScoreBest2of3_P1} vs {player2Label.Text}'s Score: {countScoreBest2of3_P2}");
                    ClearBoard();

                    return;
                }
            }
            else
            {
                countScoreBest2of3_P2++;
                if (countScoreBest2of3_P2 == 2)
                {
                    MessageBox.Show($"{player2Label.Text} Wins!");
                    UpdateThePlayerModelData(updatePlayer2);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show($"{player2Label.Text} Wins that round! \n\n{player1Label.Text}'s Score {countScoreBest2of3_P1} vs {player2Label.Text}'s Score:{countScoreBest2of3_P2}");
                    ClearBoard();

                    return;
                }
            }

        }


        /// <summary>
        /// Work in progress to a soluiton that would solve any size matrix. That Currently works for a 3x3.
        /// </summary>
        private void DotProductForTheWin()
        {
            UpdateScoreBoard();
            // if this (1 x 3) matrixs cycels its 0's to 1's and we do the dot product on WinMatrix if the output ever equals 3 win?????????
            int[] IdentityMatrix = { 1, 1, 1 };
            int[,] playerGameScore = new int[3, 3];
            if (!player1Turn)
            {
                playerGameScore = player1StartGameScore;
            }
            else
            {
                playerGameScore = player2StartGameScore;
            }
            for (int i = 0; i < IdentityMatrix.Length; i++)
            {
                int[] winHor = { 0, 0, 0 };
                int[] winVert = { 0, 0, 0 };
                int[] winDiagLeft = { 0, 0, 0 };
                int[] winDiagRight = { 0, 0, 0 };

                // Clean this up with one more for loop for the j's

                //winDiagRight[0] = IdentityMatrix[i] * playerGameScore[0, 2];
                //winDiagRight[1] = IdentityMatrix[i] * playerGameScore[1, 1];
                //winDiagRight[2] = IdentityMatrix[i] * playerGameScore[2, 0];

                int x = 0;
                int y = IdentityMatrix.Length - 1;
                for (int j = 0; j < IdentityMatrix.Length; j++)
                {
                    winDiagLeft[j] = IdentityMatrix[i] * playerGameScore[j, j];
                    winDiagRight[j] = IdentityMatrix[i] * playerGameScore[x++, y--];
                    winHor[j] = IdentityMatrix[i] * playerGameScore[i, j];
                    winVert[j] = IdentityMatrix[i] * playerGameScore[j, i];
                }

                int horizontalWin = winHor[0] + winHor[1] + winHor[2];
                int verticalWin = winVert[0] + winVert[1] + winVert[2];
                int diagonalWinLeft = winDiagLeft[0] + winDiagLeft[1] + winDiagLeft[2];
                int diagonalWinRight = winDiagRight[0] + winDiagRight[1] + winDiagRight[2];

                if (diagonalWinRight == 3 || diagonalWinLeft == 3 || horizontalWin == 3 || verticalWin == 3)
                {
                    WinMessageBoxForDotProductWin();
                    return;
                }
            }
        }


        /// <summary>
        /// Updates the player model the better way!
        /// </summary>
        private void UpdateThePlayerModelData(PlayerModel p)
        {
            p.Wins++;
            p.GamesPlayed++;
            p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
            p.WinLoseRatio = p.Wins / p.GamesPlayed;
            GlobalConfig.Connection.UpdatePlayer(p);
        }

        private void OverRide(PictureBox p)
        {
            if (player1Skills.OverRide && player1Turn)
            {
                MessageBox.Show($"{player1Label.Text} you already used this skill");
                return;
            }
            if (player2Skills.OverRide && player2Turn)
            {
                MessageBox.Show($"{player2Label.Text} you already used this skill");
                return;
            }
            if (player1Turn && !player1Skills.OverRide)
            {
                p.Image = player1PictureBox.Image;
                player1Skills.OverRide = true;
                PlayerTurnFunction();
                overRideP1Button.BackColor = Color.LightPink;
            }
            else
            {
                p.Image = player2PictureBox.Image;
                player2Skills.OverRide = true;
                PlayerTurnFunction();
                overRideP2Button.BackColor = Color.LightPink;
            }
            return;
        }

        #endregion



        #region Buttons 
        private void newGameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearBoardP1Button_Click(object sender, EventArgs e)
        {
            if (player1Turn)
            {
                FlameThrowerGru();
                clearBoardP1Button.BackColor = Color.LightPink;
            }
            return;
        }

        private void backToBackP1Button_Click(object sender, EventArgs e)
        {
            if (player2Turn)
            {
                PlayerTurnFunction();
                backToBackP1Button.BackColor = Color.LightPink;
            }
            return;
        }

        private void overRideP1Button_Click(object sender, EventArgs e)
        {
            if (player1Turn && !(overRideP1Button.BackColor == Color.LightGreen))
            {
                MessageBox.Show($"Double Click the box you wish to chage.");
                overRideP1Button.BackColor = Color.LightGreen;
            }
            return;
        }

        private void backToBackP2Button_Click(object sender, EventArgs e)
        {
            if (player1Turn)
            {
                PlayerTurnFunction();
                backToBackP2Button.BackColor = Color.LightPink;
            }
            return;
        }
        private void clearBoardP2Button_Click(object sender, EventArgs e)
        {
            if (player2Turn)
            {
                KeyboardDanceVector();
                ClearBoard();
                clearBoardP2Button.BackColor = Color.LightPink;
            }
            return;

        }
        private void overRideP2Button_Click(object sender, EventArgs e)
        {
            if (player2Turn && !(overRideP2Button.BackColor == Color.LightGreen))
            {
                MessageBox.Show($"Double Click the box you wish to chage.");
                overRideP2Button.BackColor = Color.LightGreen;
            }
            return;
        }
        #endregion




        #region Not Actually using these methods anymore but I don't want to delete them yet.
        private void UpdateThePlayerModelDataOld()
        {
            foreach (PlayerModel p in dudeFigureThisOut)
            {
                // TODO - Add a UpdatePlayer Method instead of creating a new player!
                if (p.DisplayName == updatePlayer1.DisplayName)
                {
                    //TODO - if Player 1 wins --  p.Wins++, p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.Wins++;
                    p.GamesPlayed++;
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.WinLoseRatio = p.Wins / p.GamesPlayed;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }
                if (p.DisplayName == updatePlayer2.DisplayName)
                {
                    //TODO - if Player 2 wins --  p.Wins++, p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    p.Wins++;
                    p.GamesPlayed++;
                    p.WinLoseRatio = p.Wins / p.GamesPlayed;
                    p.AmountOfMoneyWon += amountBettingNumericUpDown.Value;
                    GlobalConfig.Connection.UpdatePlayer(p);
                }

            }
        }


        /// <summary>
        /// Every Win case Hard Coded!
        /// </summary>
        private void FigureOutAWinWithSwitchs()
        {
            for (int winner = 0; winner <= 7; winner++)
            {
                switch (winner)
                {
                    case 0:

                        int p1X123 = player1StartGameScore[0, 0] + player1StartGameScore[0, 1] + player1StartGameScore[0, 2];
                        int p2X123 = player2StartGameScore[0, 0] + player2StartGameScore[0, 1] + player2StartGameScore[0, 2];

                        WinMessageBoxForSwitchWin(p1X123, p2X123);

                        break;

                    case 1:

                        int p1X456 = player1StartGameScore[1, 0] + player1StartGameScore[1, 1] + player1StartGameScore[1, 2];
                        int p2X456 = player2StartGameScore[1, 0] + player2StartGameScore[1, 1] + player2StartGameScore[1, 2];

                        WinMessageBoxForSwitchWin(p1X456, p2X456);

                        break;
                    case 2:

                        int p1X789 = player1StartGameScore[2, 0] + player1StartGameScore[2, 1] + player1StartGameScore[2, 2];
                        int p2X789 = player2StartGameScore[2, 0] + player2StartGameScore[2, 1] + player2StartGameScore[2, 2];

                        WinMessageBoxForSwitchWin(p1X789, p2X789);

                        break;
                    case 3:

                        int p1X741 = player1StartGameScore[0, 0] + player1StartGameScore[1, 0] + player1StartGameScore[2, 0];
                        int p2X741 = player2StartGameScore[0, 0] + player2StartGameScore[1, 0] + player2StartGameScore[2, 0];

                        WinMessageBoxForSwitchWin(p1X741, p2X741);

                        break;
                    case 4:

                        int p1X852 = player1StartGameScore[0, 1] + player1StartGameScore[1, 1] + player1StartGameScore[2, 1];
                        int p2X852 = player2StartGameScore[0, 1] + player2StartGameScore[1, 1] + player2StartGameScore[2, 1];

                        WinMessageBoxForSwitchWin(p1X852, p2X852);

                        break;
                    case 5:
                        int p1X963 = player1StartGameScore[0, 2] + player1StartGameScore[1, 2] + player1StartGameScore[2, 2];
                        int p2X963 = player2StartGameScore[0, 2] + player2StartGameScore[1, 2] + player2StartGameScore[2, 2];
                        WinMessageBoxForSwitchWin(p1X963, p2X963);
                        break;

                    case 6:
                        int p1X753 = player1StartGameScore[0, 0] + player1StartGameScore[1, 1] + player1StartGameScore[2, 2];
                        int p2X753 = player2StartGameScore[0, 0] + player2StartGameScore[1, 1] + player2StartGameScore[2, 2];
                        WinMessageBoxForSwitchWin(p1X753, p2X753);
                        break;

                    case 7:

                        int p1X951 = player1StartGameScore[0, 2] + player1StartGameScore[1, 1] + player1StartGameScore[2, 0];
                        int p2X951 = player2StartGameScore[0, 2] + player2StartGameScore[1, 1] + player2StartGameScore[2, 0];
                        WinMessageBoxForSwitchWin(p1X951, p2X951);
                        break;

                }
            }
        }


        /// <summary>
        /// This is the Message Box popup if a win case is hit while using FigureOutAWinWithSwitches.
        /// </summary>
        /// <param name="xP1">This is the variable Player1s score is stored</param>
        /// <param name="xP2">This is the variable Player2s score is stored</param>
        private void WinMessageBoxForSwitchWin(int xP1, int xP2)
        {
            if (xP1 == 3 || xP2 == 3)
            {
                if (xP1 == 3)
                {
                    MessageBox.Show($"{player1Label.Text} Wins!");
                    return;
                }
                else
                {
                    MessageBox.Show($"{player2Label.Text} Wins!");
                    return;
                }
            }
        }



        #endregion


    }
}
