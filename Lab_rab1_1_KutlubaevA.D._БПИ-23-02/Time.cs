using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab_rab1_1_KutlubaevA.D._БПИ_23_02
{
    public class Time : INotifyPropertyChanged
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int Hours
        {
            get => hours;
            set { if (hours != value) { hours = value; OnPropertyChanged(); } }
        }
        public int Minutes
        {
            get => minutes;
            set { if (minutes != value) { minutes = value; OnPropertyChanged(); } }
        }
        public int Seconds
        {
            get => seconds;
            set { if (seconds != value) { seconds = value; OnPropertyChanged(); } }
        }

        public Time(int h, int m, int s) { Hours = h; Minutes = m; Seconds = s; }

        public int GetFullMinutes() => Hours * 60 + Minutes;

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }
        public void DecreaseByTenMinutes()
        {
            int total = Hours * 3600 + Minutes * 60 + Seconds - 10 * 60;
            int day = 24 * 3600;
            total = ((total % day) + day) % day;
            Hours = total / 3600;
            total %= 3600;
            Minutes = total / 60;
            Seconds = total % 60;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
