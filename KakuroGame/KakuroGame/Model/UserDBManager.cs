using System;
using SQLite;
using Xamarin.Forms;

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
                User user = con.Table<User>().FirstOrDefault(u => u.Username == username);


				if (User.VerifyPassword(password, user.Password))
					return user;
            }


			return null;
		}

		public static void ChangeUserPassword(string user, string newPassword)
		{
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {

                User user1 = con.Table<User>().FirstOrDefault(u => u.Username == user);
                if (user1 != null)
                {
                    string hashedPassword = User.HashPassword(newPassword);

                    user1.Password = hashedPassword;
                    int row = con.Update(user1);
                    con.Close();
                }
            }
        }

        public static void ChangeUserPassword(string newPassword)
        {
            var username = SessionManager.GetSession();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {

                User user1 = con.Table<User>().FirstOrDefault(u => u.Username == username);
                if (user1 != null)
                {
                    string hashedPassword = User.HashPassword(newPassword);

                    user1.Password = hashedPassword;
                    int row = con.Update(user1);
                    con.Close();
                }
            }
        }

        public static void RequestDeleteUser()
        {
            var username = SessionManager.GetSession();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                User userToDelete = con.Table<User>().FirstOrDefault(u => u.Username == username);
                con.CreateTable<User>();
                int row = con.Delete(userToDelete);
                con.Close();
            }
        }

        public static bool SaveUser(User user)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<User>();
                int rowsAffected = con.Insert(user);
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

        public static bool AvailableUsername(string username)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                User user = con.Table<User>().FirstOrDefault(u => u.Username == username);

                if (user != null)
                    return true;
            }

            return false;
        }
	}
}

