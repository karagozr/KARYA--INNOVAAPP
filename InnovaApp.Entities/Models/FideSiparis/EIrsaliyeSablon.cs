using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("TBLEIRSABLON")]
    public class EIrsaliyeSablon
    {

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }

        [Column("LICENSEPLATEID")]
        public string PlakaNo { get; set; }

        [Column("CARRIERVKN")]
        public string CariVknNo { get; set; }

        [Column("CARRIERNAME")]
        public string CariUnvan { get; set; }

        [Column("CARRIERSUBCITY")]
        public string CariIlce { get; set; }

        [Column("CARRIERCITY")]
        public string CariIl { get; set; }

        [Column("DPERSON1FIRSTNAME")]
        public string SoforAd { get; set; }

        [Column("DPERSON1FAMILYNAME")]
        public string SoforSoyad { get; set; }

        [Column("DPERSON1NID")]
        public string SoforTckn { get; set; }

        [Column("CARRIERPOSTAL")]
        public string PostaKodu { get; set; }

        [Column("CARRIERCOUNTRY")]
        public string Ulke { get; set; }

    }
}
