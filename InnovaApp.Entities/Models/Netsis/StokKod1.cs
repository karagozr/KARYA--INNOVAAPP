using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_STOK_KOD1")]
    public class StokKod1
    {
        [Column("GRUP_KODU")]
        public string GrupKodu { get; set; }

        [Column("GRUP_ISIM")]
        public string GrupIsim { get; set; }
    }
}
