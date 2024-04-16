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

        public void GenerateKakuro(EDifficulty difficulty)
        {
            kakuro = KakuroFetcher.FetchKakuro(difficulty);
        }

        public bool CheckCell(int value, (int, int) position)
        {
            kakuro.UpdateCell(value, position);

            return ValidateKakuro();
        }

        private bool ValidateKakuro()
        {
            var board = kakuro.Board;

            int expectedTotalForX = -1;
            var startedCountForX = false;
            int currentXSum = 0;
            var numberTrackX = new HashSet<int>();

            int expectedTotalForY = -1;
            var startedCountForY = false;
            int currentYSum = 0;
            var numberTrackY = new HashSet<int>();

            // Board[x,y] where x is the row and y is the column
            for (var i = 1; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    // Check if the sum of the columns is accurate
                    var cellForVertical = board[j, i];
                    if (cellForVertical.type != ECellType.Blank)
                    {

                        if (cellForVertical.type == ECellType.Start)
                        {
                            if (startedCountForX)
                            {
                                if (currentXSum != expectedTotalForX)
                                    return false;

                                currentXSum = 0;
                                numberTrackX = new HashSet<int>();
                            }

                            expectedTotalForX = cellForVertical.VerticalTargetValue;
                            startedCountForX = true;
                        }
                        else
                        {
                            var value = cellForVertical.value;
                            currentXSum += value;

                            if (numberTrackX.Contains(value))
                                return false;

                            numberTrackX.Add(value);
                        }
                    }

                    // Check if the sum of the rows is accurate
                    var cellForHorizontal = board[i, j];

                    if (cellForHorizontal.type != ECellType.Blank)
                    {
                        

                        if (cellForHorizontal.type == ECellType.Start)
                        {
                            if (startedCountForY)
                            {
                                if (currentYSum != expectedTotalForY)
                                    return false;

                                currentYSum = 0;
                                numberTrackY = new HashSet<int>();
                            }

                            expectedTotalForY = cellForHorizontal.HorizontalTargetValue;
                            startedCountForY = true;
                        }
                        else
                        {
                            var value = cellForHorizontal.value;
                            currentYSum += value;

                            if (numberTrackY.Contains(value))
                                return false;

                            numberTrackY.Add(value);
                        }
                    }
                }
                numberTrackX = new HashSet<int>();
                numberTrackY = new HashSet<int>();
            }

            if (startedCountForX && currentXSum != expectedTotalForX)
                return false;
            

            if (startedCountForY && currentYSum != expectedTotalForY)
                return false;

            return true;
        }
    }
}

