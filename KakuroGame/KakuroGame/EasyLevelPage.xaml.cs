using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using KakuroGame.Model;
using KakuroGame.Enums;
using System.ComponentModel;

namespace KakuroGame
{
	[DesignTimeVisible(true)]
	public partial class EasyLevelPage : ContentPage
	{	
		public EasyLevelPage ()
		{
			InitializeComponent ();
            lblTimer.BindingContext = new Clock();
            Game game = Game.GetInstance();
            game.GenerateKakuro(EDifficulty.Easy);
            BindingContext = game;
        }

        void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblTimer.Text)) {

                    if (TimeSpan.TryParse(lblTimer.Text, out TimeSpan elapsedTime)) {

                        //TimeSpan elapsedTime = TimeSpan.Parse(lblTimer.Text);

                        Clock clock = new Clock();
                        clock.InitializeElapsedTime(elapsedTime);
                        Kakuro kakuro = new Kakuro(Enums.EDifficulty.Easy);
                        string username = SessionManager.GetSession();
                        Record record = new Record(clock, kakuro, username);

                        if (RecordDBManager.SaveRecord(record))
                        {
                            DisplayAlert("Success", "Record successfully saved", "Ok");
                            Navigation.PopAsync();
                        }
                        else
                        {
                            DisplayAlert("Failed", "Failed to save the game", "Ok");
                        }
                    }
                    
                }
                
            }
            catch (Exception ex) {

                DisplayAlert("Error", $"System error: {ex.Message}", "Ok");

            }

        }
        

    }
}

