using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.CariRapor
{
    public class CariRaporListeFiltreModel
    {
        public string CariGrupKod { get; set; }

        public string CariRaporKod1 { get; set; }

        public string CariAdi { get; set; }

        public decimal MinBakiye { get; set; }
        public decimal MaxBakiye { get; set; }
    }
}
