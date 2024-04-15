using System;
using KakuroGame.Enums;
namespace KakuroGame.Model
{
	public class Kakuro
	{
		public int Rows { get { return Board.GetLength(0); } }
		public int Columns { get { return Board.GetLength(1); } }

        public Cell[,] Board { get; set; }
        public EDifficulty Difficulty { get; set; }

        public Kakuro(EDifficulty difficulty)
        {
            Difficulty = difficulty;
            Board = new Cell[((int)difficulty), ((int)difficulty)];

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {

                    Board[i, j] = new Cell();

                }
            }
        }

        public void UpdateCell(int value, (int, int) position)
        {
            Board[position.Item1, position.Item2].value = value;
        }


        public EDifficulty getSize() {

            return Difficulty; 
        }

         
		
	}
}

