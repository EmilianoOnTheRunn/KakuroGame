using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(userNameEntry.Text);
            bool isPassEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            if (isEmailEmpty || isPassEmpty)
            {


            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}

