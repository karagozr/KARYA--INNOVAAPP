using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_FATURA_KALEM")]
    public class FaturaKalem
    {
        [Column("SIRA")]
        public short Sira { get; set; }

        [Column("CARI_KODU")]
        public string CariKodu { get; set; }

        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }

        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("BIRIM")]
        public string Birim { get; set; }

        [Column("MIKTAR")]
        public decimal Miktar { get; set; }

        [Column("TOPLAM_TUTAR")]
        public decimal ToplamTutar { get; set; }


    }
}
