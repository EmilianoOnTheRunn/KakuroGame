using System;
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

        public void GenerateKakuro(EDifficulty difficulty)
        {
            kakuro = KakuroFetcher.FetchKakuro(difficulty);
        }

        public bool CheckCell(int value, (int, int) position)
        {
            kakuro.UpdateCell(value, position);

            var flag = ValidateKakuro();
            Console.WriteLine(flag);
            return flag;
        }

        private bool ValidateKakuro()
        {
            var board = kakuro.Board;

            int expectedTotal = -1;
            var startedCount = false;
            int currentSum = 0;

            // Vertical Loop
            for (var i = 1; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    var cell = board[j, i];
                    if (cell.type == ECellType.Blank)
                        continue;

                    if (cell.type == ECellType.Start)
                    {
                        if (startedCount)
                        {
                            if (currentSum != expectedTotal)
                                return false;

                            currentSum = 0;
                        }

                        expectedTotal = cell.VerticalTargetValue;
                        startedCount = true;
                        continue;
                    }

                    if (cell.type == ECellType.Value)
                    {
                        currentSum += cell.value;
                        continue;
                    }
                }
            }

            expectedTotal = -1;
            startedCount = false;
            currentSum = 0;

            // Horizontal loop
            for (var i = 1; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    var cell = board[i, j];
                    if (cell.type == ECellType.Blank)
                        continue;

                    if (cell.type == ECellType.Start)
                    {
                        if (startedCount)
                        {
                            if (currentSum != expectedTotal)
                                return false;

                            currentSum = 0;
                        }

                        expectedTotal = cell.HorizontalTargetValue;
                        startedCount = true;
                        continue;
                    }

                    if (cell.type == ECellType.Value)
                    {
                        currentSum += cell.value;
                    }
                }
            }

            return true;
        }
    }
}

