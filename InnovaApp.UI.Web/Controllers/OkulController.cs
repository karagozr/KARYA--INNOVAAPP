using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data.OgrenciServis;
using InnovaApp.Entities.Models.OgrenciServis;
using InnovaApp.UI.Web.Models.OgrenciServis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class OkulController : Controller
    {
        OkulBll _okulBll;
        public OkulController()
        {
            _okulBll = new OkulBll();
        }
        public IActionResult OkulListe()
        {
            var model = new OkulModel
            {
                OkulListe = _okulBll.OkulListe(null).ToList()
            };
                
            return View(model);
        }

        public JsonResult OkulEkleDuzenle(Okul model)
        {
            //if (HttpContext.Session.GetString("UserId") == null) return Json("");

            try
            {
                if (model.Id >= 1)
                {
                    string[] props = { "OkulAdi", "OkulKodu", "Aciklama", "Durum" };
                    _okulBll.Update(new Okul()
                    {
                        Id = model.Id,
                        OkulKodu = model.OkulKodu,
                        OkulAdi = model.OkulAdi,
                        Aciklama = model.Aciklama,
                        Durum = model.Durum

                    }, props);

                    return Json("True");
                }
                else
                {

                    _okulBll.Insert(new Okul()
                    {
                        Guid = Guid.NewGuid().ToString(),
                        Id = model.Id,
                        OkulKodu = model.OkulKodu,
                        OkulAdi = model.OkulAdi,
                        Aciklama = model.Aciklama,
                        Durum = model.Durum

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