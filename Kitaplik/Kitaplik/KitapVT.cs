using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kitaplik
{

    class KitapVT
    {
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\acer\Desktop\Kitaplik.mdb");

        public List<Kitap> Liste()
        {
            List<Kitap> ktp = new List<Kitap>();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kitaplar", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                Kitap k = new Kitap();
                k.ID =Convert.ToInt16(dr[0].ToString());
                k.AD = dr[1].ToString();
                k.YAZARI = dr[2].ToString();

                ktp.Add(k);
            }
            baglanti.Close();
            return ktp;
        }
        public void KitapEkle(Kitap kt)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Kitaplar (KitapAd,Yazar) values (@P1,@P2)",baglanti);
            komut.Parameters.AddWithValue("@P1",kt.AD);
            komut.Parameters.AddWithValue("@P2",kt.YAZARI);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }

    }
}
