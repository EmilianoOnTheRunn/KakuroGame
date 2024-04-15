using System;
using KakuroGame.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace KakuroGame
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            KakuroFetcher.FetchKakuro(Enums.EDifficulty.Easy);
            //Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetHasNavigationBar(this, false);
            DatabaseLocation = databaseLocation;

        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

