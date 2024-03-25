using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class EasyLevelPage : ContentPage
	{	
		public EasyLevelPage ()
		{
			InitializeComponent ();
		}

        void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
			Navigation.PopAsync();
        }

    }
}

