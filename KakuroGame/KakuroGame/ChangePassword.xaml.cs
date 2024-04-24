using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using KakuroGame.Model;

namespace KakuroGame
{	
	public partial class ChangePassword : ContentPage
	{	
		public ChangePassword ()
		{
			InitializeComponent ();
		}

        void btnReset_Clicked(System.Object sender, System.EventArgs e)
        {
            string username = SessionManager.GetSession();
            string password = passwordEntry.Text;
            string confirmPassword = confirmPasswordEntry.Text;
            bool isUsernameEmpty = string.IsNullOrEmpty(username);
            bool isPassEmpty = string.IsNullOrEmpty(password);

            if (!isUsernameEmpty && !isPassEmpty && password == confirmPassword)
            {

                try
                {
                    UserDBManager.ChangeUserPassword(username, password);
                    DisplayAlert("Success", "Data updated", "Ok");
                    Navigation.PopAsync();

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

