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
                string username = userNameEntry.Text;
                string password = passwordEntry.Text;
                string confirmPassword = confirmPasswordEntry.Text;
                bool isUsernameEmpty = string.IsNullOrEmpty(username);
                bool isPassEmpty = string.IsNullOrEmpty(password);

                if (!isUsernameEmpty && !isPassEmpty && password == confirmPassword)
                {

                    try
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {

                            User user1 = con.Table<User>().FirstOrDefault(u => u.Username == username);
                            if (user1 != null)
                            {
                                string hashedPassword = User.HashPassword(password);

                                user1.Password = hashedPassword;
                                int row = con.Update(user1);
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
                                DisplayAlert("Failed", "Invalid username", "Ok");
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
                    DisplayAlert("Validation Error", "Please ensure all fields are filled and passwords match", "Ok");
                }

            }

        }
    }
}

