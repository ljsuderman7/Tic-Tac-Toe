/*
 * Program Name: LSudermanAsignment3
 * 
 * Purpose: Runs the tic tac toe game
 * 
 * Revision History:
 *          November 11, 2019: Created
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSudermanAssignment3
{
    /// <summary>
    /// this is the tictactoe form
    /// </summary>
    public partial class TicTacToe : Form
    {
        Tile[,] board = new Tile[3, 3];
        const int NONE = 0;
        const int X = 1;
        const int O = 2;
        const int COLUMNS = 3;
        const int ROWS = 3;
        int turn;
        int numberOfTurns;

        const int LEFT = 50;
        const int TOP = 50;
        const int WIDTH = 100;
        const int HEIGHT = 100;
        const int VERTICLE_GAP = 5;
        const int HORIZONTAL_GAP = 5;

        public TicTacToe()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Checks to see if there is a winner
        /// </summary>
        /// <returns>returns false unless there is a winner</returns>
        private bool winner()
        {
            //left
            if ((board[0, 0].tileType == X && board[0, 1].tileType == X && board[0, 2].tileType == X) ||
                (board[1, 0].tileType == X && board[1, 1].tileType == X && board[1, 2].tileType == X) ||
                (board[2, 0].tileType == X && board[2, 1].tileType == X && board[2, 2].tileType == X) ||
                (board[0, 0].tileType == O && board[0, 1].tileType == O && board[0, 2].tileType == O) ||
                (board[1, 0].tileType == O && board[1, 1].tileType == O && board[1, 2].tileType == O) ||
                (board[2, 0].tileType == O && board[2, 1].tileType == O && board[2, 2].tileType == O))
            {
                return true;
            }
            //down
            if ((board[0, 0].tileType == X && board[1, 0].tileType == X && board[2, 0].tileType == X) ||
                (board[0, 1].tileType == X && board[1, 1].tileType == X && board[2, 1].tileType == X) ||
                (board[0, 2].tileType == X && board[1, 2].tileType == X && board[2, 2].tileType == X) ||
                (board[0, 0].tileType == O && board[1, 0].tileType == O && board[2, 0].tileType == O) ||
                (board[0, 1].tileType == O && board[1, 1].tileType == O && board[2, 1].tileType == O) ||
                (board[0, 2].tileType == O && board[1, 2].tileType == O && board[2, 2].tileType == O))
            {
                return true;
            }
            //diagonal
            if ((board[0, 0].tileType == X && board[1, 1].tileType == X && board[2, 2].tileType == X) ||
                (board[0, 2].tileType == X && board[1, 1].tileType == X && board[2, 0].tileType == X) ||
                (board[0, 0].tileType == O && board[1, 1].tileType == O && board[2, 2].tileType == O) ||
                (board[0, 2].tileType == O && board[1, 1].tileType == O && board[2, 0].tileType == O))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Places either an X or an O, depending on whos turn it is, in the chosen picturebox. If there is a winner it 
        /// displays a message box with the correct message and resets the form, and if the number of turns has reaches 9, 
        /// and there is no winner, then it displays that it is a tie and resets the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            Tile selected = (Tile)sender;
            if (selected.tileType == NONE)
            {
                numberOfTurns++;
                if (turn == 0)
                {
                    selected.Image = Properties.Resources.X;
                    selected.tileType = X;
                    turn = 1;
                }
                else
                {
                    selected.Image = Properties.Resources.O;
                    selected.tileType = O;
                    turn = 0;
                }

                if (winner())
                {
                    if (turn == 0)
                    {
                        MessageBox.Show("O Wins!");
                    }
                    else
                    {
                        MessageBox.Show("X Wins!");
                    }
                    this.Controls.Clear();
                    TicTacToe_Load(sender, e);
                }
                else if(numberOfTurns == 9)
                {
                    MessageBox.Show("Tie.");
                    this.Controls.Clear();
                    TicTacToe_Load(sender, e);
                }
            }
        }

        /// <summary>
        /// creates the tic tac toe board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicTacToe_Load(object sender, EventArgs e)
        {
            turn = 0;
            numberOfTurns = 0;
            int leftPosition = LEFT;
            int topPosition = TOP;

            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    Tile tile = new Tile();

                    tile.left = i;
                    tile.down = j;

                    tile.Height = HEIGHT;
                    tile.Width = WIDTH;
                    tile.Top = topPosition;
                    tile.Left = leftPosition;
                    tile.BorderStyle = BorderStyle.FixedSingle;
                    tile.SizeMode = PictureBoxSizeMode.Zoom;

                    tile.tileType = NONE;

                    tile.Click += pictureBox_Click;
                    this.Controls.Add(tile);

                    leftPosition += WIDTH + HORIZONTAL_GAP;

                    board[i, j] = tile;
                }
                topPosition += HEIGHT + VERTICLE_GAP;
                leftPosition = LEFT;
            }
        }
    }
}
