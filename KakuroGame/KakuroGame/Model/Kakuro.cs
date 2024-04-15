using System;
using KakuroGame.Enums;
namespace KakuroGame.Model
{
	public class Kakuro
	{

		public EDifficulty Size { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
        public Cell[,] Board { get; set; }

        public Kakuro()
        {

            Rows = 0;
            Columns = 0;

        }

        public Kakuro(int rows, int columns) {

			Rows = rows;
			Columns = columns;

        }


        public EDifficulty getSize() {

            return Size; 
        }

         
		
	}
}

