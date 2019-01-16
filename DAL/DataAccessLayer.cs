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
        
        SqlDataAdapter adap;
        DataSet ds;
        DataTable dt;
        public void UrunEkle(Urunler u)
        {
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

        }
        public void deneme(CinsiyetTablo c)
        {

           var acb = con.Query<CinsiyetTablo>("Select * from Cinsiyet Where CinsiyetAdi = @id", new { @id = c.CinsiyetAdi });

            
        }

        public DataSet Cinsiyet()
        {
            dt = new DataTable();
            adap = new SqlDataAdapter("Select * from Cinsiyet", con);
            ds.Tables.Add("Cinsiyet");
            adap.Fill(ds.Tables[0]);

            return ds;
        }

    }
}
