using System;
using System.Collections.Generic;
using System.ComponentModel;
using KakuroGame.Model;
using Xamarin.Forms;

namespace KakuroGame
{
    [DesignTimeVisible(true)]
    public partial class HardLevelPage : ContentPage
	{
        public HardLevelPage ()
		{
			InitializeComponent ();
            lblTimer.BindingContext = new Clock();
        }

        void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}

