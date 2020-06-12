using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data.MotoServis;
using InnovaApp.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class MotoServisController : Controller
    {
        MotoServisNetsisRepository _motoServisNetsisRepository;
        public MotoServisController()
        {
            _motoServisNetsisRepository = new MotoServisNetsisRepository();
        }
        public IActionResult Liste(string tarih1 = "01-01-0001", string tarih2 = "01-01-0001", string onayDurum = "")
        {
            //if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            //var yeniSiparisYetki = _userRepository.UserYetkiGetir(Convert.ToInt32(HttpContext.Session.GetString("UserId")), 40200000);
            ViewBag.yeniSiparisYetki = true;//(yeniSiparisYetki == null ? 0 : yeniSiparisYetki.Yetki) == 1 ? true : false;

            ViewBag.onayDurum = onayDurum;
            ViewBag.tarih1 = tarih1 == "01-01-0001" ? DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") : tarih1;
            ViewBag.tarih2 = tarih2 == "01-01-0001" ? DateTime.Today.ToString("yyyy-MM-dd") : tarih2;
            //var teklifListe = new List<SiparisBaslikModel>();
            //var kullanici = HttpContext.Session.GetString("UserName");



            
            var cariKodu = "";
            var liste = _motoServisNetsisRepository.TeklifListe(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2), onayDurum,cariKodu).Select(x=>new SiparisBaslikModel
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

        public IActionResult KayitDuzenle()
        {
            return View();
        }

    }
}