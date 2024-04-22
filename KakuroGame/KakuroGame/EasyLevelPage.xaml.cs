using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using KakuroGame.Model;
using KakuroGame.Enums;
using System.ComponentModel;
using System.Diagnostics;

namespace KakuroGame
{
	[DesignTimeVisible(true)]
	public partial class EasyLevelPage : ContentPage
	{
        public EasyLevelPage ()
		{
			InitializeComponent ();
            lblTimer.BindingContext = new Clock();
            StartGame();
            
        }

        public void StartGame() {

            Game game = Game.GetInstance();
            game.SetUpKakuro(EDifficulty.Easy);
            BindingContext = game;
            var board = game.kakuro.Board;
            //Row 0
            lblx0y1.Text = Convert.ToString(board[0, 1].VerticalTargetValue);
            lblx0y2.Text = Convert.ToString(board[0, 2].VerticalTargetValue);
            //Row 1
            lblx1y0.Text = Convert.ToString(board[1, 0].HorizontalTargetValue);
            lblx1y1.Text = "";
            lblx1y2.Text = "";
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = "";
            lblx2y2.Text = "";
        }

        async void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            Game game = Game.GetInstance();
            
            if (game.ValidateKakuro())
            {      
                await DisplayAlert("Congratulations", "You have won!", "Ok");
                bool answer = await DisplayAlert("Game Over", "Would you like to save a game", "Yes", "No");
                if (answer)
                {
                    Clock clock = lblTimer.BindingContext as Clock;
                    if (clock != null)
                    {
                        var hour = Convert.ToInt32(clock.Hours);
                        var minutes = Convert.ToInt32(clock.Minutes);
                        var second = Convert.ToInt32(clock.Seconds);
                        DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        hour, minutes, second);
                        if (RecordDBManager.Add(time))
                            await DisplayAlert("Saved Game", "You have successfully saved a record", "Ok");
                        else
                            await DisplayAlert("Error", "The record couldn't be saved", "Ok");
                    }
                }

            }
            else
            {
                await DisplayAlert("Sorry, the kakuro isn't solve", "Try changing the values and then you can evaluate again", "Ok");
            }
        }

        void CellValueChange_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is Entry entry && e.PropertyName == "Text")
            {

                Game game = Game.GetInstance();

                int rowID = ValidateCells.GetRowId(entry);
                int columnID = ValidateCells.GetColumnId(entry);
                
                if (int.TryParse(entry.Text, out var value))
                {
                    game.CheckCell(value, (rowID, columnID));
                }
                else if (entry.Text != "")
                {
                    DisplayAlert("Error", "Please enter a valid number", "Ok");
                }
            }
        }

    }
}

