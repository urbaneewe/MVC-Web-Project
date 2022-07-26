using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class VlasnikController : Controller
    {
        // GET: Vlasnik
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrujTrenera(Korisnik korisnik)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            Korisnik korisnikTrenutni = (Korisnik)HttpContext.Session["korisnik"];

            korisnik.uloga = Uloga.TRENER;
            if (!korisnici.ContainsKey(korisnik.username))
            {
                foreach(FitnessCentar f in centri.Values)
                {
                    if(f.vlasnik.username == korisnikTrenutni.username && !korisnici.ContainsKey(korisnik.username))
                    {
                        korisnik.angazovanje.Add(f);
                    }
                }
                korisnici.Add(korisnik.username, korisnik);
                Baza.LoadKorisnika(korisnik);
            }
            else
            {
                ViewBag.Error = "Trener vec postoji ili niste uneli trazene podatke.\n";
            }

            return View("~/Views/Vlasnik/Index.cshtml");
        }
    }
}