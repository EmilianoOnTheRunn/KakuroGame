
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class ProfilePage : ContentPage
	{	
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        void btnEdit_Clicked(System.Object sender, System.EventArgs e)
        {
             
        }

        void btnDelete_Clicked(System.Object sender, System.EventArgs e)
        {

        }

        void btnSignOut_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}

