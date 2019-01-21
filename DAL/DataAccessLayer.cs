using DAL.Tablo_Sınıfları;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Diagnostics;
using System.IO;

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

        static string adress = "Data Source=.\\SQLEXPRESS;Initial Catalog=Heddiye;Integrated Security=True";

        public int UrunEkle(Urunler u)
        {

            int SorguKontrol = 0;

            string adress = "Data Source=.\\SQLEXPRESS;Initial Catalog=Heddiye;Integrated Security=True";
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
                //int x = 0;



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

        public int AdminBilgileriSorgula(AdminTablo adminTablo)
        {
            string email, sifre;
            int sorgu = 0;
            email = adminTablo.Email;
            sifre = adminTablo.Sifre;
            con = new SqlConnection(adress);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from Admin where email = '" + email + "' and sifre = '" + sifre + "'";
            var sonuc = cmd.ExecuteScalar();
            if (Convert.ToInt32(sonuc) > 0)
            {
                sorgu = 1;
            }
            con.Close();


            return sorgu;
        }
        //Hata kontrolünü bu alanda yapıyoruz.
        public void HataGonder(HataLog h)
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Heddiye;Integrated Security=True");


            //Hatanın satır numarasına erişme için true değeri veriliyor.
            StackTrace st = new StackTrace(true);

            foreach (StackFrame frame in st.GetFrames())

            {
                string path3 = @"C:\Users\www\Source\Repos\Heddiye-v2-13\HProgram.cs";
                string result;
                result = Path.GetFileName(path3).Split(Path.DirectorySeparatorChar).Last();


                if (!string.IsNullOrEmpty(frame.GetFileName()))
                {
                    con.Execute("insert into HataLoglari (DosyaAdi,MethodAdi,LineNumber,ColumnNumber,message) values (@DosyaAdi,@MethodAdi,@LineNumber,@ColumnNumber,@message)", new
                    {
                        @DosyaAdi = result,
                        @MethodAdi = frame.GetMethod().ToString(),
                        @LineNumber = frame.GetFileLineNumber(),
                        @ColumnNumber = frame.GetFileColumnNumber(),
                        @message =h.message
                    });


                }

            }
        }
    }
}
