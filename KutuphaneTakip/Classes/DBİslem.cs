using KutuphaneTakip.Classes.Parametreler;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace KutuphaneTakip.Classes
{
    public class DBİslem
    {

        //DATA GRİD DOLDURMA
        public static bool GridDoldur(DataGrid grd)
        {
            sbyte i = 0;

            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);

            SQLiteCommand com = new SQLiteCommand("select * from tbl_KitapListesi", con);

            //SQLiteCommand com = new SQLiteCommand("Select tbl_Yazarlar. AdiSoyadi, tbl_KitapListesi. Barkod, tbl_kitapListesi.ID, tbl_KitapListesi.KitapTuru,

            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                con.Dispose();
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }




        }


        //VERİ EKLEME 
        public static bool EklemeIslemi(prm veri)
        {
            sbyte i = 0;

            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);

            SQLiteCommand com = new SQLiteCommand("Insert into tbl_KitapListesi " +
                "(Barkod, KitapAdi, Kitapturu, KitapKonusu, BaskiYeri, Baskisayisi, BaskiTarihi, TeminTuru, TeminTarihi, SayfaSayisi, Resim, EkleyenID, YayinEviID, YazarAdiID) values " +
                "(@Barkod, @Kitapadi, @Kitapturu, @Kitapkonusu,@BaskiYeri, @Baskisayisi, @BaskiTarihi,@TeminTuru,@TeminTarihi,@sayfasayisi, @Resim, @EkleyenID, @YayinEviID, @YazarAdiID)", con);

            com.Parameters.AddWithValue("@Barkod", veri.Barkod);
            com.Parameters.AddWithValue("@KitapAdi", veri.KitapAdi);
            com.Parameters.AddWithValue("@Kitapturu", veri.KitapTuru);
            com.Parameters.AddWithValue("@kitapkonusu", veri.Konusu);
            com.Parameters.AddWithValue("@BaskiYeri", veri.BaskiYeri);
            com.Parameters.AddWithValue("@Baskisayisi", veri.Baskisayisi);
            com.Parameters.AddWithValue("@BaskiTarihi", veri.BaskiTarihi);
            com.Parameters.AddWithValue("@TeminTuru", veri.TeminTuru);
            com.Parameters.AddWithValue("@TeminTarihi", veri.TeminTarihi);
            com.Parameters.AddWithValue("@SayfaSayisi", veri.Sayfasayisi);
            com.Parameters.AddWithValue("@Resim", veri.Resim);
            com.Parameters.AddWithValue("@EkleyenID", veri.EkleyenID);
            com.Parameters.AddWithValue("@YayinEviID", veri.YayinEviID);
            com.Parameters.AddWithValue("@YazarAdiID", veri.YazarAdiID);

            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Dispose();
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
