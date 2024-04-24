using System;
using Xamarin.Essentials;
namespace KakuroGame.Model
{
	public static class SessionManager
	{
		private const string SessionKey = "1234567890";

        

		public static void StartSession(string username) => Preferences.Set(SessionKey, username);

        public static string GetSession() => Preferences.Get(SessionKey, null);

        public static void RemoveSession() => Preferences.Remove(SessionKey);

        public static bool CheckSessionStatus() => !string.IsNullOrEmpty(GetSession());

    }
}

