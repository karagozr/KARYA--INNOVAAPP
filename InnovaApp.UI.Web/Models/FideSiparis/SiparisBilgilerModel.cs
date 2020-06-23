using InnovaApp.Entities.Models.FideSiparis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaApp.UI.Web.Models.FideSiparis
{

    public class SiparisBilgilerModel
    {
        public SiparisBaslikModel SiparisBaslik { get; set; }
        public List<SiparisDetayModel> SiparisDetay { get; set; }
        
    }

    public class SiparisBaslikBilgileriModel
    {
        public DateTime Tarih1 { get; set; } = DateTime.Today.AddDays(-7);
        public DateTime Tarih2 { get; set; } = DateTime.Today.AddDays(1);
        public List<SiparisDurumModel> SiparisDurumlari { get; set; }
        public List<SiparisBaslikModel> SiparisDetay { get; set; }
    }
   
    public class SiparisDurumModel
    {
        public string Kod { get; set; }

        public string Isim { get; set; }

    }

    

    public class SiparisBaslikModel
    {
        public string Guid { get; set; }

        public string FtirSip { get; set; }

        public string BelgeNo { get; set; }

        public DateTime Tarih { get; set; }

        public string CariKodu { get; set; }

        public string CariAdi { get; set; }

        public string Aciklama { get; set; }

        public string Il { get; set; }

        public string Ilce { get; set; }

        public string VergiDairesiNo { get; set; }

        public string VergiDairesi { get; set; }
        public string Eposta { get; set; }

        public string TelNo { get; set; }

        public string OnayDurum { get; set; }

        public string OnayDurumAdi { get; set; }

        public int Guncellendi { get; set; }

        public string Plasiyer { get; set; }


    }

    public class SiparisDetayModel
    {
       

        /*
        *Duzenlendi: 0
        *Eklendi: 1
        *Silindi: 0*/

        public int Eklendi { get; set; }
        public int Duzenlendi { get; set; }
        public int Silindi { get; set; }

        public string Id { get; set; }

        public short Sira { get; set; }
        public string StokKodu { get; set; }

        public string StokAdi { get; set; }

        public string Birim { get; set; }

        public decimal Miktar { get; set; }

        public decimal SiparisKalanMiktar { get; set; }

        public string Doviz { get; set; }
        public string DovizAdi { get; set; }
        public double Kur { get; set; }

        public double BirimTutar { get; set; }

        public double BirimTutarDoviz { get; set; }

        public double ToplamTutar { get; set; }

        public double ToplamTutarDoviz { get; set; }

        public string Aciklama { get; set; }
    }


    public class SiparisGirisModel
    {
        public string belgeNo { get; set; }

        public DateTime tarih { get; set; }

        public string onayDurumKodu { get; set; }

        public string onayDurumAdi { get; set; }

        public string yetki { get; set; }

        public List<CariKart> cariListe { get; set; }

        public SiparisBaslikModel SiparisBaslik { get; set; }
        public List<SiparisDetayModel> SiparisDetay { get; set; }
    }


    public class TeklifGirisModel
    {
        public string belgeNo { get; set; }

        public DateTime tarih { get; set; }

        public string musteriAdi { get; set; }

        public string aciklama { get; set; }

        public string onayDurumKodu { get; set; }

        public string onayDurumAdi { get; set; }

        public string yetki { get; set; }

        public string firmaCariKodu { get; set; }

        public string firmaCariAdi { get; set; }

        public string durumAciklama { get; set; }
        
        public string siparisDataJson { get; set; }
        
        public List<CariKart> cariListe { get; set; }

        public SiparisBaslikModel SiparisBaslik { get; set; }
        public List<SiparisDetayModel> SiparisDetay { get; set; }
    }
}
