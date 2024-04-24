using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KakuroGame.Model;
using SQLite;
using System.Linq;

namespace KakuroGame
{	
	public partial class RecordPage : ContentPage
	{	
		public RecordPage ()
		{
			InitializeComponent ();

		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var username = SessionManager.GetSession();
            try { 
                var records = await RecordDBManager.GetRecords(username);

                if (records == null)
                {
                    await DisplayAlert("Error", "There was an unexpected problem with the database, try again later", "Ok");
                }
                else
                    recordListView.ItemsSource = records;
            } catch
            {
                await DisplayAlert("Error", "Couldn't connect to the database", "Ok");
            }
        }


        void recordListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedRecord = (Record)e.SelectedItem;
        }
    }
}

