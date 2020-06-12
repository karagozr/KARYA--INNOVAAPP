using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_SIPARIS_IRSALIYE_DURUMU")]
    public class SiparisIrsaliyeDurum
    {
        [Column("FISNO")]
        public string BelgeNo { get; set; }

        [Column("STHAR_TARIH")]
        public DateTime Tarih { get; set; }

        [Column("SIPARIS_DURUM")] 
        public char Durum { get; set; }
    }
}
