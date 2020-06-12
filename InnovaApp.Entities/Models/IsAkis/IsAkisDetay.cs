using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InnovaApp.Entities.Models.IsAkis
{
    public class IsAkisDetay
    {
        public int Akis_Id { get; set; }

        public int Sira { get; set; }

        public int Kullanici { get; set; }

        public string Kullanici_Adi { get; set; }

        public DateTime Kayit_Tarihi { get; set; }

        public string Durum { get; set; }


    }
}
