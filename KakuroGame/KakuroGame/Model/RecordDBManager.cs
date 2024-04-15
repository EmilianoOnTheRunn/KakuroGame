using System;
using SQLite;

namespace KakuroGame.Model
{
	public class RecordDBManager
	{
		public RecordDBManager()
		{
		}

        public static bool SaveRecord(Record record)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Record>();
                int rowsAffected = con.Insert(record);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public static bool Add(Clock time)
        {
            Game game = Game.GetInstance();
            var kakuro = game.kakuro;

            var user = SessionManager.GetSession();

            Record record = new Record(time, kakuro, user);
            return SaveRecord(record);
        }

    }
}

