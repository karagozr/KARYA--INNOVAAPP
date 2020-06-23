using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data;
using InnovaApp.DataAccess.Data.FideSiparis;
using InnovaApp.DataAccess.Data.MotoServis;
using InnovaApp.DataAccess.Data.Netsis;
using InnovaApp.Entities.Models.FideSiparis.Innova;
using InnovaApp.UI.Web.Models;
using InnovaApp.UI.Web.Models.FideSiparis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnovaApp.UI.Web.Controllers
{
    public class MotoServisController : Controller
    {
        StokRepository _stokRepository;
        InnovaRepository _innovaRepository;
        MotoServisNetsisRepository _motoServisNetsisRepository;
        NetsisVerilerRepository _netsisVerilerRepository;
        public MotoServisController()
        {
            _motoServisNetsisRepository = new MotoServisNetsisRepository();
            _stokRepository = new StokRepository();
            
        }
        public IActionResult Liste(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200000);
            ViewBag.yeniSiparisYetki = true;//(yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") : tarih2;
            //var teklifListe = new List<SiparisBaslikModel>();
            //var kullanici = HttpContext.Session.GetString("UserName");



            
            var cariKodu = HttpContext.Session.GetString("UserCariKodu");
            var liste = _motoServisNetsisRepository.TeklifListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum,cariKodu).Select(x=>new InnovaApp.UI.Web.Models.SiparisBaslikModel
            { 
                Tarih=x.Tarih,
                Aciklama=x.Aciklama,
                BelgeNo=x.BelgeNo,
                CariAdi=x.CariAdi,
                CariKodu=x.CariKodu,
                Musteri=x.Aciklama2,
                Il=x.Il,
                Ilce=x.Ilce,
                OnayDurum=x.OnayDurum,
                OnayDurumAciklama=x.Aciklama3,
                Plasiyer=x.Plasiyer

            });



            return View(liste.OrderBy(x => x.OnayDurum).ToList());
        }

        public IActionResult Duzenle(string belgeNo = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var siparisEkleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200001);
            //var siparisDuzenleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200002);
            //var siparisOnayYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200003);


            ViewBag.siparisEkleYetki    = true; //(siparisEkleYetki == null ? 0 : siparisEkleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisDuzenleYetki = true; //(siparisDuzenleYetki == null ? 0 : siparisDuzenleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisOnayYetki    = true; //(siparisOnayYetki == null ? 0 : siparisOnayYetki.Yetki) == 1 ? true : false;

            
            if (string.IsNullOrEmpty(belgeNo))
            {
                _netsisVerilerRepository = new NetsisVerilerRepository();

                belgeNo = YeniBelgeNo();
                var tarih = DateTime.Now;
                var caKod = HttpContext.Session.GetString("UserCariKodu");
                var _cari =  _netsisVerilerRepository.GetCariKart(x => x.CariKod == caKod);
                ViewBag.siparisOnayYetki = false;
                return View(new TeklifGirisModel
                {
                    belgeNo = belgeNo,
                    tarih = DateTime.Now,
                    yetki = "",
                    onayDurumKodu = "A",
                    onayDurumAdi = "Beklemede",
                    cariListe = null,
                    firmaCariAdi= _cari.CariIsim
                });

            }
            else
            {
                var baslik = _motoServisNetsisRepository.Teklif(belgeNo);
                //if (baslik.OnayDurum != "A")
                //{
                //    ViewBag.siparisEkleYetki = false;
                //    ViewBag.siparisDuzenleYetki = false;
                //    ViewBag.siparisOnayYetki = false;
                //}
                return View(new TeklifGirisModel
                {
                    belgeNo = baslik.BelgeNo,
                    tarih = baslik.Tarih,
                    musteriAdi = baslik.Aciklama,
                    aciklama = baslik.Aciklama2,
                    durumAciklama = baslik.Aciklama3,
                    siparisDataJson = JsonConvert.SerializeObject(_motoServisNetsisRepository.TeklifDetayListe(belgeNo)),
                    yetki = "",
                    onayDurumKodu = baslik.OnayDurum,
                    onayDurumAdi = baslik.OnayDurum,
                    firmaCariAdi = baslik.CariAdi
                }); ;
            }

            string YeniBelgeNo()
            {

                var nowDate = DateTime.Now;
                var year = (nowDate.Year.ToString()).Substring(2, 2);
                var month = nowDate.Month < 10 ? "0" + (nowDate.Month.ToString()) : nowDate.Month.ToString();
                var day = nowDate.Day < 10 ? "0" + (nowDate.Day.ToString()) : nowDate.Day.ToString();
                var hour = nowDate.Hour < 10 ? "0" + (nowDate.Hour.ToString()) : nowDate.Hour.ToString();
                var minute = nowDate.Minute < 10 ? "0" + (nowDate.Minute.ToString()) : nowDate.Minute.ToString();
                var second = nowDate.Second < 10 ? "0" + (nowDate.Second.ToString()) : nowDate.Second.ToString();
                Random random = new Random();
                var rand = random.Next(10, 99).ToString();
                return "W" + year + month + day + hour + minute + second + rand;
            }

        }

        public IActionResult AdminListe(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200000);
            ViewBag.yeniSiparisYetki = true;//(yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") : tarih2;
            //var teklifListe = new List<SiparisBaslikModel>();
            //var kullanici = HttpContext.Session.GetString("UserName");




            var liste = _motoServisNetsisRepository.TeklifListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum).Select(x => new InnovaApp.UI.Web.Models.SiparisBaslikModel
            {
                Tarih = x.Tarih,
                Aciklama = x.Aciklama,
                BelgeNo = x.BelgeNo,
                CariAdi = x.CariAdi,
                CariKodu = x.CariKodu,
                Musteri = x.Aciklama2,
                Il = x.Il,
                Ilce = x.Ilce,
                OnayDurum = x.OnayDurum,
                OnayDurumAciklama = x.Aciklama3,
                Plasiyer = x.Plasiyer

            });



            return View(liste.OrderBy(x => x.OnayDurum).ToList());
        }

        public IActionResult Onay(string belgeNo = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var siparisEkleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200001);
            //var siparisDuzenleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200002);
            //var siparisOnayYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200003);


            ViewBag.siparisEkleYetki = true; //(siparisEkleYetki == null ? 0 : siparisEkleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisDuzenleYetki = true; //(siparisDuzenleYetki == null ? 0 : siparisDuzenleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisOnayYetki = true; //(siparisOnayYetki == null ? 0 : siparisOnayYetki.Yetki) == 1 ? true : false;


            var baslik = _motoServisNetsisRepository.Teklif(belgeNo);
            //if (baslik.OnayDurum != "A")
            //{
            //    ViewBag.siparisEkleYetki = false;
            //    ViewBag.siparisDuzenleYetki = false;
            //    ViewBag.siparisOnayYetki = false;
            //}
            return View(new TeklifGirisModel
            {
                belgeNo = baslik.BelgeNo,
                tarih = baslik.Tarih,
                musteriAdi = baslik.Aciklama,
                aciklama = baslik.Aciklama2,
                durumAciklama = baslik.Aciklama3,
                siparisDataJson = JsonConvert.SerializeObject(_motoServisNetsisRepository.TeklifDetayListe(belgeNo)),
                yetki = "",
                onayDurumKodu = baslik.OnayDurum,
                onayDurumAdi = baslik.OnayDurum,
                firmaCariAdi = baslik.CariAdi
            });

        }

        [HttpPost]
        public JsonResult SiparisKaydet(MotoSiparisModel siparisBilgilerModel)
        {


            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            //bool guncellemeVar = false;

            //if (siparisBilgilerModel.SiparisBaslik.Guncellendi >= 1)
            //    guncellemeVar = true;

            //for (int i = 0; i < siparisBilgilerModel.SiparisDetay.Count; i++)
            //{
            //    if (siparisBilgilerModel.SiparisDetay[i].Eklendi == 1 || siparisBilgilerModel.SiparisDetay[i].Duzenlendi == 1 || siparisBilgilerModel.SiparisDetay[i].Silindi == 1)
            //        guncellemeVar = true;
            //}

            //if (siparisBilgilerModel.SiparisBaslik.Guncellendi == 1)
            //    guncellemeVar = true;

            //if (!guncellemeVar)
            //{
            //    var Sonuc = new
            //    {
            //        Durum = "0",
            //        Mesaj = "Kayıt zaten güncel"

            //    };

            //    return Json(Sonuc);
            //}

            _netsisVerilerRepository = new NetsisVerilerRepository();
            _innovaRepository = new InnovaRepository();
            var dovizKurListe = _motoServisNetsisRepository.DovizKurListe();
            var belgeKayitListe = new List<BelgeKayit>();
            var kalemler = siparisBilgilerModel.detay;
            for (int i = 0; i < kalemler.Count; i++)
            {
                
                var stok = _stokRepository.StokBul(x => x.StokKodu == kalemler[i].stokKod).FirstOrDefault();
                var kur = dovizKurListe.Where(x => x.Sira == stok.SatisDovizTip).FirstOrDefault().Kur;
                belgeKayitListe.Add(
                    new BelgeKayit
                    {
                        Sira = i + 1,
                        SiparisSira = i + 1,
                        FtirSip = "H",
                        Aktarim = 0,
                        SiparisNo = siparisBilgilerModel.belgeNo,
                        Guid = kalemler[i].id,
                        BelgeNo = siparisBilgilerModel.belgeNo,
                        Tarih = siparisBilgilerModel.tarih,
                        CariKodu = HttpContext.Session.GetString("UserCariKodu"),
                        CariAdi = _netsisVerilerRepository.GetCariKart(x => x.CariKod == HttpContext.Session.GetString("UserCariKodu")).CariIsim,
                        Aciklama = siparisBilgilerModel.musteriAdi,
                        Aciklama2 = siparisBilgilerModel.aciklama,
                        StokKodu = kalemler[i].stokKod,
                        StokAdi = stok.StokAdi,
                        Birim = stok.OlcuBr,
                        Miktar = kalemler[i].miktar,
                        Doviz = stok.SatisDovizTip.ToString(),
                        Kur = (decimal)kur,

                        BirimTutar = (decimal)stok.DovizSatisFiyat* (decimal)kur,
                        BirimTutarDoviz = (decimal)stok.DovizSatisFiyat,
                        ToplamTutar = (decimal)stok.DovizSatisFiyat * (decimal)kur * kalemler[i].miktar,
                        ToplamTutarDoviz = (decimal)stok.DovizSatisFiyat * kalemler[i].miktar,
                        //DepoKodu = Convert.ToInt32(HttpContext.Session.GetString("Depo")),
                        KalemAciklama = kalemler[i].aciklama,
                        KayitKullaniciId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                        KayitKullaniciAdi = HttpContext.Session.GetString("UserName")

                    });
                
            }

            //var val = belgeKayitListe;

            try
            {
                _innovaRepository.BelgeKaydet(belgeKayitListe);
                _motoServisNetsisRepository.PrBelgeKayitTeklif(siparisBilgilerModel.belgeNo, HttpContext.Session.GetString("UserCariKodu"));
                var Sonuc = new
                {
                    Durum = "1",
                    Mesaj = ""

                };
                return Json(Sonuc);
            }
            catch (Exception ex)
            {
                var Sonuc = new
                {
                    Durum = "-1",
                    Mesaj = ex.Message

                };
                return Json(Sonuc);
            }



        }
    }
}