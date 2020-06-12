using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data;
using InnovaApp.DataAccess.Data.FideSiparis;
using InnovaApp.DataAccess.Data.Netsis;
using InnovaApp.Entities.Models.FideSiparis;
using InnovaApp.Entities.Models.FideSiparis.Innova;
using InnovaApp.UI.Web.Models.FideSiparis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class FideSiparisController : Controller
    {
        FideSiparisRepository _fideSiparisRepository;
        UserRepository _userRepository;
        NetsisVerilerRepository _netsisVerilerRepository;
        CariRepository _cariRepository;
        public FideSiparisController()
        {
            _netsisVerilerRepository = new NetsisVerilerRepository();
            _fideSiparisRepository = new FideSiparisRepository();
            _userRepository = new UserRepository();
            _cariRepository = new CariRepository();
        }
        public IActionResult Liste(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200000);
            ViewBag.yeniSiparisYetki = (yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.ToString("yyyy-MM-dd") : tarih2;
            var teklifListe = new List<SiparisBaslikModel>();
            var kullanici = HttpContext.Session.GetString("UserName");

           

            var depo = HttpContext.Session.GetString("Depo");

            var liste = _netsisVerilerRepository.TeklifListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2),onayDurum,kullanici,depo);
            foreach (var item in liste)
            {
                teklifListe.Add(
                    new SiparisBaslikModel
                    {
                        BelgeNo = item.BelgeNo,
                        CariAdi = item.CariAdi,
                        CariKodu = item.CariKodu,
                        Tarih = item.Tarih,
                        Aciklama = item.Aciklama,
                        OnayDurum = item.OnayDurum,
                        Il=item.Il,
                        Ilce=item.Ilce,
                        Plasiyer=item.Plasiyer

                    }
                    );
            }



            return View(teklifListe.OrderBy(x=>x.OnayDurum).ToList());
        }

        public IActionResult Detay(string belgeNo = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            var siparisEkleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200001);
            var siparisDuzenleYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200002);
            var siparisOnayYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200003);

            
            ViewBag.siparisEkleYetki = (siparisEkleYetki == null ? 0 : siparisEkleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisDuzenleYetki = (siparisDuzenleYetki == null ? 0 : siparisDuzenleYetki.Yetki) == 1 ? true : false;
            ViewBag.siparisOnayYetki = (siparisOnayYetki == null ? 0 : siparisOnayYetki.Yetki) == 1 ? true : false;
            
            if (string.IsNullOrEmpty(belgeNo))
            {
                belgeNo = YeniBelgeNo();
                var tarih = DateTime.Now;
                var _cariListe = HttpContext.Session.GetString("PlasiyerKodu")=="000"? _netsisVerilerRepository.CariKartlar() : _netsisVerilerRepository.CariKartlar(x=>x.Plasiyer== HttpContext.Session.GetString("PlasiyerKodu"));
                ViewBag.siparisOnayYetki = false;
                return View(new SiparisGirisModel
                {
                    belgeNo = belgeNo,
                    tarih = DateTime.Now,
                    yetki = "",
                    onayDurumKodu = "A",
                    onayDurumAdi = "Beklemede",
                    cariListe= _cariListe
                });

            }
            else
            {
                var baslik = _netsisVerilerRepository.Teklif(belgeNo);
                var _cariListe = HttpContext.Session.GetString("PlasiyerKodu") == "000" ? _netsisVerilerRepository.CariKartlar() : _netsisVerilerRepository.CariKartlar(x => x.Plasiyer == HttpContext.Session.GetString("PlasiyerKodu"));
                if (baslik.OnayDurum != "A")
                {
                    ViewBag.siparisEkleYetki = false;
                    ViewBag.siparisDuzenleYetki = false;
                    ViewBag.siparisOnayYetki = false;
                }
                return View(new SiparisGirisModel
                {
                    belgeNo = belgeNo,
                    cariListe = _cariListe
                });
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

        public JsonResult StokListesi(string stokGrupKod)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var stokListe = _netsisVerilerRepository.StokListe(stokGrupKod);
            return Json(stokListe);
        }

        public JsonResult StokGrupListesi()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var stokGrupListe = _netsisVerilerRepository.StokGrupListe();
            return Json(stokGrupListe);
        }

        public JsonResult CariListesi()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            var cariListe = _netsisVerilerRepository.CariListe();
            return Json(cariListe);
        }

        public JsonResult CariBakiyeRisk(string cariKod)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
                var cari = _netsisVerilerRepository.CariListe(x=>x.CariKod== cariKod).FirstOrDefault();
            return Json(new { 
                bakiye=cari.Bakiye,
                risk=cari.ToplamRisk
            });
        }

        public JsonResult DovizKurListesi()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            var dovizKurListe = _netsisVerilerRepository.DovizKurListe();
            return Json(dovizKurListe);
        }

        [HttpPost]
        public JsonResult SiparisKaydet(SiparisBilgilerModel siparisBilgilerModel)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            bool guncellemeVar = false;

            if (siparisBilgilerModel.SiparisBaslik.Guncellendi >= 1)
                guncellemeVar = true;

            for (int i = 0; i < siparisBilgilerModel.SiparisDetay.Count; i++)
            {
                if (siparisBilgilerModel.SiparisDetay[i].Eklendi == 1 || siparisBilgilerModel.SiparisDetay[i].Duzenlendi == 1 || siparisBilgilerModel.SiparisDetay[i].Silindi == 1)
                    guncellemeVar = true;
            }

            if (siparisBilgilerModel.SiparisBaslik.Guncellendi == 1)
                guncellemeVar = true;

            if (!guncellemeVar)
            {
                var Sonuc = new
                {
                    Durum = "0",
                    Mesaj = "Kayıt zaten güncel"

                };

                return Json(Sonuc);
            }

            var belgeKayitListe = new List<BelgeKayit>();

            for (int i = 0; i < siparisBilgilerModel.SiparisDetay.Count; i++)
            {
                if (siparisBilgilerModel.SiparisDetay[i].Silindi == 0)
                {
                    belgeKayitListe.Add(
                    new BelgeKayit
                    {
                        Sira = i + 1,
                        SiparisSira = i + 1,
                        FtirSip = "H",
                        Aktarim = 0,
                        SiparisNo = siparisBilgilerModel.SiparisBaslik.BelgeNo,
                        Guid = siparisBilgilerModel.SiparisDetay[i].Id,
                        BelgeNo = siparisBilgilerModel.SiparisBaslik.BelgeNo,
                        Tarih = siparisBilgilerModel.SiparisBaslik.Tarih,
                        CariKodu = siparisBilgilerModel.SiparisBaslik.CariKodu,
                        CariAdi = siparisBilgilerModel.SiparisBaslik.CariAdi,
                        Aciklama = siparisBilgilerModel.SiparisBaslik.Aciklama,

                        StokKodu = siparisBilgilerModel.SiparisDetay[i].StokKodu,
                        StokAdi = siparisBilgilerModel.SiparisDetay[i].StokAdi,
                        Birim = siparisBilgilerModel.SiparisDetay[i].Birim,
                        Miktar = siparisBilgilerModel.SiparisDetay[i].Miktar,
                        Doviz = siparisBilgilerModel.SiparisDetay[i].Doviz,
                        Kur = (decimal)siparisBilgilerModel.SiparisDetay[i].Kur,

                        BirimTutar = (decimal)siparisBilgilerModel.SiparisDetay[i].BirimTutar,
                        BirimTutarDoviz = (decimal)siparisBilgilerModel.SiparisDetay[i].BirimTutarDoviz,
                        ToplamTutar = (decimal)siparisBilgilerModel.SiparisDetay[i].ToplamTutar,
                        ToplamTutarDoviz = (decimal)siparisBilgilerModel.SiparisDetay[i].ToplamTutarDoviz,
                        DepoKodu = Convert.ToInt32(HttpContext.Session.GetString("Depo")),
                        KalemAciklama = siparisBilgilerModel.SiparisDetay[i].Aciklama,
                        KayitKullaniciId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                        KayitKullaniciAdi = HttpContext.Session.GetString("UserName")

                    }
                    ) ;
                }

            }

            var val = belgeKayitListe;

            try
            {
                _fideSiparisRepository.Kaydet(belgeKayitListe);
                _netsisVerilerRepository.PrBelgeKayitTeklif(siparisBilgilerModel.SiparisBaslik.BelgeNo, siparisBilgilerModel.SiparisBaslik.CariKodu);
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

        public JsonResult TeklifSiparisOnay(string belgeNo)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var baslik = _netsisVerilerRepository.Teklif(belgeNo);
            var detay = _netsisVerilerRepository.TeklifDetayListe(belgeNo);
            var belgeKayitListe = new List<BelgeKayit>();

            for (int i = 0; i < detay.Count; i++)
            {
                belgeKayitListe.Add(
                    new BelgeKayit
                    {
                        Sira              = i + 1,
                        SiparisSira       = i + 1,
                        FtirSip           = "6",
                        Aktarim           = 0,
                        SiparisNo         = belgeNo,
                        Guid              = Guid.NewGuid().ToString(),
                        BelgeNo           = belgeNo,
                        Tarih             = baslik.Tarih,
                        CariKodu          = baslik.CariKodu,
                        CariAdi           = baslik.CariAdi,
                        Aciklama          = baslik.Aciklama,
                                          
                        StokKodu          = detay[i].StokKodu,
                        StokAdi           = detay[i].StokAdi,
                        Birim             = detay[i].Birim,
                        Miktar            = detay[i].Miktar,
                        Doviz             = detay[i].Doviz.ToString(),
                        Kur               = (decimal)detay[i].DovizKuru,
                                          
                        BirimTutar        = (decimal)detay[i].BirimFiyat,
                        BirimTutarDoviz   = (decimal)detay[i].BirimFiyatDoviz,
                        ToplamTutar       = (decimal)detay[i].ToplamTutar,
                        ToplamTutarDoviz  = (decimal)detay[i].ToplamTutarDoviz,
                        DepoKodu          = Convert.ToInt32(HttpContext.Session.GetString("Depo")),
                        KalemAciklama     = detay[i].Aciklama,
                        KayitKullaniciId  = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                        KayitKullaniciAdi = baslik.Plasiyer

                    }) ;

            }

            try
            {
                _fideSiparisRepository.Kaydet(belgeKayitListe);
                _netsisVerilerRepository.PrBelgeKayitSiparis(belgeNo, baslik.CariKodu);
                SiparisOnayIptal(belgeNo, 'B');
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



        public JsonResult SiparisOnayIptal(string belgeNo, char onayKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                _netsisVerilerRepository.PrTeklifOnayIptal(belgeNo, onayKodu);
                
                var Sonuc = new
                {
                    Durum = "1",
                    Mesaj = "Başarılı"

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

        public JsonResult TeklifBilgileri(string belgeNo)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            if (!string.IsNullOrEmpty(belgeNo))
            {
                var baslik = _netsisVerilerRepository.Teklif(belgeNo);
                var detayListe = _netsisVerilerRepository.TeklifDetayListe(belgeNo);
                var detayListeModel = new List<SiparisDetayModel>();
                if (baslik == null) return Json("yeni");
                foreach (var item in detayListe)
                {
                    detayListeModel.Add(
                        new SiparisDetayModel
                        {
                            Aciklama = item.Aciklama,
                            Birim = item.Birim,
                            BirimTutar = (double)item.BirimFiyat,
                            BirimTutarDoviz = (double)item.BirimFiyatDoviz,
                            Doviz = item.Doviz.ToString(),
                            DovizAdi = item.DovizAdi,
                            Kur = (double)item.DovizKuru,
                            Miktar = item.Miktar,
                            StokAdi = item.StokAdi,
                            StokKodu = item.StokKodu,
                            ToplamTutar = (double)item.ToplamTutar,
                            ToplamTutarDoviz = (double)item.ToplamTutarDoviz,
                            Id = Guid.NewGuid().ToString(),
                            Silindi = 0,
                            Duzenlendi = 0,
                            Eklendi = 0
                        }
                        );
                }

                return Json(new SiparisGirisModel
                {

                    SiparisBaslik = new SiparisBaslikModel
                    {
                        BelgeNo = baslik.BelgeNo == null ? belgeNo : baslik.BelgeNo,
                        Aciklama = baslik.Aciklama,
                        Tarih = baslik.Tarih,
                        CariAdi = baslik.CariAdi,
                        CariKodu = baslik.CariKodu,
                        OnayDurum = baslik.OnayDurum,
                        OnayDurumAdi = baslik.OnayDurum == "A" ? "BEKLEMEDE" : baslik.OnayDurum == "B" ? "ONAYLANDI" : "İPTAL EDİLDİ",
                        Guncellendi = 0
                    },
                    SiparisDetay = detayListeModel


                });
            }
            else
            {
                var Sonuc = new
                {
                    Durum = "-1",
                    Mesaj = "Kayıt bulunamadı"

                };
                return Json(Sonuc);
            }
        }

        public JsonResult SiparisBilgileri(string belgeNo)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            if (!string.IsNullOrEmpty(belgeNo))
            {
                //var baslik = _netsisVerilerRepository.Siparis(belgeNo);
                var detayListe = _netsisVerilerRepository.SiparisDetayListe(belgeNo);
                var detayListeModel = new List<SiparisDetayModel>();
                //if (baslik == null) return Json("yeni");
                foreach (var item in detayListe)
                {
                    detayListeModel.Add(
                        new SiparisDetayModel
                        {
                            Aciklama = item.Aciklama,
                            Birim = item.Birim,
                            BirimTutar = (double)item.BirimFiyat,
                            BirimTutarDoviz = (double)item.BirimFiyatDoviz,
                            Doviz = item.Doviz.ToString(),
                            Kur = (double)item.DovizKuru,
                            Miktar = item.Miktar,
                            StokAdi = item.StokAdi,
                            StokKodu = item.StokKodu,
                            ToplamTutar = (double)item.ToplamTutar,
                            ToplamTutarDoviz = (double)item.ToplamTutarDoviz,
                            Id = Guid.NewGuid().ToString(),
                            Silindi = 0,
                            Duzenlendi = 0,
                            Eklendi = 0
                        }
                        );
                }

                return Json(new SiparisGirisModel
                {

                    //SiparisBaslik = new SiparisBaslikModel
                    //{
                    //    BelgeNo         = baslik.BelgeNo==null?belgeNo: baslik.BelgeNo,
                    //    Aciklama        = baslik.Aciklama,
                    //    Tarih           = baslik.Tarih,
                    //    CariAdi         = baslik.CariAdi,
                    //    CariKodu        = baslik.CariKodu,
                    //    OnayDurum       = baslik.OnayDurum,
                    //    OnayDurumAdi    = baslik.OnayDurum == "A" ? "BEKLEMEDE" : baslik.OnayDurum == "B" ? "ONAYLANDI" : "İPTAL EDİLDİ",
                    //    Guncellendi     = 0
                    //},
                    SiparisDetay = detayListeModel


                });
            }
            else
            {
                var Sonuc = new
                {
                    Durum = "-1",
                    Mesaj = "Kayıt bulunamadı"

                };
                return Json(Sonuc);
            }
        }


        public IActionResult SiparisListe(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40300000);
            ViewBag.yeniSiparisYetki = (yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.ToString("yyyy-MM-dd") : tarih2;

            var siparisListe = new List<SiparisBaslikModel>();
            var liste = _netsisVerilerRepository.SiparisListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum, HttpContext.Session.GetString("Depo"), HttpContext.Session.GetString("UserName"));
            //var liste = _netsisVerilerRepository.SiparisListe();
            //var listeDurum = _netsisVerilerRepository.SiparisDurumListe();
            foreach (var item in liste)
            {
                siparisListe.Add(
                    new SiparisBaslikModel
                    {
                        BelgeNo = item.BelgeNo,
                        CariAdi = item.CariAdi,
                        CariKodu = item.CariKodu,
                        Tarih = item.Tarih,
                        Aciklama = item.Aciklama,
                        OnayDurum = item.OnayDurum,
                        Il=item.Il,
                        Ilce=item.Ilce,
                        Plasiyer=item.Plasiyer

                    });
            }

            //for (int i = 0; i < liste.Count; i++)
            //{
            //    siparisListe[i].OnayDurum= listeDurum[i].Durum.ToString();
            //}

            var sonucListe = siparisListe.ToList();
            return View(sonucListe);
        }


        public IActionResult SiparisDetay(string belgeNo = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            var irsaliyeYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40300001);

            ViewBag.siparisOnayYetki = (irsaliyeYetki == null ? 0 : irsaliyeYetki.Yetki) == 1 ? true : false;

            if (string.IsNullOrEmpty(belgeNo))
            {
                return RedirectToAction("FideSiparis","SiparisListe");
            }
            else
            {
                var baslik  = _netsisVerilerRepository.Siparis(belgeNo);
                var cKodu = baslik.CariKodu;
                var cari = _netsisVerilerRepository.GetCariBilgi(cKodu);
                var detay   = _netsisVerilerRepository.SiparisDetayListe(belgeNo);
                var detayList = new List<SiparisDetayModel>();
                
                foreach (var item in detay)
                {
                    detayList.Add(new SiparisDetayModel
                    {
                        Id                  = item.Sira.ToString() + item.BelgeNo,
                        Sira                = item.Sira,
                        StokKodu            = item.StokKodu,
                        StokAdi             = item.StokAdi,
                        Birim               = item.Birim,
                        Miktar              = item.Miktar,
                        SiparisKalanMiktar  = item.SiparisKalanMiktar,
                        DovizAdi            = item.DovizAdi,
                        Kur                 = item.DovizKuru,
                        Aciklama            = item.Aciklama,
                        BirimTutar          = (double)item.BirimFiyat,
                        BirimTutarDoviz     = (double)item.BirimFiyatDoviz,
                        ToplamTutar         = (double)item.ToplamTutar,
                        ToplamTutarDoviz    = (double)item.ToplamTutarDoviz,

                    });
                }

                if (baslik.OnayDurum != "A")
                {
                    ViewBag.siparisOnayYetki = false;
                }
                return View(new SiparisGirisModel
                {
                    SiparisBaslik = new SiparisBaslikModel
                    {
                        BelgeNo     = baslik.BelgeNo,
                        CariKodu    = baslik.CariKodu,
                        CariAdi     = baslik.CariAdi,
                        FtirSip     = "",
                        Aciklama    = baslik.Aciklama,
                        Il          = baslik.Il,
                        Ilce        = baslik.Ilce,
                        OnayDurum   = baslik.OnayDurum,
                        Tarih       = baslik.Tarih,
                        Eposta      = cari.Eposta,
                        TelNo       = cari.TelNo,
                        VergiDairesi=cari.VergiDairesi,
                        VergiDairesiNo=cari.VergiNumarasi

                    },
                    SiparisDetay = detayList


                });;
            }
        }


        public JsonResult IrsaliyeNumaraSorgula(string irsaliyeNo)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var irsaliyeVarmi = _netsisVerilerRepository.IrsaliyeSorgula(irsaliyeNo);

            if (irsaliyeVarmi)
            {
                var Sonuc = new
                {
                    Durum = "1",
                    Mesaj = "Kayıt var"

                };
                return Json(Sonuc);
            }
            else
            {
                var Sonuc = new
                {
                    Durum = "0",
                    Mesaj = "Kayıt bulunamadı"

                };
                return Json(Sonuc);
            }
            
            
        }

        public JsonResult IrsaliyeKaydet(IrsaliyeBilgilerModel irsaliyeBilgilerModel)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            //var irsaliyeVarmi = _netsisVerilerRepository.IrsaliyeSorgula(irsaliyeNo);

            var baslik = _netsisVerilerRepository.Siparis(irsaliyeBilgilerModel.BelgeNo);
            var detay = _netsisVerilerRepository.SiparisDetayListe(irsaliyeBilgilerModel.BelgeNo);
            var belgeKayitListe = new List<BelgeKayit>();


            for (int i = 0; i < detay.Count; i++)
            {
                if(irsaliyeBilgilerModel.IrsaliyeDetayBilgiler.Where(x=>x.Sira== detay[i].Sira).FirstOrDefault()!=null)
                {
                    belgeKayitListe.Add(
                    new BelgeKayit
                    {
                        Sira = detay[i].Sira,
                        SiparisSira = detay[i].Sira,
                        FtirSip = "3",
                        Aktarim = 0,
                        SiparisNo = baslik.BelgeNo,
                        Guid = Guid.NewGuid().ToString(),
                        BelgeNo = irsaliyeBilgilerModel.IrsaliyeNo,
                        Tarih = baslik.Tarih,
                        CariKodu = baslik.CariKodu,
                        CariAdi = baslik.CariAdi,
                        Aciklama = baslik.Aciklama,
                        Aciklama2 = irsaliyeBilgilerModel.Aciklama2,
                        Aciklama3 = irsaliyeBilgilerModel.Aciklama3,
                        Aciklama4 = irsaliyeBilgilerModel.Aciklama4,
                        Aciklama5 = irsaliyeBilgilerModel.Aciklama5,
                        StokKodu = detay[i].StokKodu,
                        StokAdi = detay[i].StokAdi,
                        Birim = detay[i].Birim,
                        Miktar = (decimal)irsaliyeBilgilerModel.IrsaliyeDetayBilgiler.Where(x => x.Sira == detay[i].Sira).FirstOrDefault().Miktar,
                        Doviz = detay[i].Doviz.ToString(),
                        Kur = (decimal)detay[i].DovizKuru,
                        DepoKodu= Convert.ToInt32(HttpContext.Session.GetString("Depo")),
                        BirimTutar = (decimal)detay[i].BirimFiyat,
                        BirimTutarDoviz = (decimal)detay[i].BirimFiyatDoviz,
                        ToplamTutar = (decimal)detay[i].ToplamTutar,
                        ToplamTutarDoviz = (decimal)detay[i].ToplamTutarDoviz,

                        KalemAciklama = detay[i].Aciklama,
                        KayitKullaniciId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                        KayitKullaniciAdi = HttpContext.Session.GetString("UserName")

                    }
                    );
                }
                

            }

            try
            {
                _fideSiparisRepository.Kaydet(belgeKayitListe);
                _netsisVerilerRepository.PrBelgeKayitIrsaliye(irsaliyeBilgilerModel.IrsaliyeNo, baslik.CariKodu);
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