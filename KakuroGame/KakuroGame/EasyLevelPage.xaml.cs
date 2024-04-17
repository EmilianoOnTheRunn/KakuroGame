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
            PopulateValues();
            
        }

        public void PopulateValues() {

            Game game = Game.GetInstance();
            game.GenerateKakuro(EDifficulty.Easy);
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
            bool questionDisplayed = false;
            bool loserDisplayed = false;
            bool invalidNumber = false;
            foreach (Entry entry in new Entry[] { lblx1y1, lblx1y2, lblx2y1, lblx2y2 })
            {
                
                int rowId = ValidateCells.GetRowId(entry);
                int columnId = ValidateCells.GetColumnId(entry);
                int value;

                if (int.TryParse(entry.Text, out value))
                {
                    if (game.CheckCell(value, (rowId, columnId)))
                    {
                        if (!questionDisplayed)
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
                                    RecordDBManager.Add(time);
                                }
                                await DisplayAlert("Saved Game", "You have successfully saved a record", "Ok");
                            }
                            questionDisplayed = true;
                        }


                    }
                    else {
                        if (!loserDisplayed)
                        {
                            await DisplayAlert("Oh no", "You have lost :(", "try again !_!");
                            loserDisplayed = true;
                        }
                    }
                    
                }
                else
                {
                    if (!invalidNumber)
                    {
                        await DisplayAlert("Error", "Please enter a valid number", "Ok");
                        invalidNumber = true;
                    }  
                    
                }
            }

        }


    }
}

