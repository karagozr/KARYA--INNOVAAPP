using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.FideSiparis
{
    public class IrsaliyeBilgilerModel
    {
        public string IrsaliyeNo { get; set; }
        public string BelgeNo { get; set; }
        public string Aciklama2 { get; set; }                     
        public string Aciklama3 { get; set; }              
        public string Aciklama4 { get; set; }          
        public string Aciklama5 { get; set; }
        public List<IrsaliyeDetayBilgilerModel> IrsaliyeDetayBilgiler { get; set; }
    }

    public class IrsaliyeDetayBilgilerModel
    {
        public short Sira { get; set; }
        public double Miktar { get; set; }

    }
}
