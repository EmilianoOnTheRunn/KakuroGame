using System;
using System.Collections.Generic;
using KakuroGame.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

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
            string username = userNameEntry.Text;
            string password = passwordEntry.Text;
            bool isUsernameEmpty = string.IsNullOrEmpty(username);
            bool isPassEmpty = string.IsNullOrEmpty(password);
            

            if (!isUsernameEmpty && !isPassEmpty)
            {

                try
                {
                    var user = UserDBManager.RequestUser(username, password);
                    if (user != null) { 
                    
                        SessionManager.SaveSesion(user.Username);

                        DisplayAlert("Success", "User successfully logged in", "Ok");
                        userNameEntry.Text = "";
                        passwordEntry.Text = "";
                        Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        DisplayAlert("Login Failed", "Invalid username or password", "Ok");
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

