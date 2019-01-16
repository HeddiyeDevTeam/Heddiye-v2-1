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

        public string UrunEkle( string cadi)
        {
            string d;
            CinsiyetTablo u = new CinsiyetTablo();
            u.CinsiyetAdi = cadi;
            dal.deneme(u);
          
        }
    }
}
