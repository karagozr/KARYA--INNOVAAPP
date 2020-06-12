using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_TEKLIF_UST")]
    public class TeklifBaslik
    {
        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }

        [Column("TARIH")]
        public DateTime Tarih { get; set; }

        [Column("CARI_KODU")]
        public string CariKodu { get; set; }

        [Column("CARI_ISIM")]
        public string CariAdi { get; set; }

        [Column("ACIKLAMA1")]
        public string Aciklama { get; set; }

        [Column("ACIKLAMA2")]
        public string Aciklama2 { get; set; }

        [Column("ACIKLAMA3")]
        public string Aciklama3 { get; set; }

        [Column("ONAYTIPI")]
        public string OnayDurum { get; set; }

        [Column("CARI_IL")]
        public string Il { get; set; }

        [Column("ILCE")]
        public string Ilce { get; set; }

        [Column("PLASIYER_KODU")]
        public string Plasiyer { get; set; }

    }
}
