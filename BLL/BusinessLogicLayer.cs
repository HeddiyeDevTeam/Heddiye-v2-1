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

        public int UrunKontrol(string UrunAdi,string CinsiyetAdi,string HediyeAmaci,string YakinlikDerecesi, string YasAraligi,string BurcAdi)
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

        //public DataTable DBListesindenUrunAl()
        //{

            
        //    DataTable diablo = dal.UrunListele();

        //    return diablo;
        //}


    }
}
