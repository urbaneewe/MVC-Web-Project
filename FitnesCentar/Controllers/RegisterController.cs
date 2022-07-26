using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registracija(Korisnik korisnik)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            korisnik.uloga = Uloga.POSETILAC;
            if (!korisnici.ContainsKey(korisnik.username))
            {
                korisnici.Add(korisnik.username, korisnik);
                Baza.LoadKorisnika(korisnik);
            }
            else
            {
                ViewBag.Error = "Username vec postoji\n";
            }
            return View("~/Views/Login/Index.cshtml");
        }
    }
}