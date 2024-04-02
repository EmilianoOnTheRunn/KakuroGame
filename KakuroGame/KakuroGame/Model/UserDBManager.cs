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
                    /*if (row > 0)
                    {
                        DisplayAlert("Success", "Data updated", "Ok");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Failed", "Check again", "Ok");
                    }
                    
                }
                else
                {
                    DisplayAlert("Failed", "Invalid username", "Ok");
                    */
                }
            }
        }

        public static void RequestDeleteUser(string user)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                User userToDelete = con.Table<User>().FirstOrDefault(u => u.Username == user);
                //lblPassword.Text = user.Password;
                con.CreateTable<User>();
                int row = con.Delete(userToDelete);
                con.Close();
                /*if (row > 0)
                {
                    DisplayAlert("Success", "User deleted", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Failed", "Check again", "Ok");
                }*/
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

