using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        UserRepository _userRepository;

        public AccountController()
        {
            _userRepository = new UserRepository();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {

            var user =  _userRepository.UserLogin(userName, password);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                ViewBag.userName = userName;
                ViewBag.password = password;
                ViewBag.message = "Giriş bilgileri yanlış";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("UserId",   user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.Kullanici);
                HttpContext.Session.SetString("Depo",     user.Depo);
                HttpContext.Session.SetString("PlasiyerKodu", user.PlasiyerKodu);
                HttpContext.Session.SetString("UserCariKodu", user.UserCariKodu==null?"": user.UserCariKodu);

                var webTeklif =  _userRepository.UserYetkiGetir(user.Id, 40200000);
                var webSiparis = _userRepository.UserYetkiGetir(user.Id, 40300000);
                var carirapor =  _userRepository.UserYetkiGetir(user.Id, 40100000);
                var cariHarrapor = _userRepository.UserYetkiGetir(user.Id, 40100001);
                var webIsAkis = _userRepository.UserYetkiGetir(user.Id, 40400000);
                var stokRapor = _userRepository.UserYetkiGetir(user.Id, 40500000);
                var motoservis = _userRepository.UserYetkiGetir(user.Id, 40600000);
                var motoservisAdmin = _userRepository.UserYetkiGetir(user.Id, 40700000);

                var webTeklifDurum      = (webTeklif    == null ? 0 : webTeklif.Yetki)      == 1 ? 1 : 0;
                var webSiparisDurum     = (webSiparis   == null ? 0 : webSiparis.Yetki)     == 1 ? 1 : 0;
                var cariraporDurum      = (carirapor    == null ? 0 : carirapor.Yetki)      == 1 ? 1 : 0;
                var webIsAkisDurum      = (webIsAkis    == null ? 0 : webIsAkis.Yetki)      == 1 ? 1 : 0;
                var cariHarRaporDurum   = (cariHarrapor == null ? 0 : cariHarrapor.Yetki)   == 1 ? 1 : 0;
                var stokraporDurum      = (stokRapor    == null ? 0 : stokRapor.Yetki)      == 1 ? 1 : 0;
                var motoservisDurum     = (motoservis   == null ? 0 : motoservis.Yetki)     == 1 ? 1 : 0;
                var motoservisAdminDurum = (motoservisAdmin == null ? 0 : motoservisAdmin.Yetki) == 1 ? 1 : 0;

                HttpContext.Session.SetInt32("CariRapor", cariraporDurum);
                HttpContext.Session.SetInt32("StokRapor", stokraporDurum);
                HttpContext.Session.SetInt32("WebTeklif", webTeklifDurum);
                HttpContext.Session.SetInt32("WebSiparis", webSiparisDurum);
                HttpContext.Session.SetInt32("WebIsAkis", webIsAkisDurum);
                HttpContext.Session.SetInt32("CariHaraketRapor", cariHarRaporDurum);
                HttpContext.Session.SetInt32("StokRapor", stokraporDurum);
                HttpContext.Session.SetInt32("MotoServis", motoservisDurum);
                HttpContext.Session.SetInt32("MotoServisAdmin", motoservisAdminDurum);
                return Redirect("~/");
            }


        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("Depo");
            HttpContext.Session.Remove("PlasiyerKodu");
            HttpContext.Session.Remove("UserCariKodu");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}