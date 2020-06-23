using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models
{
    public class MotoSiparisModel
    {
        public string aciklama { get; set; }
        public string musteriAdi { get; set; }
        public string belgeNo { get; set; }
        public DateTime tarih { get; set; }
        public List<MotoSiparisDetayModel> detay { get; set; }
    }

    public class MotoSiparisDetayModel
    {
        public string aciklama { get; set; }
        public string doviz { get; set; }
        public decimal fiyat { get; set; }
        public string id { get; set; }
        public decimal miktar { get; set; }
        public string stokAd { get; set; }
        public string stokKod { get; set; }  
        public decimal tutar { get; set; }
    }
}
