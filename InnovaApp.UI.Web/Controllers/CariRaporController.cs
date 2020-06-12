using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Context;
using InnovaApp.DataAccess.Data.Netsis;
using InnovaApp.DataAccess.Helper;
using InnovaApp.UI.Web.Models.CariRapor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnovaApp.UI.Web.Controllers
{
    public class CariRaporController : Controller
    {
        CariRepository _cariRepository;
        InnovaContext _innovaContext;
        //string conStr = string.IsNullOrEmpty(HttpContext.Session.GetString("Donem")) ? "" : HttpContext.Session.GetString("Donem");

        public CariRaporController()
        {
           
            //_innovaContext  = new InnovaContext();
            _cariRepository = new CariRepository();
            //if (HttpContext.Session.GetString("Donem") == null)
            //{
            //    _cariRepository = new CariRepository();
            //}
            //else
            //{
            //    var dnm = HttpContext.Session.GetString("Donem");
            //    _cariRepository = new CariRepository(dnm);
            //}

        }


        

        public IActionResult Liste()
        {
            

            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            DbManager.DbName = "BUYIL";

            dynamic myDynamic = new System.Dynamic.ExpandoObject();
            myDynamic.DbName = "BUYIL";
            var json = JsonConvert.SerializeObject(myDynamic);

            return View();
        }

        public IActionResult CariHaraket(string cariKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return RedirectToAction("Login", "Account");

            return View();
        }


        public JsonResult Donem(string donem)
        {

            DbManager.DbName = donem;

            dynamic myDynamic = new System.Dynamic.ExpandoObject();
            myDynamic.DbName = donem;

            var json = JsonConvert.SerializeObject(myDynamic);
            HttpContext.Session.SetString("Donem", donem);
            return Json("");
        }

        public JsonResult FaturaBak(string belgeNo, string cariKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            if (!string.IsNullOrEmpty(belgeNo))
            {
                try
                {
                    var values = _cariRepository.GetFatura(belgeNo, cariKodu);

                    return Json(values);
                }
                catch(Exception ex)
                {

                    return Json(ex.Message);
                }
               
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

        public JsonResult BakiyeliCariListe(CariRaporListeFiltreModel cariRaporListeFiltreModel)
        {
            try
            {
                if (HttpContext.Session.GetString("UserId") == null) return Json("");

                var query = _cariRepository.GetCariBakiyeliListe(null);


                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("PlasiyerKodu")))
                    if (HttpContext.Session.GetString("PlasiyerKodu") != "000")
                        query = query.Where(x => x.PlasierKodu == HttpContext.Session.GetString("PlasiyerKodu"));

                if (!string.IsNullOrEmpty(cariRaporListeFiltreModel.CariAdi))
                    query = query.Where(x => x.CariAdi.ToLower().Contains(cariRaporListeFiltreModel.CariAdi.ToLower()));

                if (cariRaporListeFiltreModel.CariGrupKod != null)
                    query = query.Where(x => x.CariGrup == cariRaporListeFiltreModel.CariGrupKod);

                if (cariRaporListeFiltreModel.CariRaporKod1 != null)
                    query = query.Where(x => x.CariRaporKod1 == cariRaporListeFiltreModel.CariRaporKod1);

                if (cariRaporListeFiltreModel.MaxBakiye != 0)
                    query = query.Where(x => x.Bakiye <= cariRaporListeFiltreModel.MaxBakiye);

                if (cariRaporListeFiltreModel.MinBakiye != 0)
                    query = query.Where(x => x.Bakiye >= cariRaporListeFiltreModel.MinBakiye);

                return Json(query.ToList());
            }
            catch (Exception ex)
            {

                var mess = ex.Message;

                return Json("");
            }
            
        }

        public JsonResult CariHaraketListe(string cariKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var query1 = _cariRepository.GetCariBilgiDetayli(cariKodu);
            var query2 = _cariRepository.GetCariHaraketListe(cariKodu);

            var list = new
            {
                cariBilgi = query1.ToList(),
                cariHaraket = query2.ToList()
            };

            return Json(list);
        }

        

        public JsonResult BakiyeliCariFiltreVerileri()
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            List<DbConnection> result;
            using (StreamReader r = new StreamReader("donemler.json"))
            {
                string json = r.ReadToEnd();
                result = DbConnection.FromJson(json);
            }

            var filtreVerileri = new
            {
                cariGrup = _cariRepository.GetCariGrup(),

                cariRaporKod = _cariRepository.GetCariRaporKod1(),

                donemler = result.Where(X=>X.Name!="BUYIL").Select(c => c.Name)
            };
            
            return Json(filtreVerileri);
        }

        public JsonResult BakiyeliCari(string cariKodu)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");
            List<DbConnection> result;
            using (StreamReader r = new StreamReader("donemler.json"))
            {
                string json = r.ReadToEnd();
                result = DbConnection.FromJson(json);
            }

            var cari = _cariRepository.GetCariBakiyeli(cariKodu);

            return Json(cari);

        }

    }
}