using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models
{
    [Table("TBLBELGE_KAYIT_WEB")]
    public class BelgeKayit
    {

        [Column("ID")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Column("GUID")]
        public string Guid { get; set; }

        [Column("SIRA")]
        public int Sira { get; set; }

        [Column("SUBE_KODU")]
        public int Sube { get; set; }


        [Column("BELGE_NO")]
        public string BelgeNo { get; set; }

        [Column("TARIH")]
        public DateTime Tarih { get; set; }


        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("STOK_ADI")]
        public string StokAdi { get; set; }

        [Column("BIRIM")]
        public string Birim { get; set; }

        [Column("MIKTAR")]
        public decimal Miktar { get; set; }

        [Column("BELGE_ONAY")]
        public string BelgeDurum { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }
    }
}
