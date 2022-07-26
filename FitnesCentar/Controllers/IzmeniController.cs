using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class IzmeniController : Controller
    {
        // GET: Izmeni
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IzmeniCentar(FitnessCentar centar)
        {
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            centri[centar.naziv] = centar;
            HttpContext.Application["centri"] = centri;
            HttpContext.Session["centar"] = centar;
            ViewBag.Poruka = "Uspesno izmenjen centar";

            Baza.DeleteCentre();

            foreach (FitnessCentar f in centri.Values)
                Baza.LoadCentre(f);

            return View("~/Views/Profil/Index.cshtml");
        }
    }
}