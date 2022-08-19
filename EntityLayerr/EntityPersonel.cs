using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayerr
{
    //katmanı public hale getir diğer katmanlardan erişebilmek için
    public class EntityPersonel //tablomun kendisi olucak aslında
    {
        //kapsülleme yaptık; ctrl+r+E  
        private int id;
        private string ad;
        private string soyad;
        private string sehir;
        private string gorev;
        private short maas;

        //property; db üzerinde crud işlemleri gerçekleştirebilmem için,değişken tanımımdan sonra yaptım
        public int Id { get => id; set => id = value; }  //get ile oku set ile değer ata
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Gorev { get => gorev; set => gorev = value; }
        public short Maas { get => maas; set => maas = value; }
    }
}
