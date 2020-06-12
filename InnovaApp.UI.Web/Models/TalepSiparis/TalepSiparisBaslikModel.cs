using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.TalepSiparis
{
    public class TalepSiparisBaslikModel
    {
        public int SubeId { get; set; }
        public string BelgeNo { get; set; }

        public DateTime Tarih { get; set; }

        public string Aciklama { get; set; }

        public string TalepDurum { get; set; }
    }
}
