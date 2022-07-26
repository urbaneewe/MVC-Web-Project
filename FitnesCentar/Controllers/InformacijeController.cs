using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class InformacijeController : Controller
    {
        // GET: Informacije
        public ActionResult Index()
        {
            Dictionary<string, GrupniTrening> treninzi = Baza.ReadTreninge("~/App_Data/Grupni.txt");
            HttpContext.Application["treninzi"] = treninzi;

            Dictionary<int, Komentar> komentari = Baza.ReadKomentare("~/App_Data/Komentari.txt");
            HttpContext.Application["komentari"] = komentari;

            return View("~/Views/Informacije/Index.cshtml");
        }

        [HttpPost]
        public ActionResult OstaviKomentar(string tekst, int ocena)
        {
            Dictionary<int, Komentar> komentari = (Dictionary<int, Komentar>)HttpContext.Application["komentari"];
            Korisnik korisnik = (Korisnik)HttpContext.Session["korisnik"];
            FitnessCentar centar = (FitnessCentar)HttpContext.Application["centar"];
            Dictionary<string, GrupniTrening> istorijaTreninga = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];
            bool imao = false;

            if (istorijaTreninga.Count > 0)
            {
                foreach(GrupniTrening g in istorijaTreninga.Values)
                {
                    if (g.fitnesCentar.naziv.Equals(centar.naziv))
                    {
                        imao = true;
                    }
                }
            }

            if (!imao)
            {
                ViewBag.Error2 = "Morate biti prijavljeni na neki trening da bi ste ostavili komnentar";
            }
            else if (ocena < 1 || ocena > 5)
            {
                ViewBag.Error2 = "Ocena mora biti na skali 1 do 5";
            }
            else
            {
                Komentar komentar = new Komentar(korisnik, centar, tekst, ocena, false);
                komentari.Add(komentari.Count, komentar);
                Baza.LoadKomentare(komentar);
            }

            return View("~/Views/Informacije/Index.cshtml");
        }

        [HttpPost]
        public ActionResult PrikaziInformacijeCentra(string naziv)
        {
            Dictionary<string, FitnessCentar> centri = Baza.ReadCentar("~/App_Data/Centri.txt");
            HttpContext.Application["centri"] = centri;

            System.Web.HttpContext.Current.Application["centar"] = centri[naziv];
            return View("~/Views/Informacije/Index.cshtml");
        }
    }
}