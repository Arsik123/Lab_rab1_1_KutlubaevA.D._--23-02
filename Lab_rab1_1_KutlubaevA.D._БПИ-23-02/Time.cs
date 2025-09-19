using System;
namespace Lab_rab1_1_KutlubaevA.D._БПИ_23_02
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public Time(int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 23) throw new ArgumentOutOfRangeException(nameof(hours));
            if (minutes < 0 || minutes > 59) throw new ArgumentOutOfRangeException(nameof(minutes));
            if (seconds < 0 || seconds > 59) throw new ArgumentOutOfRangeException(nameof(seconds));
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int GetFullMinutes()
        {
            return Hours * 60 + Minutes;
        }

        public void DecreaseByTenMinutes()
        {
            int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
            totalSeconds -= 10 * 60;

            int secondsInDay = 24 * 3600;
            totalSeconds = ((totalSeconds % secondsInDay) + secondsInDay) % secondsInDay;

            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        public string ToString(string format)
        {
            if (format == "HH:mm:ss") return ToString();
            return ToString();
        }
    }
}
