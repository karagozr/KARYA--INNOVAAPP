using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.IsAkis
{
    [Table("TBLISAKIS")]
    public class IsAkis
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Column("KULLANICI")]
        public long Kullanici { get; set; }

        [Column("AKIS_ID")]
        public long AkisId { get; set; }

        [Column("SIRA")]
        public long Sira { get; set; }
    }
}
