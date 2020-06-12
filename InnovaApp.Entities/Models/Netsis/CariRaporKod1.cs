using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_CARI_KOD1")]
    public class CariRaporKod1
    {
        [Column("GRUP_KODU")]
        public string RaporKod { get; set; }
        [Column("GRUP_ISIM")]
        public string RaporIsim { get; set; }
    }
}
