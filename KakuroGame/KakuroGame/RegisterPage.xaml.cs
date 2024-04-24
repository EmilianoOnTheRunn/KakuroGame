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

                    var result = UserDBManager.SaveUser(user);

                    if (result.success)
                    {
                        DisplayAlert("Success", result.message, "Ok");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Failed", result.message, "Ok");
                    }
                    
                }
                catch
                {
                    DisplayAlert("Error", $"There was an error connecting to the database. Try again later", "Ok");
                }
            }
            else
            {
                DisplayAlert("Validation Error", "Please ensure all fields are filled and passwords match", "Ok");
            }

        }
    }
}

