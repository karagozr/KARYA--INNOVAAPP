using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("INN_VW_CARI_GRUP")]
    public class CariGrup
    {
        [Column("GRUP_KODU")]
        public string GrupKod { get; set; }
        [Column("GRUP_ISIM")]
        public string GrupIsim { get; set; }
    }
}
