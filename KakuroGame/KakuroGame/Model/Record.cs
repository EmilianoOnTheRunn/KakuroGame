using System;
using SQLite;

namespace KakuroGame.Model
{
	public class Record
	{
        [PrimaryKey, AutoIncrement]
        public int RecordId { get; set; }

        public Clock Clock { get; }
        public Kakuro Kakuro { get; }
        [MaxLength(10)]
        public string Username { get; }

        public Record()
        {

        }
        public Record(Clock clock, Kakuro kakuro, string username)
        {
            Clock = clock;
            Kakuro = kakuro;
            Username = username; 
        }

        public string GetTime => $"{Clock.Hours}h:{Clock.Minutes}m:{Clock.Seconds}s";

        public int GetLevel  => (int)Kakuro.getSize();


    }
}

