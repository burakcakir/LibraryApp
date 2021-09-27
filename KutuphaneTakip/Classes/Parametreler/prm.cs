using System;
using System.Globalization;

namespace KutuphaneTakip.Classes.Parametreler
{
    public class prm
    {
        #region Static Parametreler

        public static sbyte Hata;
        public static string BilgiEkraniContent;

        public static string BelgelerimYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();

        public static string ResimAdi;
        public static string BarkodNo;

        #endregion

        #region Ekle Parametreleri

        private string barkod;
        private string kitapAdi;
        private string yazarAdiSoyadi;
        private string yayinEvi;
        private string baskiYeri;
        private string baskiTarihi;
        private string baskisayisi;
        private string kitapTuru;
        private string sayfasayisi;
        private string dili;
        private string konusu;
        private string teminTuru;
        private string teminTarihi;
        private string resim;

        private int ekleyenID;
        private int yayinEviID;
        private int yazarAdiID;

        private bool emanetDurum;

        public string Barkod { get => barkod; set => barkod = value; }
        public string KitapAdi { get => kitapAdi; set => kitapAdi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string YazarAdiSoyadi { get => yazarAdiSoyadi; set => yazarAdiSoyadi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string YayinEvi { get => yayinEvi; set => yayinEvi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string BaskiYeri { get => baskiYeri; set => baskiYeri = value; }
        public string BaskiTarihi { get => baskiTarihi; set => baskiTarihi = value; }
        public string Baskisayisi { get => baskisayisi; set => baskisayisi = value; }
        public string KitapTuru { get => kitapTuru; set => kitapTuru = value; }
        public string Sayfasayisi { get => sayfasayisi; set => sayfasayisi = value; }
        public string Dili { get => dili; set => dili = value; }
        public string Konusu { get => konusu; set => konusu = value; }
        public string TeminTuru { get => teminTuru; set => teminTuru = value; }
        public string TeminTarihi { get => teminTarihi; set => teminTarihi = value; }
        public string Resim { get => resim; set => resim = value; }
        public int EkleyenID { get => ekleyenID; set => ekleyenID = value; }
        public int YayinEviID { get => yayinEviID; set => yayinEviID = value; }
        public int YazarAdiID { get => yazarAdiID; set => yazarAdiID = value; }
        public bool EmanetDurum { get => emanetDurum; set => emanetDurum = value; }

        #endregion

    }
}
