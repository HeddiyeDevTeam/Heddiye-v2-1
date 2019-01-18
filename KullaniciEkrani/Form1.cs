using DAL.Tablo_Sınıfları;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DAL;
using BLL;
namespace KullaniciEkrani
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer bll;

        public Form1()
        {
            InitializeComponent();
        }
        DataAccessLayer dal;
        SqlConnection con;
        
        
        private void btnadmin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer();
            DataTable dt;
            
       dt= bll.ULComboControl(cmbCinsiyet.Text, cmbYasAraligi.Text, cmbBurc.Text, cmbHediyeAmac.Text, cmbYakinlikDerecesi.Text);
            libUrunler.DataSource = dt;
            libUrunler.DisplayMember = "UrunAdi";
            libUrunler.ValueMember = "UrunId";




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";

            con = new SqlConnection(adress);

            // VeriTabanindaki Cinsiyetleri Combobox1'a Ekler
            var GelenCinsiyet = con.Query<CinsiyetTablo>("Select * from Cinsiyet");
            
            cmbCinsiyet.DataSource = GelenCinsiyet;
            
            cmbCinsiyet.DisplayMember = "CinsiyetAdi";
            cmbCinsiyet.ValueMember = "CinsiyetId";
            cmbCinsiyet.Text = "Cinsiyet?";
            // VeriTabanindaki Hediye Amaclarini Combobox2'a Ekler
            var GelenHediyeAmaci = con.Query<HediyeAmaciTablo>("Select * from HediyeAmaci");
            cmbHediyeAmac.DataSource = GelenHediyeAmaci;
            cmbHediyeAmac.DisplayMember = "HediyeAmaci";
            cmbHediyeAmac.ValueMember = "HediyeAmacId";
            cmbHediyeAmac.Text = "Hediye";
            // VeriTabanindaki Yas Araligini Combobox'3 e Ekler
            var GelenYasAraligi = con.Query<YasAraligiTablo>("select * from YasAraligi");
            cmbYasAraligi.DataSource = GelenYasAraligi;
            cmbYasAraligi.DisplayMember = "YasAraligi";
            cmbYasAraligi.ValueMember = "YasId";

            // VeriTabanindaki Burclari Combobox5'e Ekler
            var GelenBurc = con.Query<BurcTablo>("select * from Burc");
            cmbBurc.DataSource = GelenBurc;
            cmbBurc.DisplayMember = "BurcAdi";
            cmbBurc.ValueMember = "BurcId";
        }

        private void cmbCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CId = cmbCinsiyet.SelectedIndex + 1;

            var YakinlikDerecesi = con.Query<YakinlikDerecesiTablo>("Select * from YakinlikDerecesi where CinsiyetId = @CinsiyetId", new { @CinsiyetId = CId });


            cmbYakinlikDerecesi.DataSource = YakinlikDerecesi;
            cmbYakinlikDerecesi.DisplayMember = "YakinlikDerecesi";
            cmbYakinlikDerecesi.ValueMember = "YakinlikId";
        }
    }
}
