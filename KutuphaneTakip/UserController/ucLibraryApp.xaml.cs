using KutuphaneTakip.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KutuphaneTakip.UserController
{
    /// <summary>
    /// Interaction logic for ucLibraryApp.xaml
    /// </summary>
    public partial class ucLibraryApp : UserControl
    {
        public ucLibraryApp()
        {
            InitializeComponent();
        }

        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        private void btn_KitapEkle_Click(object sender, RoutedEventArgs e)
        {
            winKitapEkle ekle = new winKitapEkle();
            ekle.Owner = gk;
            //gk.Opacity = 0.3;
            ekle.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBİslem.GridDoldur(dtg_KitapListesi);
        }

        int barkodNo;
        string kitapTuru , KitapYazari ;
        private void dtg_KitapListesi_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            barkodNo = Convert.ToInt32(((TextBlock)dtg_KitapListesi.Columns[0].GetCellContent(dtg_KitapListesi.SelectedItem)).Text);

            MessageBox.Show("Satır Seçildi.");
        }
    }
}
