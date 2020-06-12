using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis
{
    /*
    [dbo].[TBLOGRENCI_BOLGE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BOLGE_KODU] [nvarchar](50) NULL,
	[BOLGE_ADI] [nvarchar](50) NULL,
	[ACIKLAMA] [nvarchar](500) NULL,
     */
    [Table("TBLOGRENCI_BOLGE")]
    public class OgrenciBolge   
    {

        [Column("ID")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("BOLGE_KODU")]
        public string BolgeKodu { get; set; }

        [Column("BOLGE_ADI")]
        public string BolgeAdi { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }
    }
}
