using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;

        private char[,] _board;

        /// <summary>
        /// Initializes player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;

            _board = new char[3, 3] { { '1', '2', '3' },{ '4', '5', '6' },{ '7', '8', '9' } };

        }

        /// <summary>
        /// Gets the input from the player
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            if (Game.GetInput() == 1)
            {
                _board[0, 0] = _currentToken;
            }

            if (_currentToken == _player1Token)
            {
                _currentToken = _player2Token;
            }
            else
            {
                _currentToken = _player1Token;
            }
        }

        /// <summary>
        /// Draws the board and let's the player know whose turn it is
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[0,0], _board[0,1], _board[0,2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[1,0], _board[1,1], _board[1,2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[2,0], _board[2,1], _board[2,2]);

            Console.WriteLine("     |     |      ");
        }

        public void End()
        {
            Console.WriteLine("Goodbye, Player.");
        }

        /// <summary>
        /// Assigns the spot at given indices in the board array to be given token
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x positon of the token.</param>
        /// <param name="posY">The y positon of the token.</param>
        /// <returns>Return false if the indices are out of range.</returns>
        public bool SetToken(char token, int posX, int posY)
        {
            int tag = Game.GetInput();

            if (tag > -1)
            {
                posX = tag / 3;
                posY = tag % 3;

                _board[posX, posY] = token;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the token appears three times consecutively horizontally, vertically, or diagonally.
        /// </summary>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {
            #region Horizontal Winning Condtion
            // Winning Condition For First Column
            if (_board[0, 0] == _board[0, 1] && _board[0, 1] == _board[0, 2])
            {
                return true;
            }

            // Winning Condition For Second Column
            else if (_board[1, 0] == _board[1, 1] && _board[1, 1] == _board[1, 2])
            {
                return true;
            }

            // Winning Condition For Third Column
            else if (_board[2,0] == _board[2,1] && _board[2,1] == _board[2,2])
            {
                return true;
            }
            #endregion

            #region Vertically Winning Condition
            // Winning Condition For First Row
            else if (_board[0,0] == _board[1,0] && _board[1,0] == _board[2,0])
            {
                return true;
            }
            // Winning Condition For Second Row
            else if (_board[0,1] == _board[1,1] && _board[1,1] == _board[2,1])
            {
                return true;
            }

            // Winning Condition For Third Row
            else if (_board[0,2] == _board[1,2] && _board[1,2] == _board[2,2])
            {
                return true;
            }
            #endregion

            #region Diagonal Winning Condition
            // Winning Condition For First Diagonal (\)
            else if (_board[0,0] == _board[1,1] && _board[1,1] == _board[2,2])
            {
                return true;
            }
            // Winning Condition For Second Diagonal (/)
            else if (_board[0,2] == _board[1,1] && _board[1,1] == _board[2,2])
            {
                return true;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (_board[0,0] != '1' && _board[0,1] != '2' && _board[0,2] != '3' && _board[1,0] != '4' && _board[1,1] != '5' && _board[0,1] != '6'&& _board[2,0] != '7' && _board[2,1] != '8' && _board[0,2] != '9')
            {
                return true;
            }
            #endregion

            return false;
        }
        
        /// <summary>
        /// Resets the board to it's default state.
        /// </summary>
        public void ClearBoard()
        {
            Console.Clear();
            Draw();
        }
    }
}
