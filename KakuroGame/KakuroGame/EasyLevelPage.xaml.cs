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
            lblx1y1.Text = Convert.ToString(board[1, 1].value);
            lblx1y2.Text = Convert.ToString(board[1, 2].value);
            //Row 2
            lblx2y0.Text = Convert.ToString(board[2, 0].HorizontalTargetValue);
            lblx2y1.Text = Convert.ToString(board[2, 1].value);
            lblx2y2.Text = Convert.ToString(board[2, 2].value);
           
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

        void lblx1y1_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (sender is Entry entry && e.PropertyName == "Text")
            {
                
                int rowId = ValidateCells.GetRowId(entry);
                int columnId = ValidateCells.GetColumnId(entry);
                Game game = Game.GetInstance();
                int value;
                if (int.TryParse(entry.Text , out value)) {
                    if (game.CheckCell(value, (rowId, columnId)))
                    {
                        DisplayAlert("Congratulations", "You have won!", "Ok");
                        Clock clock = lblTimer.BindingContext as Clock;
                        if (clock != null)
                        {
                            RecordDBManager.Add(clock);
                        }
                    }

                }
            }
        }


    }
}

