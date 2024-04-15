using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using Xamarin.Forms;

namespace KakuroGame.Model
{
	public class Clock : INotifyPropertyChanged
    {

        Stopwatch stopWatch = new Stopwatch();

        public string Hours => stopWatch.Elapsed.Hours.ToString();
        public string Minutes => stopWatch.Elapsed.Minutes.ToString();
        public string Seconds => stopWatch.Elapsed.Seconds.ToString();


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(true, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Clock()
        {
            stopWatch.Start();
            

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                OnPropertyChanged(nameof(Hours));
                OnPropertyChanged(nameof(Minutes));
                OnPropertyChanged(nameof(Seconds));
                return true;
            });

        }

        public void InitializeElapsedTime(TimeSpan elapsedTime)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            stopWatch.Stop();
            stopWatch.Elapsed.Add(elapsedTime);
            stopWatch.Start();
        }

    }
}

