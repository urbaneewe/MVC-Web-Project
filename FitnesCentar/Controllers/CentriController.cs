using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class CentriController : Controller
    {
        // GET: Centri
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObrisiCentar(string naziv)
        {
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            centri[naziv].obrisan = true;
            HttpContext.Application["centri"] = centri;

            Baza.DeleteCentre();
            foreach(FitnessCentar f in centri.Values)
            {
                Baza.LoadCentre(f);
            }

            return View("~/Views/Centri/Index.cshtml");
        }

        [HttpPost]
        public ActionResult VratiCentar(string naziv)
        {
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            centri[naziv].obrisan = false
;
            HttpContext.Application["centri"] = centri;

            Baza.DeleteCentre();
            foreach (FitnessCentar f in centri.Values)
            {
                Baza.LoadCentre(f);
            }

            return View("~/Views/Centri/Index.cshtml");
        }

        [HttpPost]
        public ActionResult KreirajCentar(FitnessCentar centar)
        {
            Korisnik korisnik = (Korisnik)HttpContext.Session["korisnik"];
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];

            centar.vlasnik = korisnik;
            centar.obrisan = false;
            if (!centri.ContainsKey(centar.naziv))
            {
                centri.Add(centar.naziv, centar);
                Baza.LoadCentre(centar);
            }
            else
            {
                ViewBag.Error = "Centar sa tim imenom vec postoji\n";
            }
            return View("~/Views/Centri/Index.cshtml");

        }
    }
}