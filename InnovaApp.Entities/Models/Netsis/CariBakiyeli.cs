using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_CARI_KART_WEB")]
    public class CariBakiyeli
    {
        [Column("LOGICALREF")]
        public string Logicalref { get; set; }
        [Column("CARI_KODU")]
        public string CariKodu { get; set; }
        [Column("CARI_ADI")]
        public string CariAdi { get; set; }
        [Column("CARI_TIP")]
        public string CariTip { get; set; }
        [Column("CARI_GRUP")]
        public string CariGrup { get; set; }
        [Column("CARI_KOD1")]
        public string CariRaporKod1 { get; set; }
        [Column("CARI_KOD2")]
        public string CariRaporKod2 { get; set; }
        [Column("SUBE_KODU")]
        public Int16 SubeKodu { get; set; }
        [Column("PLASIYER_KODU")]
        public string PlasierKodu { get; set; }

        [Column("BAKIYE")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Bakiye { get; set; }
        [Column("CARI_IL")]
        public string CariIl { get; set; }
        [Column("CARI_ILCE")]
        public string CariIlce { get; set; }
        [Column("KILIT")]
        public string Kilit { get; set; }
        [Column("CARI_ADRES")]
        public string CariAdres { get; set; }
        [Column("CARI_TEL")]
        public string CariTel { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("VERGI_DAIRESI")]
        public string VergiDairesi { get; set; }
        [Column("VERGI_NUMARASI")]
        public string VergiNumarasi { get; set; }

        [Column("TOPLAM_RISKI")]
        public decimal Risk { get; set; }

    }
}
