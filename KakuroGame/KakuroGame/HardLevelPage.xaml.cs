﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using KakuroGame.Enums;
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
            PopulateValues();
        }

        public void PopulateValues()
        {

            Game game = Game.GetInstance();
            game.GenerateKakuro(EDifficulty.Hard);
            BindingContext = game;
            var board = game.kakuro.Board;
            //Row 0
            lblx0y2.Text = Convert.ToString(board[0, 2].VerticalTargetValue);
            lblx0y3.Text = Convert.ToString(board[0, 3].VerticalTargetValue);
            //Row 1
            lblx1y1Top.Text = Convert.ToString(board[1, 1].HorizontalTargetValue);
            lblx1y1Bottom.Text = Convert.ToString(board[1, 1].VerticalTargetValue);
            lblx1y2.Text = "";
            lblx1y3.Text = "";
            lblx1y4.Text = Convert.ToString(board[1, 4].VerticalTargetValue);
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = "";
            lblx2y2.Text = "";
            lblx2y3.Text = "";
            lblx2y4.Text = "";
            //Row 3
            lblx3y0.Text = Convert.ToString(board[3, 0].HorizontalTargetValue);
            lblx3y1.Text = "";
            lblx3y2.Text = "";
            lblx3y3.Text = "";
            lblx3y4.Text = "";
            //Row 4
            lblx4y1.Text = Convert.ToString(board[4, 1].HorizontalTargetValue);
            lblx4y2.Text = "";
            lblx4y3.Text = "";
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
                        RecordDBManager.Add(time);
                    }
                    await DisplayAlert("Saved Game", "You have successfully saved a record", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Sorry, the kakuro isn't solved", "Try changing the values and then you can evaluate again", "Ok");
            }
        }

        void lblx1y2_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is Entry entry && e.PropertyName == "Text")
            {

                int rowId = ValidateCells.GetRowId(entry);
                int columnId = ValidateCells.GetColumnId(entry);
                Game game = Game.GetInstance();
                int value;
                if (int.TryParse(entry.Text, out value))
                {
                    game.CheckCell(value, (rowId, columnId));
                }
                else if (entry.Text != "")
                {
                    DisplayAlert("Error", "Please enter a valid number", "Ok");
                }
            }
        }
    }
}

