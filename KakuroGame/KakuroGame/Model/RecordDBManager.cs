using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KakuroGame.Enums;
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


        public static bool Add(DateTime time)
        {
            Game game = Game.GetInstance();
            var kakuro = game.kakuro;

            var user = SessionManager.GetSession();

            Record record = new Record(time, kakuro.Difficulty, user);
            return SaveRecord(record);
        }

        public async static Task<List<Record>> GetRecords(string username)
        {
            using (SQLiteConnection con = new SQLiteConnection("hello"))
            {
                //con.CreateTable<Record>();
                var records = con.Table<Record>().ToList();
                return records.Where(s => s.Username == username.ToString()).ToList();
;
            }
        }

    }
}

