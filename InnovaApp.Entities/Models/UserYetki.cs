using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models
{
    [Table("TBLKULLANICIYETKI")]
    public class UserYetki
    {
        [Key]
        [Column("LOGIC")]
        public int Logic { get; set; }

        [Column("ID")]
        public int Id { get; set; }

        [Column("USTID")]
        public int UstId { get; set; }

        [Column("ACIKLAMA")]
        public string Aciklama { get; set; }

        [Column("KULLANICI")]
        public int Kullanici { get; set; }

        [Column("YETKI")]
        public int Yetki { get; set; }

        [Column("DUZELTME")]
        public int Duzeltme { get; set; }

        [Column("SIL")]
        public int Sil { get; set; }

        [Column("AKTIF")]
        public int Aktif { get; set; }
    }
}
