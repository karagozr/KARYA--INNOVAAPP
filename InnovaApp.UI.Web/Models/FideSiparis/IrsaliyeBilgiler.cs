using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.FideSiparis
{
    public class IrsaliyeBilgilerModel
    {
        public string IrsaliyeNo    { get; set; }
        public string BelgeNo       { get; set; }
        public string PlakaNo       { get; set; }                     
        public string SoforAd       { get; set; }              
        public string SoforSoyad    { get; set; }
        public string SoforTckn     { get; set; }
        public string Aciklama      { get; set; }
        public string CariVkn       { get; set; }
        public string CariUnvan     { get; set; }
        public string CariIl        { get; set; }
        public string CariIlce      { get; set; }
        public string Ulke          { get; set; }
        public string PostaKodu     { get; set; }
        public DateTime Tarih       { get; set; }
        public DateTime SevkTarih   { get; set; }
        public string Aciklama1     { get; set; }
        public string Aciklama2     { get; set; }
        public string Aciklama3     { get; set; }
        public string Aciklama4     { get; set; }
        public List<IrsaliyeDetayBilgilerModel> IrsaliyeDetayBilgiler { get; set; }
    }

    public class IrsaliyeDetayBilgilerModel
    {
        public short Sira { get; set; }
        public double Miktar { get; set; }

    }
}
