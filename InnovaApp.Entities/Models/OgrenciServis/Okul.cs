using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis
{
    /*
     * [dbo].[TBLOKUL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [nvarchar](500) NULL,
	[DURUM] [bit] NULL,
	[OKUL_ADI] [nvarchar](500) NULL,
	[OKUL_KODU] [nvarchar](50) NULL,
	[PAROLA] [nvarchar](50) NULL,
	[ACIKLAMA] [nvarchar](500) NULL,
     */
    [Table("TBLOKUL")]
    public class Okul   
    {

        [Column("ID")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Column("GUID")]
        public string Guid { get; set; }


        [Column("DURUM")]
        public bool Durum { get; set; }


        [Column("OKUL_ADI")]
        public string OkulAdi { get; set; }

        [Column("OKUL_KODU")]
        public string OkulKodu { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }
    }
}
