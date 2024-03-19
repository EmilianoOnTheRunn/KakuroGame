using System;
using System.Collections.Generic;
using KakuroGame.Model;
using SQLite;
using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

        void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(userNameEntry.Text);
            bool isPassEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            string username = userNameEntry.Text;
            string password = passwordEntry.Text;

            if (!isUsernameEmpty || !isPassEmpty)
            {

                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
                    {

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
                catch (Exception ex) {

                    DisplayAlert("Error", $"System error: {ex.Message}", "Ok");
                }
            }
            else
            {
                DisplayAlert("Validation Error", "Please enter username and password", "Ok");
            }
        }

        void btnForgotPassword_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PasswordPage());
        }

        void btnSignIn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}

