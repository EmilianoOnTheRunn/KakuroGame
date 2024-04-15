using System;
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
            lblx1y2.Text = Convert.ToString(board[1, 2].value);
            lblx1y3.Text = Convert.ToString(board[1, 3].value);
            lblx1y4.Text = Convert.ToString(board[1, 4].VerticalTargetValue);
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = Convert.ToString(board[2, 1].value);
            lblx2y2.Text = Convert.ToString(board[2, 2].value);
            lblx2y3.Text = Convert.ToString(board[2, 3].value);
            lblx2y4.Text = Convert.ToString(board[2, 4].value);
            //Row 3
            lblx3y0.Text = Convert.ToString(board[3, 0].HorizontalTargetValue);
            lblx3y1.Text = Convert.ToString(board[3, 1].value);
            lblx3y2.Text = Convert.ToString(board[3, 2].value);
            lblx3y3.Text = Convert.ToString(board[3, 3].value);
            lblx3y4.Text = Convert.ToString(board[3, 4].value);
            //Row 4
            lblx4y1.Text = Convert.ToString(board[4, 1].HorizontalTargetValue);
            lblx4y2.Text = Convert.ToString(board[4, 2].value);
            lblx4y3.Text = Convert.ToString(board[4, 3].value);
        }

        void btnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}

