using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-B2JOG7A;" +
            "Initial Catalog=DbPersonel;" +
            "Integrated Security=True");
        //c# da bazı şartlarda yeni nesne türetmeden kullanacağımız komutlar var bu komutlat static komutlar olarak geçer

    }
}
