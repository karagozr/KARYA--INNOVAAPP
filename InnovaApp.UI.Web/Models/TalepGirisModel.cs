using InnovaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models
{
    public class TalepGirisModel
    {
        public int SubeId { get; set; }
        public string BelgeNo { get; set; }

        public DateTime Tarih { get; set; }

        public string Aciklama { get; set; }

        public string TalepDurum { get; set; }

        public BelgeKayit BelgeKayit { get; set; }

        public List<BelgeKayit> BelgeKayitListe { get; set; }
        public List<Stok> StokListe { get; set; }
    }

    public class Stok
    {
        public string StokKodu { get; set; }

        public string StokAdi { get; set; }

        public string Birim { get; set; }
    }
}
