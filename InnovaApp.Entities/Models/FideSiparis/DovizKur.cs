using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_DOVIZ_KUR")]
    public class DovizKur
    {
        [Column("SIRA")]
        public int Sira { get; set; }

        [Column("DOVIZ")]
        public string Doviz { get; set; }

        [Column("KUR")]
        public double Kur { get; set; }
    }
}
