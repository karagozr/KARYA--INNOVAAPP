﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_STOK_KOD5")]
    public class StokGrup
    {
        [Column("GRUP_KODU")]
        public string GrupKodu { get; set; }

        [Column("GRUP_ISIM")]
        public string GrupIsim { get; set; }
    }
}
