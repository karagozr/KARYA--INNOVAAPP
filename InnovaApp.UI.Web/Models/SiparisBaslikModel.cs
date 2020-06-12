using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models
{
    public class SiparisBaslikModel
    {
        public string BelgeNo   {get;set;}
        public string CariAdi   {get;set;}
        public string CariKodu  {get;set;}
        public DateTime Tarih     {get;set;}
        public string Musteri  {get;set;}
        public string Aciklama { get; set; }
        public string OnayDurumAciklama { get; set; }
        public string OnayDurum {get;set;}
        public string Il        {get;set;}
        public string Ilce      {get;set;}
        public string Plasiyer  { get; set; }
    }
}
