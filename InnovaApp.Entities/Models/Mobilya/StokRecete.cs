using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.Entities.Models.Mobilya
{
    public class StokRecete
    {
        public string MamulAdi          { get; set; }
        public string HamKodu           { get; set; }
        public string StokAdi           { get; set; }
        public decimal Miktar           { get; set; }
        public int    OzellikId         { get; set; }
        public string OzellikAciklama   { get; set; }
        public string DegerAciklama     { get; set; }

    }
}
