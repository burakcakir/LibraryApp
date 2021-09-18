using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KutuphaneTakip.Classes
{
    public class DBbaglanti
    {
        public static string DBadres = @"Data Source=" + Environment.CurrentDirectory + "\\DB\\kitap.db;Version=3;New=False;Compress=True;Read Only=False";

        public static string BagDurum;

        public static void BagTest()
        {
            using (SqliteConnection coon = new SqliteConnection(DBadres))
            {
                if (coon.State == ConnectionState.Closed)
                {
                    try
                    {
                        coon.Open();
                        BagDurum = "Veritabanı Bağlantına Bağlanıldı.";
                    }
                    catch (Exception E)
                    {   
                        BagDurum = "Hata Sebep : " + E.Message.ToString();
                    }
                }
                else
                {
                    BagDurum = "Veritabanı Bağlantına Bağlanıldı.";
                }
            }
        }


    }
}
