using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerr; //dataacces layer içerisine referance olarak ekledim entity layerı sonra burda çağırdım
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
    public class DALPersonel
    { 
                      
        public static List<EntityPersonel> PersonelListesi()//türü entity katmanındaki sınıf olucak ve method ismini yazdık
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Bilgi", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open) //bağlantım açık değilse
            {
                komut1.Connection.Open(); //bağlantıyı aç
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel(); //nesne türetiyorum 
                ent.Id = int.Parse(dr["ID"].ToString()); //propertylere burdan ulaşabiliyorum
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Gorev = dr["Görev"].ToString();
                ent.Maas = short.Parse(dr["Maas"].ToString());
                degerler.Add(ent); //değerlerin içersine ekle ent adlı nesnemden gelen deperleri

            }
            dr.Close();
            return degerler; //değerlerimi listenin içerisine almış oldum.
        }

        public static int PersonelEkle(EntityPersonel p)
        {

            SqlCommand komut2 = new SqlCommand("insert into Tbl_Bilgi (Ad,Soyad,Görev,Sehir,Maas)" +
                "values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open) //bağlantım açık değilse
            {
                komut2.Connection.Open(); //bağlantıyı aç
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Gorev);
            komut2.Parameters.AddWithValue("@p4", p.Sehir);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery(); //kayıtdan etkilenen kayıt sayısını döndürücek o yüzden int

        }
        public static bool PersonelSil(int p) //dIŞARIDAN BİR ENTİTY DEĞİL İD PARAMETRESİ GÖNDERİCEM
        {
            SqlCommand komut3 = new SqlCommand("Delete from Tbl_Bilgi where ID=@p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open) //bağlantım açık değilse
            {
                komut3.Connection.Open(); //bağlantıyı aç
            }
            komut3.Parameters.AddWithValue("@p1", p);
            return komut3.ExecuteNonQuery()>0;
        }

        public static bool PersonelGuncelle(EntityPersonel ent) //birden fazla parametre göndereceğimden EntityPersonel den nesne türettim
        {
            SqlCommand komut4 = new SqlCommand("Update Tbl_Bilgi set Ad=@p1,Soyad=@p2,Maas=@p3,Sehir=@p4,Görev=@p5 where ID=@p6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open) //bağlantım açık değilse
            {
                komut4.Connection.Open(); //bağlantıyı aç
            }
            komut4.Parameters.AddWithValue("@p1", ent.Ad);
            komut4.Parameters.AddWithValue("@p2", ent.Soyad);
            komut4.Parameters.AddWithValue("@p3", ent.Maas);
            komut4.Parameters.AddWithValue("@p4", ent.Sehir);
            komut4.Parameters.AddWithValue("@p5", ent.Gorev);
            komut4.Parameters.AddWithValue("@p6", ent.Id);
            return komut4.ExecuteNonQuery() > 0; //bu işlemler gerçekleşirse döndürüyor olucak
        }
    }
}
