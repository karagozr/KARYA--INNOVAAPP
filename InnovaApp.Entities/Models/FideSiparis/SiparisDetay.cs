using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_SIPARIS_KALEM")]
    public class SiparisDetay
    {
        [Column("SIRA")]
        public Int16 Sira { get; set; }

        [Column("FATIRS_NO")]
        public string BelgeNo { get; set; }

        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("OLCU_BR1")]
        public string Birim { get; set; }

        [Column("MIKTAR")]
        public decimal Miktar { get; set; }

        [Column("KALAN_MIKTAR")]
        public decimal SiparisKalanMiktar { get; set; }
        //DOVIZ_KODU,DOVIZ_ADI,DOVIZ_KURU,NET_FIYAT,NET_TUTAR,DOVIZ_FIYAT,DOVIZ_TUTAR

        [Column("DOVIZ_KODU")]
        public int Doviz { get; set; }

        [Column("DOVIZ_ADI")]
        public string DovizAdi { get; set; }

        [Column("DOVIZ_KURU")]
        public int DovizKuru { get; set; }

        [Column("NET_FIYAT")]
        public decimal BirimFiyat { get; set; }

        [Column("DOVIZ_FIYAT")]
        public decimal BirimFiyatDoviz { get; set; }

        [Column("NET_TUTAR")]
        public decimal ToplamTutar { get; set; }

        [Column("DOVIZ_TUTAR")]
        public decimal ToplamTutarDoviz { get; set; }

        [Column("NOT1")]
        public string Aciklama { get; set; }
    }
}
