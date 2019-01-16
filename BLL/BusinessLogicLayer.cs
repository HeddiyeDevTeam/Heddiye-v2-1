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
  //string d ifadesi silindi. @Erkan          
            CinsiyetTablo u = new CinsiyetTablo();
            u.CinsiyetAdi = cadi;
            dal.deneme(u);
//return cadi ifadesi eklendi. @Erkan
            return cadi;
          
        }
    }
}
