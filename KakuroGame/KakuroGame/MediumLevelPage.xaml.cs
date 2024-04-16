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
            lblx1y1.Text = Convert.ToString(board[1, 1].value);
            lblx1y2.Text = Convert.ToString(board[1, 2].value);
            lblx1y3.Text = Convert.ToString(board[1, 3].value);
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = Convert.ToString(board[2, 1].value);
            lblx2y2.Text = Convert.ToString(board[2, 2].value);
            lblx2y3.Text = Convert.ToString(board[2, 3].value);
            //Row 3
            lblx3y0.Text = Convert.ToString(board[3, 0].HorizontalTargetValue);
            lblx3y1.Text = Convert.ToString(board[3, 1].value);
            lblx3y2.Text = Convert.ToString(board[3, 2].value);
            lblx3y3.Text = Convert.ToString(board[3, 3].value);
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
                    }

                }


            }
        }
    }
}

