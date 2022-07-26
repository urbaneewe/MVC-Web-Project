using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Azuriranje(Korisnik korisnik)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            korisnici[korisnik.username] = korisnik;
            HttpContext.Application["korisnici"] = korisnici;
            HttpContext.Session["korisnik"] = korisnik;
            ViewBag.Poruka = "Uspesno izmenjen profil";

            Baza.DeleteKorisnike();

            foreach (Korisnik k in korisnici.Values)
                Baza.LoadKorisnika(k);

            return View("~/Views/Profil/Index.cshtml");
        }
    }
}