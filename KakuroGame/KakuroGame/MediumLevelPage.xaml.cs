using System;
using System.Collections.Generic;
using System.ComponentModel;
using KakuroGame.Enums;
using KakuroGame.Model;
using Xamarin.Forms;

namespace KakuroGame
{
    [DesignTimeVisible(true)]
    public partial class MediumLevelPage : ContentPage
	{	
		public MediumLevelPage ()
		{
			InitializeComponent ();
            lblTimer.BindingContext = new Clock();
            PopulateValues();
        }

        public void PopulateValues()
        {

            Game game = Game.GetInstance();
            game.GenerateKakuro(EDifficulty.Medium);
            BindingContext = game;
            var board = game.kakuro.Board;
            //Row 0
            lblx0y1.Text = Convert.ToString(board[0, 1].VerticalTargetValue);
            lblx0y2.Text = Convert.ToString(board[0, 2].VerticalTargetValue);
            lblx0y3.Text = Convert.ToString(board[0, 3].VerticalTargetValue);
            //Row 1
            lblx1y0.Text = Convert.ToString(board[1, 0].HorizontalTargetValue);
            lblx1y1.Text = "";
            lblx1y2.Text = "";
            lblx1y3.Text = ""; 
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = "";
            lblx2y2.Text = "";
            lblx2y3.Text = "";
            //Row 3
            lblx3y0.Text = Convert.ToString(board[3, 0].HorizontalTargetValue);
            lblx3y1.Text = "";
            lblx3y2.Text = "";
            lblx3y3.Text = "";
        }

        void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }



        void lblx1y1_PropertyChanged_1(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is Entry entry && e.PropertyName == "Text")
            {

                int rowId = ValidateCells.GetRowId(entry);
                int columnId = ValidateCells.GetColumnId(entry);
                Game game = Game.GetInstance();
                int value;
                if (int.TryParse(entry.Text, out value))
                {
                    if (game.CheckCell(value, (rowId, columnId)))
                    {
                        DisplayAlert("Congratulations", "You have won!", "Ok");
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
                    }

                }
            }
        }
    }
}

