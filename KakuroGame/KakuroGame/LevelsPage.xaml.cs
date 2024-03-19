using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KakuroGame
{	
	public partial class LevelsPage : ContentPage
	{	
		public LevelsPage ()
		{
			InitializeComponent ();
		}

        void btnEasy_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EasyLevelPage());
        }

        void btnMedium_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MediumLevelPage());
        }

        void btnHard_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HardLevelPage());
        }
    }
}

