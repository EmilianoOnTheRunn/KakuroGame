using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class PasswordPage : ContentPage
	{	
		public PasswordPage ()
		{
			InitializeComponent ();
		}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}

