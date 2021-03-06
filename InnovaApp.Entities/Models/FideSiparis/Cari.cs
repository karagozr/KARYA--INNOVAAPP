﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.FideSiparis
{
    [Table("INN_VW_CARI_KART_BAKIYELI")]
    public class Cari
    {
        [Column("CARI_KOD")]
        public string CariKod { get; set; }

        [Column("CARI_ISIM")]
        public string CariIsim { get; set; }

        [Column("CARI_IL")]
        public string Il { get; set; }

        [Column("CARI_ILCE")]
        public string Ilce { get; set; }

        [Column("CARI_ADRES")]
        public string Adres { get; set; }

        [Column("CARI_TEL")]
        public string TelNo { get; set; }

        [Column("EMAIL")]
        public string Eposta { get; set; }

        [Column("TOPLAM_RISKI")]
        public decimal ToplamRisk { get; set; }

        [Column("BAKIYE")]
        public decimal Bakiye { get; set; }

        [Column("VERGI_DAIRESI")]
        public string VergiDairesi { get; set; }


        [Column("VERGI_NUMARASI")]
        public string VergiNumarasi { get; set; }

        [Column("PLASIYER_KODU")]
        public string Plasiyer { get; set; }
    }
}
