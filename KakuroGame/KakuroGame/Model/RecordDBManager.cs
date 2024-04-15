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




    }
}

