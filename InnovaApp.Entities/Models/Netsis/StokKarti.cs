using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("TBLSTSABIT")]
    public class StokKarti
    {
        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("GRUP_KODU")]
        public string GrupKodu { get; set; }

        [Column("KOD_1")]
        public string Kod1 { get; set; }

        [Column("KOD_2")]
        public string Kod2 { get; set; }

        [Column("KOD_3")]
        public string Kod3 { get; set; }

        [Column("KOD_4")]
        public string Kod4 { get; set; }

        [Column("OLCU_BR1")]
        public string OlcuBr { get; set; }

        [Column("SATIS_FIAT1")]
        public decimal? SatisFiyat { get; set; }

        [Column("KDV_ORANI")]
        public decimal? KdvSatis { get; set; }

        [Column("DOV_SATIS_FIAT")]
        public decimal? DovizSatisFiyat { get; set; }

        [Column("SAT_DOV_TIP")]
        public byte SatisDovizTip { get; set; }
        public string SatisDovizAdi { get {
                if (SatisDovizTip == 1) return "USD";
                else if (SatisDovizTip == 2) return "EUR";
                else return "TL";
            } }

    }
}
