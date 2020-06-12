using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_TEKLIF_KALEM")]
    public class TeklifDetay
    {
        [Column("BELGEGUID")]
        public string BelgeNo { get; set; }

        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("BIRIM")]
        public string Birim { get; set; }

        [Column("MIKTAR")]
        public decimal Miktar { get; set; }

        [Column("DOVIZ_KODU")]
        public int Doviz { get; set; }

        [Column("DOVIZ_ADI")]
        public string DovizAdi { get; set; }

        [Column("DOVIZ_KURU")]
        public int DovizKuru { get; set; }

        [Column("BRUT_FIYAT")]
        public decimal BirimFiyat { get; set; }

        [Column("DOVIZ_FIYAT")]
        public decimal BirimFiyatDoviz { get; set; }

        [Column("BRUT_TUTAR")]
        public decimal ToplamTutar { get; set; }

        [Column("DOVIZ_TUTAR")]
        public decimal ToplamTutarDoviz { get; set; }

        [Column("NOT1")]
        public string Aciklama { get; set; }
    }
}
