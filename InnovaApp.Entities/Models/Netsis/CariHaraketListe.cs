using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_CARI_HAR_WEB")]
    public class CariHaraket
    {
        [Column("LOGICALREF")]
        public string Logicalref { get; set; }
        [Column("CARI_KODU")]
        public string CariKodu { get; set; }
        [Column("CARI_ADI")]
        public string CariAdi { get; set; }
        [Column("TARIH")]
        public DateTime Tarih { get; set; }
        [Column("BORC")]
        public decimal Borc { get; set; }
        [Column("VADE_TARIHI")]
        public DateTime VadeTarih { get; set; }
        [Column("ALACAK")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Alacak { get; set; }
        [Column("BAKIYE")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Bakiye { get; set; }
        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }
        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }
        [Column("INC_KEY_NUMBER")]
        public int IncKeyNumber { get; set; }
        [Column("HAREKET_TURU")]
        public string HaraketTuru { get; set; }

    }
}
