using System;
using KakuroGame.Enums;
namespace KakuroGame.Model
{
	public class Cell
	{
        public ECellType type { get; set; }
        public int value { get; set; }
        public int HorizontalTargetValue { get; set; }
        public int VerticalTargetValue { get; set; }

        public Cell()
        {
            type = ECellType.Blank;
        }
    }
}

