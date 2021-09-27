using KutuphaneTakip.Classes;
using KutuphaneTakip.Classes.Parametreler;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KutuphaneTakip
{
    /// <summary>
    /// winKitapEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class winKitapEkle : Window
    {        

        public winKitapEkle()
        {
            InitializeComponent();
        }

        sbyte resimKontrol = 0;

        private void txt_BaskiSayisi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void txt_SayfaSayisi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void txt_StokAdedi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void btn_KitapEleKApat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_KitapEkeBilgi_Click(object sender, RoutedEventArgs e)
        {
            /*
            if(popup_Bilgi.IsOpen == true)
            {
                popup_Bilgi.IsOpen = false;
            }
            else
            {
                popup_Bilgi.IsOpen = true;
            }
            */

            PopUpSettings.PopUpShow(popup_Bilgi);

        }

        private void btn_KitapEkle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_Barkod.Text != "" && cmb_KitapTuru.Text != "" && txt_KitapAdi.Text != "")
            {
                prm veri = new prm();
                prm.BarkodNo = txt_Barkod.Text;
                veri.Barkod = txt_Barkod.Text;
                veri.KitapAdi = txt_KitapAdi.Text;
                veri.BaskiYeri = cmb_BaskiYeri.Text;
                veri.BaskiTarihi = dp_BaskiTarihi.Text;
                veri.Baskisayisi = txt_BaskiSayisi.Text;
                veri.KitapTuru = cmb_KitapTuru.Text;
                veri.Sayfasayisi = txt_SayfaSayisi.Text;
                veri.Konusu = txt_Konusu.Text;
                veri.Dili = cmb_Dili.Text;
                veri.TeminTuru = cmb_TeminTuru.Text;
                veri.TeminTarihi = dp_TeminTarihi.Text;
                
                if(resimKontrol ==1)
                {
                    veri.Resim = prm.ResimAdi;
                }
                else
                {
                    veri.Resim = null;
                }
                

                veri.YayinEviID = 1;
                veri.YayinEviID = 1;
                veri.YazarAdiID = 1;

                if (DBİslem.EklemeIslemi(veri))
                {
                    prm.Hata = 0;
                    BilgiEkrani bilgiEkrani = new BilgiEkrani();
                    prm.BilgiEkraniContent = "Kayıt İşlemi Başarılı.";
                    bilgiEkrani.Show();

                    resimKontrol = 1;
                }
                else
                {
                    prm.Hata = 1;
                    BilgiEkrani bilgiEkrani = new BilgiEkrani();
                    prm.BilgiEkraniContent = "Zorunlu Alanları Doldurunuz ! \n(Barkod, Kitap Türü ve Kitap Adı)";
                    bilgiEkrani.Show();
                }

            }
            else
            {
                prm.Hata = 1;
                BilgiEkrani bilgiEkrani = new BilgiEkrani();
                prm.BilgiEkraniContent = "Zorunlu Alanları Doldurunuz ! \n(Barkod, Kitap Türü ve Kitap Adı)";
                bilgiEkrani.Show();
            }

        }

        string SecilenResimAdi;
        private void btn_ResimEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler"))
                {
                    Directory.CreateDirectory(prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler");
                }
                
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "Resim Seç";
                fileDialog.InitialDirectory = "";
                fileDialog.Filter = "Image Files (*.jpg;*.jpeg) *.jpg;*.jpeg|PNG Files (*.png) *.png JPG Files (*.jpg)]*.jpg";
                fileDialog.FilterIndex = 1;

                if((bool)fileDialog.ShowDialog())
                {
                    //openfile dialog ile  seçilen resmi oluşturduğumuz klasör içerisine kopyalama işlemi
                    SecilenResimAdi = fileDialog.FileName;
                    DateTime zaman = DateTime.Now;
                    string format = "dd-MM-yyyy-_hh-mm-ss";
                    prm.ResimAdi = prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler\\" + prm.BarkodNo + zaman.ToString(format)+".jpg";

                    File.Copy(SecilenResimAdi, prm.ResimAdi, true);

                    //belgelerim içerisindeki resim yolunu uri'ye çevirip ekrana bastırma
                    BitmapImage imgMap = new BitmapImage();
                    imgMap.BeginInit();
                    imgMap.UriSource = new Uri(@""+prm.ResimAdi);
                    imgMap.EndInit();

                    img_KitapResmi.Source = imgMap; // seçilen resmi anında arayüz üzerinde görme.

                    prm.Hata = 0;
                    BilgiEkrani bilgiEkrani = new BilgiEkrani();
                    prm.BilgiEkraniContent = "Resim Ekleme İşlemi Başarılı.";
                    bilgiEkrani.Show();
                    
                }
                else
                {
                    prm.Hata = 1;
                    BilgiEkrani bilgiEkrani = new BilgiEkrani();
                    prm.BilgiEkraniContent = "Resim Ekleme İşlemi Başarısız!";
                    bilgiEkrani.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
