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
using System.Diagnostics;

namespace KullaniciEkrani
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }
        // Diğer Sınıflardan nesnelerimiz tanımlandı.
        BusinessLogicLayer bll;
        DataAccessLayer dal;
        SqlConnection con;
      
        private void btnadmin_Click(object sender, EventArgs e)
        {
            // Admin Login Sayfamız için bir nesne oluşturduk.
            AdminLogin adminLogin = new AdminLogin();
            // oluşan nesne gösterildi şuanki form gizlendi.
            adminLogin.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //BusinessLogicLayer sınıfından nesnemizi new ettik.
            bll = new BusinessLogicLayer();
            DataTable dt;
            try
            {
                dt = bll.ULComboControl(cmbCinsiyet.Text, cmbYasAraligi.Text, cmbBurc.Text, cmbHediyeAmac.Text, cmbYakinlikDerecesi.Text);
                libUrunler.DataSource = dt;
                libUrunler.DisplayMember = "UrunAdi";
                libUrunler.ValueMember = "UrunId";
            }
            catch (Exception ex)
            {
                //oluşan hataları database gönderir
                HataLog h = new HataLog();
                h.message = ex.StackTrace;
                bll.HataGonder(h);
                MessageBox.Show("Seçtiğiniz bilgilere ait ürün bilgiler bulunmamaktadır. ");
            }
            // bll sınıfındaki ULCombo kontrol fonksiyonu cağırıldı gelen datatable yeni oluşturaln data
            // tableye atıldı
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // VeriTabanindaki Cinsiyetleri Combobox1'a Ekler
     
            bll = new BusinessLogicLayer();
            DataSet ds = bll.getCombo();
            cmbCinsiyet.DataSource = ds.Tables[0];
            
            cmbCinsiyet.DisplayMember = "CinsiyetAdi";
            cmbCinsiyet.ValueMember = "CinsiyetId";
            cmbCinsiyet.Text = "Cinsiyet?";
            // VeriTabanindaki Hediye Amaclarini Combobox2'a Ekler
           // var GelenHediyeAmaci = con.Query<HediyeAmaciTablo>("Select * from HediyeAmaci");
            cmbHediyeAmac.DataSource = ds.Tables[2];
            cmbHediyeAmac.DisplayMember = "HediyeAmaci";
            cmbHediyeAmac.ValueMember = "HediyeAmacId";
            cmbHediyeAmac.Text = "Hediye";
            // VeriTabanindaki Yas Araligini Combobox'3 e Ekler
            //var GelenYasAraligi = con.Query<YasAraligiTablo>("select * from YasAraligi");
            cmbYasAraligi.DataSource = ds.Tables[3];
            cmbYasAraligi.DisplayMember = "YasAraligi";
            cmbYasAraligi.ValueMember = "YasId";

            // VeriTabanindaki Burclari Combobox5'e Ekler
            //var GelenBurc = con.Query<BurcTablo>("select * from Burc");
            cmbBurc.DataSource = ds.Tables[1];
            cmbBurc.DisplayMember = "BurcAdi";
            cmbBurc.ValueMember = "BurcId";
        }

        private void cmbCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CId = cmbCinsiyet.SelectedIndex + 1;

            //var YakinlikDerecesi = con.Query<YakinlikDerecesiTablo>("Select ** from YakinlikDerecesi where CinsiyetId = @CinsiyetId", new { @CinsiyetId = CId });

            DataSet ds = bll.getYakinlik(CId);
            cmbYakinlikDerecesi.DataSource = ds.Tables[0];
            cmbYakinlikDerecesi.DisplayMember = "YakinlikDerecesi";
            cmbYakinlikDerecesi.ValueMember = "YakinlikId";
            cmbYakinlikDerecesi.Text = "Yakınlık Dereceniz Nedir?";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(libUrunler.SelectedValue.ToString());
            int ID = (int)libUrunler.SelectedValue;
            bll = new BusinessLogicLayer();
            string link = bll.GetLinkAccess(ID);
            Process.Start(link);
        }
    }
}
