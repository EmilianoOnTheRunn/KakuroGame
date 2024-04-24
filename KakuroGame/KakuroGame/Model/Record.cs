using System;
using KakuroGame.Enums;
using SQLite;

namespace KakuroGame.Model
{
	public class Record
	{
        [PrimaryKey, AutoIncrement]
        public int RecordId { get; set; }

        public DateTime Clock { get; set; }
        public EDifficulty Difficulty { get; set; }
        [MaxLength(10)]
        public string Username { get; set; }

        public Record()
        {

        }

        public Record(DateTime clock, EDifficulty kakuro, string username)
        {
            Clock = clock;
            Difficulty = kakuro;
            Username = username; 
        }

        public string GetTime => $"{Clock.Hour}h:{Clock.Minute}m:{Clock.Second}s";

        public string GetLevel  => Difficulty.ToString();


    }
}

