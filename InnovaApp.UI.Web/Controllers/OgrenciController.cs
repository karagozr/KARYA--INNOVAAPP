using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data.OgrenciServis;
using InnovaApp.Entities.Models.OgrenciServis;
using InnovaApp.UI.Web.Models.OgrenciServis;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class OgrenciController : Controller
    {
        OgrenciBll _ogrenciBll;
        OkulBll _okulBll;
        OgrenciBolgeBll _ogrenciBolgeBll;
        TahakkukBll _tahakkukBll;
        TahakkukDetayBll _tahakkukDetayBll;
        public OgrenciController()
        {
            _ogrenciBolgeBll = new OgrenciBolgeBll();
            _ogrenciBll = new OgrenciBll();
            _okulBll = new OkulBll();
            _tahakkukBll = new TahakkukBll();
            _tahakkukDetayBll = new TahakkukDetayBll();
        }

        public IActionResult OgrenciListe(int OkulId=0, bool Durum=true)
        {
            

            var val = _tahakkukDetayBll.TahakkukDetayGetir("aaaa-aaaa").ToList();

            var query = _ogrenciBll.OgrenciListe(null).Where(x=>x.Durum==Durum);

            if (OkulId != 0)
                query = query.Where(x=>x.OkulId== OkulId);


            var model = new OgrenciModel
            {
                OkulId = 0,
                OkulListesi = _okulBll.OkulListe(null).ToList(),
                OgreciBolgeListesi = _ogrenciBolgeBll.OgrenciBolgeListe(null).ToList(), 
                OgrenciListesi = query.ToList()
            };

            return View(model);
        }

        //[HttpPost]
        //public IActionResult OgrenciListe(int OkulId, bool Durum)
        //{
        //    var query = _ogrenciBll.OgrenciListe(null).Where(x => x.Durum == true);


        //    var model = new OgrenciModel
        //    {
        //        OkulId = 0,
        //        OkulListesi = _okulBll.OkulListe(null).ToList(),
        //        OgreciBolgeListesi = _ogrenciBolgeBll.OgrenciBolgeListe(null).ToList(),
        //        OgrenciListesi = query.ToList()
        //    };

        //    return View(model);
        //}

        public IActionResult OgrenciBolgeListe()
        {
            var model = new OgrenciBolgeModel
            {
                OgrenciBolge = _ogrenciBolgeBll.OgrenciBolgeListe(null).ToList()
            };

            return View(model);
        }

        public JsonResult OgrenciBolgeEkleDuzenle(OgrenciBolge model)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                if (model.Id >= 1)
                {
                    string[] props = { "BolgeAdi", "BolgeKodu", "Aciklama" };
                    _ogrenciBolgeBll.Update(new OgrenciBolge()
                    {
                        Id = model.Id,
                        BolgeAdi = model.BolgeAdi,
                        BolgeKodu = model.BolgeKodu,
                        Aciklama = model.Aciklama

                    }, props);

                    return Json("True");
                }
                else
                {

                    _ogrenciBolgeBll.Insert(new OgrenciBolge()
                    {
                        Id = model.Id,
                        BolgeAdi = model.BolgeAdi,
                        BolgeKodu = model.BolgeKodu,
                        Aciklama = model.Aciklama

                    });

                    return Json("True");
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                throw;
            }



        }

        public JsonResult OgrenciGetir(int id)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var query = _ogrenciBll.OgrenciGetir(id);

            return Json(query);

        }

        
        public JsonResult OgrenciAktifPasifEt(bool durum,int id)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                string[] props = { "Durum" };
                _ogrenciBll.Update(new Ogrenci()
                {
                    Id = id,
                    Durum = durum
                }, props);

                return Json("True");

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                throw;
            }



        }

        public JsonResult OgrenciEkleDuzenle(OgrenciModel ogrenciModel)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var model = ogrenciModel.Ogrenci;

            try
            {
                if (model.Id >= 1)
                {
                    string[] props = { "OkulId", "Sinif", "OgrenciTcNo", "OgrenciAdi", "OgrenciSoyadi", "BolgeId", "Adres", "KayitTarihi", "Aciklama" };
                    _ogrenciBll.Update(new Ogrenci()
                    {
                        Id = model.Id,
                        OkulId = model.OkulId,
                        Sinif = model.Sinif,
                        OgrenciTcNo = model.OgrenciTcNo,
                        OgrenciAdi = model.OgrenciAdi,
                        OgrenciSoyadi = model.OgrenciSoyadi,
                        BolgeId = model.BolgeId,
                        Adres = model.Adres,
                        KayitTarihi = model.KayitTarihi,
                        Aciklama = model.Aciklama
                    }, props);

                    return Json("True");
                }
                else
                {

                    _ogrenciBll.Insert(new Ogrenci()
                    {
                        Id = model.Id,
                        Guid = Guid.NewGuid().ToString(),
                        Durum = true,
                        OkulId = model.OkulId,
                        Sinif = model.Sinif,
                        OgrenciTcNo = model.OgrenciTcNo,
                        OgrenciAdi = model.OgrenciAdi,
                        OgrenciSoyadi = model.OgrenciSoyadi,
                        BolgeId = model.BolgeId,
                        Adres = model.Adres,
                        KayitTarihi = model.KayitTarihi,
                        Aciklama = model.Aciklama
                    });

                    return Json("True");
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                throw;
            }



        }
    }
}