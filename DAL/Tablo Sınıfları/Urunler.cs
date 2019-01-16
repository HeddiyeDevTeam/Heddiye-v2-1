using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace DAL.Tablo_Sınıfları
{
    public class Urunler
    {
        public string UrunAdi { get; set; }
        public string CinsiyetAdi { get; set; }
        public string HediyeAmaci { get; set; }
        public string YakinlikDerecesi { get; set; }
        public string YasAraligi { get; set; }
        public string BurcAdi { get; set; }
        public void UrunEkle(Urunler u)
        {
            string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";
            SqlConnection con = new SqlConnection(adress);
           
            var query = con.Query<Urunler>("SP_UrunEkle",
                new
                {
                    UrunAdii = u.UrunAdi,
                    Cinsiyet = u.CinsiyetAdi,
                    HediyeAmacii = u.HediyeAmaci,
                    YakinlikDerecesii = u.YakinlikDerecesi,
                    YasAraligii = u.YasAraligi,
                    Burcadii = u.BurcAdi
                }, commandType: CommandType.StoredProcedure);
      
            
        }
    }
}
