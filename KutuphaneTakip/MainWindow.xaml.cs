using KutuphaneTakip.Classes;
using KutuphaneTakip.UserController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void menubuton_kitaplistesi_Click(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik,new ucLibraryApp());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new ucLibraryApp());
            DBbaglanti.BagTest();
            deneme.Content = DBbaglanti.BagDurum;
        }
    }
}
