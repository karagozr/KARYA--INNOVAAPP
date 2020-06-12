using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.TalepSiparis
{
    public class SiparisTalepFiltreModel
    {
        public int SubeId { get; set; }

        public string SiparisDurum { get; set; }

        public DateTime Tarih1 { get; set; }

        public DateTime Tarih2 { get; set; }

    }
}
