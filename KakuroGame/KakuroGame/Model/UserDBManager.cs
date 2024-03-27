using System;
using SQLite;

namespace KakuroGame.Model
{
	public class UserDBManager
	{
		public UserDBManager()
		{
		}

		public static User RequestUser(string username, string password)
		{
			using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
			{
                User user = con.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);

				if (user != null)
					return user;
            }


			return null;
		}

		public static void ChangeUserPassword(User user, string newPassword)
		{

		}
	}
}

