using InnovaApp.Entities.Models.Netsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.StokRapor
{
    public class StokAraModel
    {
        public List<StokGrubu> StokGruplar { get; set; }

        public List<StokKod1> StokKodlar1 { get; set; }

        public List<StokKod2> StokKodlar2 { get; set; }

        public List<StokKod3> StokKodlar3 { get; set; }

        public List<StokKod4> StokKodlar4 { get; set; }

    }
}
