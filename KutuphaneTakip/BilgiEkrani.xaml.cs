using KutuphaneTakip.Classes.Parametreler;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace KutuphaneTakip
{
    /// <summary>
    /// BilgiEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class BilgiEkrani : Window
    {
        public BilgiEkrani()
        {
            InitializeComponent();
        }

        private void btn_BilgiEkrani_Kapatma_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;

            Hata();

            // 5 saniye sonra kapan.
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(5)
            };

            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (this.ShowActivated) this.Close();
            };

            timer.Start();

        }

        void Hata()
        {
            if (prm.Hata == 0)
            {
                Olumlu_BilgiEkrani.Visibility = Visibility.Visible;
                Olumsuz_BilgiEkrani.Visibility = Visibility.Hidden;
                BilgiEkrani_Content.Content = prm.BilgiEkraniContent;
                Header.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff134187");
                BilgiEkrani_Content.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff134187");
                img_Olumlu.Visibility = Visibility.Visible;
                img_Olumsuz.Visibility = Visibility.Hidden;
            }
            else
            {
                Olumlu_BilgiEkrani.Visibility = Visibility.Hidden;
                Olumsuz_BilgiEkrani.Visibility = Visibility.Visible;
                BilgiEkrani_Content.Content = prm.BilgiEkraniContent;
                Header.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff4caf50");
                BilgiEkrani_Content.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff4caf50");
                img_Olumlu.Visibility = Visibility.Hidden;
                img_Olumsuz.Visibility = Visibility.Visible;
            }
        }

    }
}
