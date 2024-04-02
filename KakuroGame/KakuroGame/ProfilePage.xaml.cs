
using System;
using System.Collections.Generic;
using SQLite;
using KakuroGame.Model;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace KakuroGame
{	
	public partial class ProfilePage : ContentPage
	{
        string username = SessionManager.GetSession();
        public ProfilePage ()
		{
			InitializeComponent ();
            lblUsernameTitle.Text = username;
            lblUsername.Text = username;
        }

        void btnEdit_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PasswordPage());
        }

        async void btnDelete_Clicked(System.Object sender, System.EventArgs e)
        {

            bool response = await DisplayAlert("Caution!", "Are you sure that you want to delete your account","Yes", "No");
            
            if (response)
            {
                try
                {
                    UserDBManager.RequestDeleteUser(username);
                    await DisplayAlert("Success", "User deleted", "Ok");
                    Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "There's was an error deleting the user: " + ex, "Ok");
                    Navigation.PopAsync();
                }
            }

        }

        void btnSignOut_Clicked(System.Object sender, System.EventArgs e)
        {
            SessionManager.RemoveSession();
            Navigation.PopAsync();
        }
    }
}

