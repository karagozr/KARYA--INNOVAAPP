using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.Entities.Models.Mobilya
{
    public class MobilyaSiparis
    {
        public string SiparisNo { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public DateTime UretimTarihi { get; set; }
        public string CariKod { get; set; }
        public string CariAd { get; set; }
    }                        
}
