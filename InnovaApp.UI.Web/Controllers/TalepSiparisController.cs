using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data;
using InnovaApp.Entities.Models;
using InnovaApp.UI.Web.Models;
using InnovaApp.UI.Web.Models.TalepSiparis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class TalepSiparisController : Controller
    {
        TalepRepository _talepRepository;
        public TalepSiparisController()
        {
            _talepRepository = new TalepRepository();
        }
        public IActionResult TalepListe()
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");
            return View();
        }

        public IActionResult TalepDetay(string belgeNo, int subeId )
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");
            if (subeId == 0) return RedirectToAction("TalepListe");
            HttpContext.Session.Remove("SubeId");
            HttpContext.Session.SetString("SubeId", subeId.ToString());
            return View();
        }

        public JsonResult TalepListeFiltreVerileri()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            List<Sube> _subeListe = new List<Sube>()
            {
                        new Sube(){SubeId=1,SubeAdi="1. ŞUBE"},
                        new Sube(){SubeId=2,SubeAdi="2. ŞUBE"},
                        new Sube(){SubeId=3,SubeAdi="3. ŞUBE"},
                        new Sube(){SubeId=4,SubeAdi="4. ŞUBE"}


            };

            List<TalepDurum> _talepDurumListe = new List<TalepDurum>()
            {
                        new TalepDurum(){DurumId="BEKLEMEDE", DurumAdi="BEKLEMEDE"},
                        new TalepDurum(){DurumId="IPTAL",DurumAdi="IPTAL"},
                        new TalepDurum(){DurumId="ONAYLANDI",DurumAdi="ONAYLANDI"}

            };

            var filtreVerileri = new
            {
                subeListe = _subeListe,
                siparisDurumListe = _talepDurumListe,
                tarih1 = DateTime.Now.AddDays(-10),
                tarih2 = DateTime.Now
            };

            return Json(filtreVerileri);
        }

        public JsonResult TalepBaslikliste(SiparisTalepFiltreModel siparisTalepFiltreModel = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var query = _talepRepository.TalepListesiBaslik(null);

            if (siparisTalepFiltreModel.Tarih1 != null)
                if (siparisTalepFiltreModel.Tarih1 != Convert.ToDateTime("01-01-0001 00:00:00"))
                    query = query.Where(x => x.Tarih >= siparisTalepFiltreModel.Tarih1);

            if (siparisTalepFiltreModel.Tarih2 != null)
                if (siparisTalepFiltreModel.Tarih2 != Convert.ToDateTime("01-01-0001 00:00:00"))
                    query = query.Where(x => x.Tarih < siparisTalepFiltreModel.Tarih2);

            if (siparisTalepFiltreModel.SubeId != 0)
                query = query.Where(x => x.Sube == siparisTalepFiltreModel.SubeId);

            if (siparisTalepFiltreModel.SiparisDurum != null)
                query = query.Where(x => x.BelgeDurum == siparisTalepFiltreModel.SiparisDurum);

            var val = query.ToList();

            return Json(query.ToList());
        }

        public JsonResult TalepDetayVerileri(string belgeNo = null)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var subeId = HttpContext.Session.GetString("SubeId");

            if (String.IsNullOrEmpty(subeId))
            {
                RedirectToAction("TalepListe");
            }

            if (string.IsNullOrEmpty(belgeNo))
            {
                var talepSiparisVerileri = new
                {
                    talepSiparisBaslik = new
                    {
                        belgeNo = yeniBelgeNo(),
                        sube = subeId,
                        tarih = DateTime.Now,
                        aciklama = "",
                        belgeDurum = "BEKLEMEDE"
                    },
                    talepSiparisDetay ="",

                };

                return Json(talepSiparisVerileri);
            }
            else
            {
                var talepSiparisKayitli = _talepRepository.GetTalepByBelgeNo(belgeNo).ToList();
                if (talepSiparisKayitli.Count == 0) return Json("");
                var talepSiparisVerileri = new
                {
                    talepSiparisBaslik = new
                    {
                        belgeNo = talepSiparisKayitli.First().BelgeNo,
                        sube = talepSiparisKayitli.First().Sube,
                        tarih = talepSiparisKayitli.First().Tarih,
                        aciklama = talepSiparisKayitli.First().Aciklama,
                        belgeDurum = talepSiparisKayitli.First().BelgeDurum
                    },
                    talepSiparisDetay= _talepRepository.GetTalepByBelgeNo(belgeNo).ToList()

            };

                return Json(talepSiparisVerileri);
            }

            string yeniBelgeNo()
            {
                var sonBelgeNo = _talepRepository.SonBelgeId();
                var sonHal = "";
                if (sonBelgeNo <= 10000)
                {
                    var sonBelgeCharSet = (sonBelgeNo + 1).ToString();
                    for (int i = 0; i < 5 - sonBelgeCharSet.Length; i++)
                    {
                        sonHal = sonHal + "0";
                    }
                    sonHal = sonHal + sonBelgeCharSet;
                }
                var x = sonHal;
                return "TS"+subeId.ToString() + sonHal;
            }
        }

        public JsonResult StokListesi()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            List<Stok> stokListe = new List<Stok>()
            {

                        new Stok(){StokKodu="ST01",StokAdi="ÇİMENTO",Birim="AD"},
                        new Stok(){StokKodu="ST02",StokAdi="BİRİKET",Birim="AD"},
                        new Stok(){StokKodu="ST03",StokAdi="DEMİR",Birim="KG"},
                        new Stok(){StokKodu="ST04",StokAdi="TUĞLA",Birim="AD"},
                        new Stok(){StokKodu="ST05",StokAdi="BEYAZ BOYA 20kg",Birim="AD"},
                        new Stok(){StokKodu="ST06",StokAdi="KALEKİM",Birim="KG"},
                        new Stok(){StokKodu="ST07",StokAdi="FAYANS",Birim="M2"},
                        new Stok(){StokKodu="ST08",StokAdi="KUM",Birim="KG"},
                        new Stok(){StokKodu="ST09",StokAdi="EL ARABASI",Birim="AD"},
                        new Stok(){StokKodu="ST10",StokAdi="YTONG",Birim="AD"},
                        new Stok(){StokKodu="ST11",StokAdi="TEL",Birim="AD"}

            };

            return Json(stokListe);
        }

        public JsonResult TalepEkleDuzenle(BelgeKayit model)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                if (model.Id >= 1)
                {
                    _talepRepository.TalepGuncelle(new BelgeKayit()
                    {
                        Id=model.Id,
                        BelgeNo =model.BelgeNo,
                        StokKodu = model.StokKodu,
                        StokAdi = model.StokAdi,
                        Birim = model.Birim,
                        Miktar = model.Miktar,
                        Aciklama = model.Aciklama

                    });

                    return Json(model.BelgeNo);
                }
                else
                {

                    _talepRepository.TalepKayit(new BelgeKayit()
                    {
                        Guid = Guid.NewGuid().ToString(),
                        //Id = model.Id,
                        Tarih = model.Tarih,
                        BelgeNo = model.BelgeNo,
                        StokKodu = model.StokKodu,
                        StokAdi = model.StokAdi,
                        Birim = model.Birim,
                        Miktar = model.Miktar,
                        Sira = 1,
                        BelgeDurum = model.BelgeDurum,
                        Sube = Convert.ToInt32(HttpContext.Session.GetString("SubeId")),
                        Aciklama = model.Aciklama

                    }); 

                    return Json(model.BelgeNo);
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                throw;
            }


            
        }

        public JsonResult BelgeSil(int belgeId)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                _talepRepository.TalepStokSil(belgeId);
                return Json(true);
            }
            catch (Exception)
            {
                return Json("hata");
                throw;
            }
        }

    }
}