using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_STOK_KART")]
    public class Stok
    {
        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("KOD_5")]
        public string GrupKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("OLCU_BR1")]
        public string OlcuBr { get; set; }

        [Column("SATIS_FIAT")]
        public decimal? SatisFiyat { get; set; }
        [Column("KDV_SATIS")]
        public decimal? KdvSatis { get; set; }

    }
}
