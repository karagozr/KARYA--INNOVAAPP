using InnovaApp.Entities.Models.OgrenciServis.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis
{
    /*
    [dbo].[TBLOGRENCI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [nvarchar](500) NULL,
    [DURUM] [bit] NULL,
	[OKUL_ID] [int] NULL,
	[OGRENCI_TC_NO] [nvarchar](50) NULL,
	[OGRENCI_ADI] [nvarchar](50) NULL,
	[OGRENCI_SOYADI] [nvarchar](50) NULL,
	[BOLGE_ID] [int] NULL,
	[ADRES] [nvarchar](500) NULL,
	[ACIKLAMA] [nvarchar](500) NULL,
     */
    [Table("TBLTAHAKKUK")]
    public class Tahakkuk
    {
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("GUID")]
        [Key]
        public string Guid { get; set; }

        [Column("TAHAKKUK_TARIH")]
        public DateTime TahakkukTarih { get; set; }

        [Column("OGRENCI_ID")]
        public int OgrenciId { get; set; }

        [Column("HIZMET_TUTAR")]
        public decimal HizmetTutar { get; set; }

        [Column("INDIRIM_ADI")]
        public string IndirimAdi { get; set; }

        [Column("INDIRIM_TUTAR")]
        public decimal IndirimTutar { get; set; }

        [Column("ODENECEK_TUTAR")]
        public decimal OdenecekTutar { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }

        [Column("TAKSIT_SAYISI")]
        public int TaksitSayisi { get; set; }

        public Ogrenci Ogrenci { get; set; }
    }


    [Table("TBLTAHAKKUK_DETAY")]
    public class TahakkukDetay
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("GUID")]
        public string Guid { get; set; }

        [ForeignKey("Tahakkuk")]
        [Column("TAHAKKUK_GUID")]
        public string TahakkukGuid { get; set; }

        [Column("TARIH")]
        public DateTime Tarih { get; set; }

        [Column("OGRENCI_ID")]
        public int OgrenciId { get; set; }

        [Column("ALACAK")]
        public decimal Alacak { get; set; }

        [Column("BORC")]
        public decimal Borc { get; set; }

        [Column("BAKIYE")]
        public decimal Bakiye { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }

        [Column("ODEME_TUR")]
        public OdemeTur OdemeTur { get; set; } = OdemeTur.Nakit;

        [Column("BANKA_AD")]
        public string BankaAd { get; set; }

        [Column("CARI_ID")]
        public string CariId { get; set; }

        [Column("FATURA_TUR")]
        public FaturaTur FaturaTur { get; set; }

        [Column("TC_VERGI_NO")]
        public string TcVergiNo { get; set; }

        [Column("FATURA_BASLIK")]
        public string FaturaBaslik { get; set; }

        [Column("FATURA_ADRES")]
        public string FaturaAdres { get; set; }

        [Column("FATURA_KESILDI")]
        public bool FaturaKesildi { get; set; }
  
        public Tahakkuk Tahakkuk { get; set; }
        public Ogrenci Ogrenci { get; set; }

    }

}
