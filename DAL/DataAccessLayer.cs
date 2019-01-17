using DAL.Tablo_Sınıfları;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL
{
    public class DataAccessLayer
    {
        SqlConnection con;
        public DataAccessLayer()
        {
            con = new SqlConnection(adress);
        }

        static string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";
        
        public int UrunEkle(Urunler u)
        {
            string sqlsorgu = ""
            int SorguKontrol = 0;
            string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";
             con = new SqlConnection(adress);

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
            if (query.Count() > 0)
            {
                SorguKontrol = 1;
            }

            return SorguKontrol;

        }
        
    }
}
