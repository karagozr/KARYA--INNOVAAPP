using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    public class Siparis
    {
        public string BelgeNo { get; set; }
        public DateTime Tarih { get; set; } 
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string Aciklama { get; set; }
        public string OnayDurum { get; set; }
        public string Il { get; set; } 
        public string Ilce { get; set; }
        public string Plasiyer { get; set; }

    }
}
