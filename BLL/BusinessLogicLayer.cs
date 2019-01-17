using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Tablo_Sınıfları;

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

            return UrunKontrol;
        }
    }
}
