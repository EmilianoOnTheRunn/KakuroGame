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
            try { 
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
            } catch
            {
                return false;
            }
        }


        public static bool Add(DateTime time)
        {
            Game game = Game.GetInstance();
            var difficulty = game.GetKakuroDifficulty();

            var user = SessionManager.GetSession();

            Record record = new Record(time, difficulty, user);
            return SaveRecord(record);
        }

        public async static Task<List<Record>> GetRecords(string username)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Record>();
                var records = con.Table<Record>().ToList();
                return records.Where(s => s.Username == username.ToString()).ToList();
            }
        }

        public static void DeleteUserRecord(string username)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Record>();
                var records = con.Table<Record>().ToList();
                foreach (var record in records.Where(s => s.Username == username.ToString()).ToList())
                {
                    con.Delete(record);
                }
            }
        }
    }
}

