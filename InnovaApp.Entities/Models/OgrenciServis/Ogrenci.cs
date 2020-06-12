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
    [Table("TBLOGRENCI")]
    public class Ogrenci   
    {

        [Column("ID")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("GUID")]
        public string Guid { get; set; }

        [Column("DURUM")]
        public bool Durum { get; set; }

        [Column("OKUL_ID")]
        public int OkulId { get; set; }

        [Column("SINIF")]
        public string Sinif { get; set; }

        [Column("OGRENCI_TC_NO")]
        public string OgrenciTcNo { get; set; }

        [Column("OGRENCI_ADI")]
        public string OgrenciAdi { get; set; }

        [Column("OGRENCI_SOYADI")]
        public string OgrenciSoyadi { get; set; }

        [Column("BOLGE_ID")]
        public int BolgeId { get; set; }

        [Column("ADRES")]
        public string Adres { get; set; }

        [Column("ACIKLAMA")]

        public string Aciklama { get; set; }

        [Column("KAYIT_TARIHI")]

        public DateTime KayitTarihi { get; set; }


        public Okul Okul { get; set; }

        public OgrenciBolge Bolge { get; set; }


    }
}
