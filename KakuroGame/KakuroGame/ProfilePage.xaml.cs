
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

        void btnDelete_Clicked(System.Object sender, System.EventArgs e)
        {
            
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                User user = con.Table<User>().FirstOrDefault(u => u.Username == username);
                //lblPassword.Text = user.Password;
                con.CreateTable<User>();
                int row = con.Delete(user);
                con.Close();
                if (row > 0)
                {
                    DisplayAlert("Success", "User deleted", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Failed", "Check again", "Ok");
                }
            }

        }

        void btnSignOut_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}

