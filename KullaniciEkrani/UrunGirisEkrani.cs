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
using DAL.Tablo_Sınıfları;
using Dapper;
using DAL;
using BLL;


namespace KullaniciEkrani
{
    public partial class UrunGirisEkrani : Form
    {
        
        public UrunGirisEkrani()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        SqlConnection con;
        private void UrunGirisEkrani_Load(object sender, EventArgs e)
        {
            string adress = "Data Source=.;Initial Catalog=Heddiye;Integrated Security=True";

            con = new SqlConnection(adress);

            // VeriTabanindaki Cinsiyetleri Combobox1'a Ekler
            var GelenCinsiyet = con.Query<CinsiyetTablo>("Select * from Cinsiyet");
            comboBox1.DataSource = GelenCinsiyet;
            comboBox1.DisplayMember = "CinsiyetAdi";
            comboBox1.ValueMember = "CinsiyetId";

            // VeriTabanindaki Hediye Amaclarini Combobox2'a Ekler
            var GelenHediyeAmaci = con.Query<HediyeAmaciTablo>("Select * from HediyeAmaci");
            comboBox2.DataSource = GelenHediyeAmaci;
            comboBox2.DisplayMember = "HediyeAmaci";
            comboBox2.ValueMember = "HediyeAmacId";

            // VeriTabanindaki Yas Araligini Combobox'3 e Ekler
            var GelenYasAraligi = con.Query<YasAraligiTablo>("select * from YasAraligi");
            comboBox3.DataSource = GelenYasAraligi;
            
            comboBox3.DisplayMember = "YasAraligi";
            comboBox3.ValueMember = "YasId";

            // VeriTabanindaki Burclari Combobox5'e Ekler
            var GelenBurc = con.Query<BurcTablo>("select * from Burc");
            comboBox5.DataSource = GelenBurc;
            comboBox5.DisplayMember = "BurcAdi";
            comboBox5.ValueMember = "BurcId";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // VeriTabanindaki Yakinlik Derecesini Combobox4'a Ekler

            int CId = comboBox1.SelectedIndex + 1;
           
            var YakinlikDerecesi = con.Query<YakinlikDerecesiTablo>("Select * from YakinlikDerecesi where CinsiyetId = @CinsiyetId", new { @CinsiyetId = CId });


            comboBox4.DataSource = YakinlikDerecesi;
            comboBox4.DisplayMember = "YakinlikDerecesi";
            comboBox4.ValueMember = "YakinlikId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Ukontrol = 0;
            Ukontrol = bll.UrunKontrol(textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox4.Text, comboBox3.Text, comboBox5.Text);

            if (Ukontrol > 0)
            {
                MessageBox.Show("UrunEklendi");
            }
            else
            {
                MessageBox.Show("Urun Eklenemedi!!");
            }
          
        }
    }
}
