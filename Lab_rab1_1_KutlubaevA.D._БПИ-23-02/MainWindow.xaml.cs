using System;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab1_1_KutlubaevA.D._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private bool TryReadTime(out Time t)
        {
            t = null;

            if (!int.TryParse(HoursBox.Text, out int h) ||
                !int.TryParse(MinutesBox.Text, out int m) ||
                !int.TryParse(SecondsBox.Text, out int s))
            {
                MessageBox.Show("Введите целые числа для часов, минут и секунд.");
                return false;
            }

            if (h < 0 || h > 23)
            {
                MessageBox.Show("Часы должны быть в диапазоне 0..23.");
                return false;
            }
            if (m < 0 || m > 59)
            {
                MessageBox.Show("Минуты должны быть в диапазоне 0..59.");
                return false;
            }
            if (s < 0 || s > 59)
            {
                MessageBox.Show("Секунды должны быть в диапазоне 0..59.");
                return false;
            }

            t = new Time(h, m, s);
            return true;
        }

        private void BtnFullMinutes_Click(object sender, RoutedEventArgs e)
        {
            if (!TryReadTime(out Time t)) return;
            int fullMinutes = t.GetFullMinutes();
            ResultText.Text = $"Полные минуты в указанном времени: {fullMinutes}";
        }

        private void BtnMinus10_Click(object sender, RoutedEventArgs e)
        {
            if (!TryReadTime(out Time t)) return;
            t.DecreaseByTenMinutes();
            HoursBox.Text = t.Hours.ToString();
            MinutesBox.Text = t.Minutes.ToString();
            SecondsBox.Text = t.Seconds.ToString();
            ResultText.Text = $"После уменьшения на 10 минут: {t:HH:mm:ss}";
        }
    }
}
