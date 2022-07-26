using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class TreningPrijaveController : Controller
    {
        // GET: TreningPrijave
        public ActionResult Index()
        {
            /*Dictionary<string, GrupnePrijave> prijave = (Dictionary<string, GrupnePrijave>)HttpContext.Application["prijave"];
            Korisnik korisnik = (Korisnik)HttpContext.Session["korisnik"];

            korisnik.listaTreninga = prijave;
            HttpContext.Session["korisnik"] = korisnik;*/
            return View();
        }


        [HttpPost]
        public ActionResult Zakazi(string nazivTreninga)
        {
            Dictionary<string, GrupniTrening> treninzi = (Dictionary<string, GrupniTrening>)HttpContext.Application["treninzi"];
            Dictionary<string, GrupniTrening> istorijaTreninga = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];
            Korisnik korisnik = (Korisnik)HttpContext.Session["korisnik"];

            if (treninzi[nazivTreninga].korisnici.ContainsKey(korisnik.username))
            {
                ViewBag.Error = "Vec ste prijavljeni na trening!"; 
            }
            else
            {
                treninzi[nazivTreninga].korisnici.Add(korisnik.username, korisnik);
                treninzi[nazivTreninga].maxPosetilaca--;
                istorijaTreninga.Add(nazivTreninga ,treninzi[nazivTreninga]);
                HttpContext.Application["treninzi"] = treninzi;
            }
                
            return View("~/Views/Informacije/Index.cshtml");
        }
    }
}