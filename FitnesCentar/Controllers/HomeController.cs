using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dictionary<string, FitnessCentar> centri = Baza.ReadCentar("~/App_Data/Centri.txt");
            HttpContext.Application["centri"] = centri;


            Dictionary<string, FitnessCentar> sortiraniCentri = new Dictionary<string, FitnessCentar>();
            foreach (KeyValuePair<string, FitnessCentar> f in centri.OrderBy(naziv => naziv.Value.naziv))
                sortiraniCentri.Add(f.Value.naziv, f.Value);
            HttpContext.Application["centri"] = sortiraniCentri;

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Pretraga(string godinaOtvaranjaOd, string godinaOtvaranjaDo, string nazivCentra, string adresaCentra)
        {
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            Dictionary<string, FitnessCentar> pretrazeniCentri = new Dictionary<string, FitnessCentar>();

            string goOd = (string)HttpContext.Application["goOd"];
            string goDo = (string)HttpContext.Application["goDo"];

            if (!godinaOtvaranjaDo.Equals(string.Empty) && !godinaOtvaranjaOd.Equals(string.Empty))
            {
                pretrazeniCentri.Clear();
                centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];

                foreach (FitnessCentar f in centri.Values)
                {
                    if (Int32.Parse(godinaOtvaranjaOd) <= f.godinaOtvaranja && Int32.Parse(godinaOtvaranjaDo) >= f.godinaOtvaranja)
                        if (!pretrazeniCentri.ContainsKey(f.naziv))
                            pretrazeniCentri.Add(f.naziv, f);
                    HttpContext.Application["centri"] = pretrazeniCentri;

                    Dictionary<string, FitnessCentar> sortiraniCentri = new Dictionary<string, FitnessCentar>();
                    foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                    HttpContext.Application["centri"] = sortiraniCentri;
                }
            }

            if (!nazivCentra.Equals(string.Empty))
            {
                pretrazeniCentri.Clear();
                centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];

                foreach (FitnessCentar f in centri.Values)
                {
                    if (f.naziv.Contains(nazivCentra))
                        if (!pretrazeniCentri.ContainsKey(f.naziv))
                            pretrazeniCentri.Add(f.naziv, f);

                    Dictionary<string, FitnessCentar> sortiraniCentri = new Dictionary<string, FitnessCentar>();
                    foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                    HttpContext.Application["centri"] = sortiraniCentri;
                }
            }

            if (!adresaCentra.Equals(string.Empty))
            {
                pretrazeniCentri.Clear();
                centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];

                foreach (FitnessCentar f in centri.Values)
                {
                    if (f.adresa.Contains(adresaCentra))
                        if (!pretrazeniCentri.ContainsKey(f.naziv))
                            pretrazeniCentri.Add(f.naziv, f);

                    Dictionary<string, FitnessCentar> sortiraniCentri = new Dictionary<string, FitnessCentar>();
                    foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                    HttpContext.Application["centri"] = sortiraniCentri;
                }
            }
            HttpContext.Application["centri"] = pretrazeniCentri;
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Sortiranje(string tipSortiranja, string podatakZaSortiranje)
        {
            Dictionary<string, FitnessCentar> centri = (Dictionary<string, FitnessCentar>)HttpContext.Application["centri"];
            Dictionary<string, FitnessCentar> sortiraniCentri = new Dictionary<string, FitnessCentar>();

            switch (podatakZaSortiranje)
            {
                case "Naziv centra":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.naziv))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderByDescending(naziv => naziv.Value.naziv))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }

                case "Adresa centra":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.adresa))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderByDescending(naziv => naziv.Value.adresa))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }
                case "Godina otvaranja centra":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderBy(naziv => naziv.Value.godinaOtvaranja))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, FitnessCentar> fit in centri.OrderByDescending(naziv => naziv.Value.godinaOtvaranja))
                                sortiraniCentri.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }
                default:
                    {
                        foreach (KeyValuePair<string, FitnessCentar> f in centri.OrderBy(naziv => naziv.Value.naziv))
                            sortiraniCentri.Add(f.Value.naziv, f.Value);
                        break;
                    }   
            }

            HttpContext.Application["centri"] = sortiraniCentri;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}