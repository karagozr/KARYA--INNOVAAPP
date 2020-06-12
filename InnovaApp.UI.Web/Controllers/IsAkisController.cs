using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Context;
using InnovaApp.DataAccess.Data.IsAkis;
using InnovaApp.DataAccess.Data.Netsis;
using InnovaApp.DataAccess.Helper;
using InnovaApp.Entities.Models.IsAkis;
using InnovaApp.UI.Web.Models.CariRapor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnovaApp.UI.Web.Controllers
{
    public class IsAkisController : Controller
    {
        IsAkisRepository _isAkisRepository;
        IsAkisDapperRepository _isAkisDetay;

        public IsAkisController()
        {
            _isAkisRepository = new IsAkisRepository();
            _isAkisDetay = new IsAkisDapperRepository();

        }


        
        [HttpGet]
        public IActionResult Liste()
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            var str = HttpContext.Session.GetString("UserId");
            var id = Convert.ToInt32(str);

            var isAkislistesi = _isAkisRepository.IsAkisListe(id);

            var isAkisUst = isAkislistesi.GroupBy(x => new { x.BelgeNo, x.Tarih, x.DbName }).Select(s => new IsAkisEmir
            {
                BelgeNo = s.Key.BelgeNo,
                Tarih = s.Key.Tarih,
                Nakit = s.Sum(t=>t.Nakit),
                KrediKarti = s.Sum(t => t.KrediKarti),
                Havale = s.Sum(t => t.Havale),
                Cek = s.Sum(t => t.Cek),
                Aciklama =s.Max(t=>t.UstAciklama),
            }).ToList();


            var model = new IsAkisModel
            {
                IsAkisUst = isAkisUst,
                IsAkisEmir = isAkislistesi
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult OnayIptalIslem(int akisId,string islem)
        {
            var str = HttpContext.Session.GetString("UserId");
            var userId = Convert.ToInt32(str);

            var isAkislistesi = _isAkisRepository.IsAkisOnayIptal(akisId,islem, userId);

            var Sonuc = new
            {
                Durum = isAkislistesi.Success == true ? "0" : "-1",
                Mesaj = isAkislistesi.Success == true ? "başarılı" : "işem sırasında hata oluştu",

            };
            return Json(Sonuc);
        }

        public JsonResult IsAkisDetay(int akisId, int akisKayitId)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var result = _isAkisDetay.IsAkisDetayGor(akisId, akisKayitId);

            return Json(result);
        }


    }

    public class IsAkisModel
    {
        public List<IsAkisEmir> IsAkisUst { get; set; }

        public List<IsAkisEmir> IsAkisEmir { get; set; }
    }
}