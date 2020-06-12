using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models
{
    [Table("TBLPARAMETRE_GENEL")]
    public class Parametreler
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("PARAMETRE")]
        public string Parametre { get; set; }

        [Column("DEGER")]
        public string Deger { get; set; }
    }
}
