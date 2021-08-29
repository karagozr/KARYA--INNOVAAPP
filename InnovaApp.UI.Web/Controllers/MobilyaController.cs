using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data.MobilyaSiparis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class MobilyaController : Controller
    {
        MobilyaServisRepository mobilyaServisRepository;
        public MobilyaController()
        {
            mobilyaServisRepository = new MobilyaServisRepository();
        }
        public IActionResult Liste(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            //if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200000);
            ViewBag.yeniSiparisYetki = true;//(yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") : tarih2;
            //var teklifListe = new List<SiparisBaslikModel>();
            //var kullanici = HttpContext.Session.GetString("UserName");




            var cariKodu = HttpContext.Session.GetString("UserCariKodu");
            var liste = mobilyaServisRepository.GetSiparisListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum, cariKodu);

            //var liste = _motoServisNetsisRepository.TeklifListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum, cariKodu).Select(x => new InnovaApp.UI.Web.Models.SiparisBaslikModel
            //{
            //    Tarih = x.Tarih,
            //    Aciklama = x.Aciklama,
            //    BelgeNo = x.BelgeNo,
            //    CariAdi = x.CariAdi,
            //    CariKodu = x.CariKodu,
            //    Musteri = x.Aciklama2,
            //    Il = x.Il,
            //    Ilce = x.Ilce,
            //    OnayDurum = x.OnayDurum,
            //    OnayDurumAciklama = x.Aciklama3,
            //    Plasiyer = x.Plasiyer

            //});



            return View(liste.OrderBy(x => x.Tarih).ToList());
        }

        public IActionResult YeniSiparis()
        {
            //if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");


            return View();
        }



        public JsonResult AddStokRecete(string StokKodu, string Guid)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var sonuc = mobilyaServisRepository.AddStokRecete(StokKodu, Guid);

            return Json(sonuc);
        }

        public JsonResult UpdateStokRecete(int Id, string StokKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var sonuc = mobilyaServisRepository.UpdateStokRecete(Id,StokKodu);

            return Json(sonuc);
        }

        public JsonResult GetStokRecete(string stokKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var stokListe = mobilyaServisRepository.GetStokRecete(stokKodu);

            return Json(stokListe);
        }
    }
}
