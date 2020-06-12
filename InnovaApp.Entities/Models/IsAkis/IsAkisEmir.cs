using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.IsAkis
{
    [Table("INN_VW_ISAKIS_SURECI_ODEME_EMRI")]
    public class IsAkisEmir
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Column("AKIS_ID")]
        public int AkisId { get; set; }

        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }

        [Column("DBNAME")]
        public string DbName { get; set; }

        [Column("CARI_ISIM")]
        public string CariIsim { get; set; }

        [Column("TARIH")]
        public DateTime Tarih { get; set; }

        [Column("NAKIT")]
        public decimal Nakit { get; set; }

        [Column("KREDI_KARTI")]
        public decimal KrediKarti { get; set; }

        [Column("HAVALE")]
        public decimal Havale { get; set; }

        [Column("CEK")]
        public decimal Cek { get; set; }

        [Column("CEK_VADE")]
        public DateTime? CekVade { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }

        [Column("ACIKLAMA2")]
        public string Aciklama2 { get; set; }

        [Column("UST_ACIKLAMA")]
        public string UstAciklama { get; set; }

        [Column("AKIS_SEVIYE")]
        public int AkisSeviye { get; set; }

        [Column("AKIS_TEKIL")]
        public int AkisTekil { get; set; }
        


    }
}
