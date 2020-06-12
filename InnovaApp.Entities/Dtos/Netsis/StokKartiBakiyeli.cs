using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.Entities.Dtos.Netsis
{
    public class StokKartiBakiyeli
    {
        public string StokKodu { get; set; }

        public string StokAdi { get; set; }

        //public string GrupKodu { get; set; }
        //
        //public string Kod1 { get; set; }
        //
        //public string Kod2 { get; set; }
        //
        //public string Kod3 { get; set; }
        //
        //public string Kod4 { get; set; }

        public string OlcuBr { get; set; }

        public decimal? Miktar { get; set; }

        //public decimal? SatisFiyat { get; set; }
    }
}
