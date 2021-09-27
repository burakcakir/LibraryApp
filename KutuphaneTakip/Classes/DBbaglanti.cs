using System;
using System.Data;
using System.Data.SQLite;

namespace KutuphaneTakip.Classes
{
    public class DBbaglanti
    {
        public static string DBadres = "Data Source=" + Environment.CurrentDirectory + "\\DB\\kitap.db;Version=3;New=False;Compress=True;Read Only=False";

        public static string BagDurum;

        public static void BagTest()
        {
            using (SQLiteConnection coon = new SQLiteConnection(DBadres))
            {
                if (coon.State == ConnectionState.Closed)
                {
                    try
                    {
                        coon.Open();
                        BagDurum = "Bağlandı";
                    }
                    catch (Exception E)
                    {
                        BagDurum = "Hata Sebep : " + E.Message.ToString();
                    }
                }
                else
                {
                    BagDurum = "Bağlandı";
                }
            }
        }


    }
}
