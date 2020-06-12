using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models
{
    public class TalepFiltreModel
    {
        public List<TalepDurum> TalepDurumListe { get; set; }

        public List<Sube> SubeListe { get; set; }

        public string TalepDurum { get; set; }

        public int SubeId { get; set; }

        public DateTime FiltreTarih1 { get; set; }

        public DateTime FiltreTarih2 { get; set; }

    }

    public class TalepDurum
    {
        public string DurumId { get; set; }
        public string DurumAdi { get; set; }

    }

    public class Sube
    {
        public int SubeId { get; set; }

        public string SubeAdi { get; set; }
    }
    
}
