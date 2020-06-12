using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.Netsis
{
    [Table("TBLSTOKPH")]
    public class StokBakiye
    {
        [Column("STOK_KODU")]
        public string StokKodu { get; set; }

        [Column("TOP_GIRIS_MIK")]
        public decimal? ToplamGiris { get; set; }

        [Column("TOP_CIKIS_MIK")]
        public decimal? ToplamCikis { get; set; }

    }
}
