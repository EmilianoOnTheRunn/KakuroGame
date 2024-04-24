using System;
using System.Collections.Generic;
using KakuroGame.Enums;

namespace KakuroGame.Model
{
	public class Game
	{
        public Kakuro kakuro;

        private static Game instance;

        private Game()
        {

        }

        public static Game GetInstance()
        {
            if (instance == null)
                instance = new Game();

            return instance;
        }

        public void SetUpKakuro(EDifficulty difficulty)
        {
            kakuro = KakuroFetcher.FetchKakuro(difficulty);
        }

        public void CheckCell(int value, (int, int) position)
        {
            kakuro.UpdateCell(value, position);
        }

        public bool ValidateKakuro()
        {
            var board = kakuro.Board;

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    var cell = board[i, j];
                
                    if (cell.value != cell.expectedValue)
                        return false;
                }
            }

            return true;
        }

        public EDifficulty GetKakuroDifficulty()
        {
            return kakuro.Difficulty;
        }
    }
}

