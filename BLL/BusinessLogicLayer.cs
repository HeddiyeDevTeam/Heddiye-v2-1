using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Tablo_Sınıfları;
using System.Data;

namespace BLL
{
    
    public class BusinessLogicLayer
    {
        DataAccessLayer dal;

        public BusinessLogicLayer()
        {
            dal = new DataAccessLayer();
        }
        public int UrunKontrol(string UrunAdi,string CinsiyetAdi,string HediyeAmaci,string YakinlikDerecesi, string YasAraligi,string BurcAdi,string link)
        {
            int UrunKontrol = 0;

            Urunler u = new Urunler();
            if (!string.IsNullOrEmpty(UrunAdi))
            {
                u.UrunAdi = UrunAdi;
                u.CinsiyetAdi = CinsiyetAdi;
                u.HediyeAmaci = HediyeAmaci;
                u.YakinlikDerecesi = YakinlikDerecesi;
                u.YasAraligi = YasAraligi;
                u.BurcAdi = BurcAdi;
                u.Link = link;
                
              

                if (dal.UrunEkle(u) > 0)
                {
                    UrunKontrol = 1;
                }
            }
            else
            {
                UrunKontrol = 0;
            }
           
            

            return UrunKontrol;
        }
        //Ürün Listelemede yer alan Comboboxlarda herhangi bir seçim olup olmadığının kontrolü.
        public DataTable ULComboControl(string Cinsiyetadi, string YasAraligiDegeri, string Burcadi, string HediyeAmacAdi, string YakinlikDerecesiDegeri)
        {
            DataTable d = new DataTable();
          
            Urunler u = new Urunler();

            if (!(string.IsNullOrEmpty(Cinsiyetadi) && (string.IsNullOrEmpty(YasAraligiDegeri))))
            {
                u.CinsiyetAdi = Cinsiyetadi;
                u.YasAraligi = YasAraligiDegeri;
                u.BurcAdi = Burcadi;
                u.HediyeAmaci = HediyeAmacAdi;
                u.YakinlikDerecesi = YakinlikDerecesiDegeri;

                 d = dal.UrunListele(u);
             
                
            }
            return d;
        }
        public int AdminBoslukKontrol(string email, string sifre)
        {
            int a;
            //Admin login sayfasında e-mail ve şifre için boşluk kontrolü
            if (!string.IsNullOrEmpty(email)&&!string.IsNullOrEmpty(sifre))
            {
                AdminTablo admt = new AdminTablo();
                admt.Email = email;
                admt.Sifre = sifre;
                a = dal.AdminBilgileriSorgula(admt);

            }
            else
            {
                a = 0;
            }

            return a;
           
        }
        public void HataGonder(HataLog ex)
        {  //hatalogunu dataaccesslayerdan alarak form ekranında kullanmak için bu method yazıldı.
            dal.HataGonder(ex);
        }
        public string GetLinkAccess(int ID)
        {
            string link = "";
            if (ID> 0)
            {
                dal = new DataAccessLayer();
                link = dal.GetLinkData(ID);
            }
            return link;
        }
        public DataSet getCombo()
        {
            dal = new DataAccessLayer();
            DataSet ds = dal.ComboGet();
            return ds;

        }
        public DataSet getYakinlik(int id)
        {
            dal = new DataAccessLayer();
            DataSet ds = dal.getYakinlikDerecesi(id);
            return ds;

        }
    }
}
