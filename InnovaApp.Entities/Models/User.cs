using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models
{
    [Table("TBLKULLANICI")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("KULLANICI")]
        public string Kullanici { get; set; }
        [Column("SIFRE")]
        public string Sifre { get; set; }

        [Column("DEPO")]
        public string Depo { get; set; }

        [Column("PLASIYER_KODU")]
        public string PlasiyerKodu { get; set; }

        [Column("YETKILI_CARI_KODU")]
        public string UserCariKodu { get; set; }

    }
}
