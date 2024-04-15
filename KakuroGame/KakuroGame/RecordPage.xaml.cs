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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Record>();
                var records = con.Table<Record>().ToList();
                recordListView.ItemsSource = records.Where(s => s.Username == SessionManager.GetSession());
            }
        }


        void recordListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedRecord = (Record)e.SelectedItem;
        }
    }
}

