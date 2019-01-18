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
        DataTable dt;
        SqlConnection con;
        public DataAccessLayer()
        {
            con = new SqlConnection(adress);
        }

        static string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";

        public int UrunEkle(Urunler u)
        {

            int SorguKontrol = 0;

            string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";
            con = new SqlConnection(adress);



            SorguKontrol = con.Execute("SP_UrunEkle", new
            {
                UrunAdii = u.UrunAdi,
                Cinsiyet = u.CinsiyetAdi,
                HediyeAmacii = u.HediyeAmaci,
                YakinlikDerecesii = u.YakinlikDerecesi,
                YasAraligii = u.YasAraligi,
                Burcadii = u.BurcAdi
            }, commandType: CommandType.StoredProcedure);
            if (SorguKontrol > 0)
            {
                SorguKontrol = 1;
            }
            //if ( ((System.Collections.Generic.List<DAL.Tablo_Sınıfları.Urunler>)query).Count>=0)
            //{
            //    SorguKontrol = 1;;
            //}

            return SorguKontrol;

        }
        public DataTable UrunListele(Urunler u)
        {
                 DataTable dt = new DataTable();
                DataSet ds = new DataSet();
            try
            {
              
               
                con = new SqlConnection(adress);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UrunListele";
                cmd.Parameters.AddWithValue("@CinsiyetAdi", u.CinsiyetAdi);
                cmd.Parameters.AddWithValue("@HediyeAmacAdi", u.HediyeAmaci);
                cmd.Parameters.AddWithValue("@YakinlikDerecesi", u.YakinlikDerecesi);
                cmd.Parameters.AddWithValue("@Yas", u.YasAraligi);
                cmd.Parameters.AddWithValue("@Burc", u.BurcAdi);
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dap.Fill(ds);

                //dt = ds.Tables[0];
                int x = 0;
                


            }

            catch (Exception ex)
            {

                ex.ToString();
            }
            finally
            {
                con.Close();

            }
            return ds.Tables[0];


        }

    }
}
