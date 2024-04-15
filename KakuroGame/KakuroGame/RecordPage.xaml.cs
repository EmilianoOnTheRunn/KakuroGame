﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KakuroGame.Model;
using SQLite;

namespace KakuroGame
{	
	public partial class RecordPage : ContentPage
	{	
		public RecordPage ()
		{
			InitializeComponent ();

		}
        List<Record> listRecords = new List<Record>
        {
            new Record(new Clock(), new Kakuro(Enums.EDifficulty.Easy), "user1"),
            new Record(new Clock(), new Kakuro(Enums.EDifficulty.Medium), "user2"),
            new Record(new Clock(), new Kakuro(Enums.EDifficulty.Hard), "user3")
        };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            recordListView.ItemsSource = listRecords;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
        //    {
        //        //con.CreateTable<Record>();
        //        //var records = con.Table<Record>().ToList();
        //        recordListView.ItemsSource = listRecords;
        //    }
        //}


        void recordListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedRecord = (Record)e.SelectedItem;
        }
    }
}

