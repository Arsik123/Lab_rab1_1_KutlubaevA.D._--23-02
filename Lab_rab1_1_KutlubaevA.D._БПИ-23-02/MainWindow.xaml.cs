using System;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab1_1_KutlubaevA.D._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public Time MyTime { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MyTime = new Time(0,0,0);
            DataContext = MyTime;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
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
        private void BtnFullMinutes_Click(object sender, RoutedEventArgs e)
        {
            int fullMinutes = MyTime.GetFullMinutes();
            ResultText.Text = $"Полные минуты в указанном времени: {fullMinutes}";
        }

        private void BtnMinus10_Click(object sender, RoutedEventArgs e)
        {
            MyTime.DecreaseByTenMinutes();
            ResultText.Text = $"После уменьшения на 10 минут: {MyTime}";
        }
    }
}
