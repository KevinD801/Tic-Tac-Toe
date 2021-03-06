using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        private bool _gameOver;
        private Board _gameBoard;

        /// <summary>
        /// Begins the game
        /// </summary>
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Draw();
                Update();
            }

            End();
        }

        /// <summary>
        /// Called when the game starts
        /// </summary>
        private void Start()
        {
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every time the game loops 
        /// </summary>
        private void Update()
        {
            _gameBoard.Update();
        }

        /// <summary>
        /// Updates the display to reflect and changes made while running
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();
        }

        /// <summary>
        /// Called when the game ends
        /// </summary>
        private void End()
        {
            _gameBoard.End();
        }

        /// <summary>
        /// Taking users choice
        /// </summary>
        /// <returns></returns>
        public static int GetInput()
        {
            int choice = -1;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }
            return choice;
        }

        public static bool SetCurrentScene(int index)
        {
            if (index < 0 || index > _sceneCount)
            {
                return true;
            }
        }
    }
}
