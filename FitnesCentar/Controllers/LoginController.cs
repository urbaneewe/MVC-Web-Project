using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class LoginController : Controller
    {

        public bool ProveraKorisnika(string korisnickoIme, string lozinka)
        {
            bool izlaz = false;
            Dictionary<string, Korisnik> korisnici = (Dictionary<string,Korisnik>)HttpContext.Application["korisnici"];
            if (korisnici.ContainsKey(korisnickoIme))
                if (korisnici[korisnickoIme].lozinka.Equals(lozinka))
                    izlaz = true;
            return izlaz;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prijava(string korisnickoIme, string lozinka)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            //foreach(FitnessCentar f in centri.Values)
           // {
                //foreach(Korisnik k in korisnici.Values)
                //{
                    if (ProveraKorisnika(korisnickoIme, lozinka))
                    {
                        Session["korisnik"] = korisnici[korisnickoIme];
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Pogrešno korisničko ime ili lozinka";
                        return View("~/Views/Login/Index.cshtml");
                    }
                //}
           // }
        }

        public ActionResult Odjava()
        {
            Session["korisnik"] = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}