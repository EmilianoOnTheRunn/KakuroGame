using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using KakuroGame.Model;
using System.ComponentModel;

namespace KakuroGame
{
	[DesignTimeVisible(true)]
	public partial class EasyLevelPage : ContentPage
	{	
		public EasyLevelPage ()
		{
			InitializeComponent ();
			BindingContext = new Clock();

            //int[,] kakuroValues = new int[,]
            //{
            //    { 0, 7, 4 },
            //    { 8, 0, 0 },
            //    { 3, 2, 1 }
            //};

            //for (int row = 0; row < kakuroValues.GetLength(0); row++)
            //{
            //    for (int col = 0; col < kakuroValues.GetLength(1); col++)
            //    {
            //        Frame frame = new Frame
            //        {
            //            Style = (Style)Application.Current.Resources["FrameGame"],
            //            Content = new StackLayout
            //            {
            //                Children =
            //    {
            //        new Label
            //        {
            //            Text = kakuroValues[row, col].ToString(),
            //            Margin = new Thickness(50, 0, 0, 20),
            //            TextColor = Color.White
            //        }
            //    }
            //            }
            //        };

            //        KakuroGrid.Children.Add(frame, col, row);
            //    }
            //}

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
                        Kakuro kakuro = new Kakuro(3, 3);
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

