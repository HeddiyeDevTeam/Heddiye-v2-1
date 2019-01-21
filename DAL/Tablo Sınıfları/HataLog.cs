using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tablo_Sınıfları
{
   public class HataLog
    {
        public string DosyaAdi { get; set; }
        public string MethodAdi { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string message { get; set; }
    }
}
