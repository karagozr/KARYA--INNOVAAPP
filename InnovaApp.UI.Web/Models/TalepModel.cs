using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models
{
    public class TalepModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public int Sira { get; set; }

        public string BelgeNo { get; set; }

        public DateTime Tarih { get; set; }

        public string StokKodu { get; set; }

        public string StokAdi { get; set; }

        public string Birim { get; set; }

        public decimal Miktar { get; set; }
    }
}
