using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace KullaniciEkrani
{
    public partial class AdminLogin : Form
    {
        BusinessLogicLayer bll;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int deg;
            bll = new BusinessLogicLayer();
            deg = bll.AdminBoslukKontrol(textBox1.Text, textBox2.Text);
            if (deg>0)
            {
                UrunGirisEkrani urunGirisEkrani = new UrunGirisEkrani();
                urunGirisEkrani.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ercan hocam siz misiniz?");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anaform = new Form1();
            anaform.Show();
            this.Hide();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
