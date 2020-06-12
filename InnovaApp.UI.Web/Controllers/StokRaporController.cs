using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data.Netsis;
using InnovaApp.Entities.Models.Netsis;
using InnovaApp.UI.Web.Models.StokRapor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class StokRaporController : Controller
    {
        StokRepository _stokRepository;
        StokDapperRepository _stokDapperRepository;
        public StokRaporController()
        {
            _stokRepository = new StokRepository();
            _stokDapperRepository = new StokDapperRepository();

        }
        public IActionResult Liste()
        {
            var model = new StokAraModel
            {
                StokGruplar = _stokRepository.StokGrublari(),
                StokKodlar1 = _stokRepository.StokKodlari1(),
                StokKodlar2 = _stokRepository.StokKodlari2(),
                StokKodlar3 = _stokRepository.StokKodlari3(),
                StokKodlar4 = _stokRepository.StokKodlari4()
            };

            return View(model);
        }

        public JsonResult StokBakiyeliListesi(string stokKodu, string stokAdi, string grup, string kod1, string kod2, string kod3, string kod4)
        {
            if (HttpContext.Session.GetString("UserId") == null) return Json("");

            var result = _stokDapperRepository.StokBakiyeliListe(stokKodu, stokAdi, grup, kod1, kod2, kod3, kod4);
            return Json(result);
        }



    }
}