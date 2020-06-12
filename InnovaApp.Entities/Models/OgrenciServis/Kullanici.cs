using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.OgrenciServis
{
    [Table("TBLKULLANICI")]
    public class Kullanici
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("KULLANICI")]
        public string KullaniciAdi { get; set; }
        [Column("SIFRE")]
        public string Sifre { get; set; }

    }
}
