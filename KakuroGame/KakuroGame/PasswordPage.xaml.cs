using System;
using System.Collections.Generic;
using SQLite;
using KakuroGame.Model;
using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class PasswordPage : ContentPage
	{	
		public PasswordPage ()
		{
			InitializeComponent ();
		}

        void btnReset_Clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                bool isUsernameEmpty = string.IsNullOrEmpty(userNameEntry.Text);
                bool isPassEmpty = string.IsNullOrEmpty(passwordEntry.Text);
                string username = userNameEntry.Text;
                string password = passwordEntry.Text;

                if (!isUsernameEmpty || !isPassEmpty)
                {

                    try
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {

                            User user1 = con.Table<User>().FirstOrDefault(u => u.Username == username);
                            if (user1 != null)
                            {
                                con.CreateTable<User>();
                                int row = con.Update(password);
                                con.Close();
                                if (row > 0)
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
                                DisplayAlert("Login Failed", "Invalid username or password", "Ok");
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        DisplayAlert("Error", $"System error: {ex.Message}", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Validation Error", "Please enter username and password", "Ok");
                }
                User user = con.Table<User>().FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    if (User.VerifyPassword(password, user.Password))
                    {
                        DisplayAlert("Success", "User successfully logged in", "Ok");
                        Navigation.PushAsync(new HomePage());
                    }

                }
                else
                {
                    DisplayAlert("Login Failed", "Invalid username or password", "Ok");
                }


            }

        }
    }
}

