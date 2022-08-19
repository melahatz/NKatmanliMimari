using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayerr;
using LogicLayer;
using DataAccessLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            //entity personele git perlist değişkeni oluştur sonra değişkeniöin içerisine değer ata
            //Logic personel sınıfım içindeki LLpersonellistesine ata. 
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Maas = short.Parse(TxtMaas.Text);
            ent.Gorev = TxtGorev.Text;
           
            LogicPersonel.LLPersonelEkle(ent);
            MessageBox.Show("Personel Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(Txtid.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
            MessageBox.Show("Personel Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(Txtid.Text);
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Gorev = TxtGorev.Text;
            ent.Maas = short.Parse(TxtMaas.Text);
            LogicPersonel.LLPersonelGuncelle(ent);
            MessageBox.Show("Personel Bilgileri Güncellendi");
        }

        
    }
}
