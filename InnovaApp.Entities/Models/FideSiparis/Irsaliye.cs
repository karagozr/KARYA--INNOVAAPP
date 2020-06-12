using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("TBLSTHAR")]
    public class Irsaliye
    {
        //SELECT SIRA,FISNO FROM TBLSTHAR
        [Column("FISNO")]
        public string BelgeNo { get; set; }

        [Column("SIRA")]
        public short Sira { get; set; }

    }
}
