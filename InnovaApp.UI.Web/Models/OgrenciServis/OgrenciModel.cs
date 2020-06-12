using InnovaApp.Entities.Models.OgrenciServis;
using InnovaApp.Entities.Models.OgrenciServis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.OgrenciServis
{
    public class OgrenciModel
    {
        public int OkulId { get; set; }

        public Ogrenci Ogrenci { get; set; }
        public List<Okul> OkulListesi { get; set; }

        public List<OgrenciBolge> OgreciBolgeListesi { get; set; }
        public List<OgrenciDto> OgrenciListesi { get; set; }

    }
}
