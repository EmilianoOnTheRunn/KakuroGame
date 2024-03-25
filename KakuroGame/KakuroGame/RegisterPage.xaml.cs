using System;
using System.Collections.Generic;
using KakuroGame.Model;
using SQLite;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class RegisterPage : ContentPage
	{	
		public RegisterPage ()
		{
			InitializeComponent ();
		}


        void signIn_Clicked(System.Object sender, System.EventArgs e)
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
                    string hashedPassword = User.HashPassword(password);

                    User user = new User()
                    {
                        Username = username,
                        Password = hashedPassword
                    };

                    using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
                    {
                        con.CreateTable<User>();
                        int rowsAffected = con.Insert(user);
                        if (rowsAffected > 0)
                        {
                            DisplayAlert("Success", "User successfully registered", "Ok");
                            Navigation.PopAsync();
                        }
                        else
                        {
                            DisplayAlert("Failed", "Failed to register user", "Ok");
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

