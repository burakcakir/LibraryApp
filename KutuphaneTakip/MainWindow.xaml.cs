using KutuphaneTakip.Classes;
using KutuphaneTakip.UserController;
using System.Windows;
using System.Windows.Input;

namespace KutuphaneTakip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brd_Sagust_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new ucLibraryApp());
            DBbaglanti.BagTest();
            deneme.Content = DBbaglanti.BagDurum;
        }

        private void btn_SimgeDurumu_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_TamEkran_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grd_AnaGridWindow.Margin = new Thickness(0, 0, 0, 15);
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                grd_AnaGridWindow.Margin = new Thickness(15, 15, 15, 15);
            }

        }


        private void btn_hamburgermenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_hamburgermenu.Width != 60)
            {
                GridLength grd = new GridLength(80, GridUnitType.Pixel);
                grdClmn_menu.Width = grd;

                lbl_menu1.Visibility = Visibility.Hidden;
                lbl_menu2.Visibility = Visibility.Hidden;
                lbl_menu3.Visibility = Visibility.Hidden;
                lbl_menu4.Visibility = Visibility.Hidden;
                lbl_menu5.Visibility = Visibility.Hidden;
                lbl_menu6.Visibility = Visibility.Hidden;

                lbl_logoyazi.Width = 0;
                btn_hamburgermenu.Width = 60;
                //btn_hamburgermenu.Visibility = Visibility.Hidden;
                menu_altpencere_resim.Visibility = Visibility.Hidden;
            }
            else
            {
                GridLength grd = new GridLength(220, GridUnitType.Pixel);
                grdClmn_menu.Width = grd;

                lbl_menu1.Visibility = Visibility.Visible;
                lbl_menu2.Visibility = Visibility.Visible;
                lbl_menu3.Visibility = Visibility.Visible;
                lbl_menu4.Visibility = Visibility.Visible;
                lbl_menu5.Visibility = Visibility.Visible;
                lbl_menu6.Visibility = Visibility.Visible;

                lbl_logoyazi.Width = 150;
                btn_hamburgermenu.Width = 100;
                //btn_hamburgermenu.Visibility = Visibility.Visible;
                menu_altpencere_resim.Visibility = Visibility.Visible;
            }

        }

        private void btn_AnaEkleButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        #region menü butonlar 

        int selection;

        private void menubuton_kitaplistesi_Click(object sender, RoutedEventArgs e)
        {
            selection = 1;
            selectionControl(selection);

            uc_cagir.Uc_Ekle(Content_icerik, new ucLibraryApp());
        }

        private void menubuton_okuyuculistesi_Click(object sender, RoutedEventArgs e)
        {
            selection = 2;
            selectionControl(selection);
        }

        private void menubuton_emanetlistesi_Click(object sender, RoutedEventArgs e)
        {
            selection = 3;
            selectionControl(selection);
        }

        private void menubuton_zamanidolanlar_Click(object sender, RoutedEventArgs e)
        {
            selection = 4;
            selectionControl(selection);
        }

        private void menubuton_ayarlar_Click(object sender, RoutedEventArgs e)
        {
            selection = 5;
            selectionControl(selection);
        }

        private void menubuton_hakkinda_Click(object sender, RoutedEventArgs e)
        {
            selection = 6;
            selectionControl(selection);
        }

        #endregion


        #region seçilen butonun seçili olup olmama kontrolü
        void selectionControl(int selection)
        {

            if (selection == 1)
            {
                menubuton_kitaplistesi.IsChecked = true;
            }
            else
            {
                menubuton_kitaplistesi.IsChecked = false;
            }

            if (selection == 2)
            {
                menubuton_okuyuculistesi.IsChecked = true;
            }
            else
            {
                menubuton_okuyuculistesi.IsChecked = false;
            }

            if (selection == 3)
            {
                menubuton_emanetlistesi.IsChecked = true;
            }
            else
            {
                menubuton_emanetlistesi.IsChecked = false;
            }

            if (selection == 4)
            {
                menubuton_zamanidolanlar.IsChecked = true;
            }
            else
            {
                menubuton_zamanidolanlar.IsChecked = false;
            }

            if (selection == 5)
            {
                menubuton_ayarlar.IsChecked = true;
            }
            else
            {
                menubuton_ayarlar.IsChecked = false;
            }

            if (selection == 6)
            {
                menubuton_hakkinda.IsChecked = true;
            }
            else
            {
                menubuton_hakkinda.IsChecked = false;
            }

        }
        #endregion

    }
}
