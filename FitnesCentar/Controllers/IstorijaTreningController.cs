using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnesCentar.Controllers
{
    public class IstorijaTreningController : Controller
    {
        // GET: IstorijaTrening
        public ActionResult Index()
        {
            HttpContext.Application["istorija"] = HttpContext.Application["treninzi"];
            return View("~/Views/IstorijaTrening/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Pretraga(string nazivCentra, string nazivTreninga, string tipTreninga)
        {
            Dictionary<string, GrupniTrening> istorija = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];
            Dictionary<string, GrupniTrening> pretrazeniTrening = new Dictionary<string, GrupniTrening>();

            if (!tipTreninga.Equals(string.Empty))
            {
                pretrazeniTrening.Clear();
                istorija = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];
                
                foreach (GrupniTrening g in istorija.Values)
                {
                        if (g.tipTreninga.ToString() == tipTreninga)
                            if (!pretrazeniTrening.ContainsKey(g.naziv))
                                pretrazeniTrening.Add(g.naziv, g);

                    Dictionary<string, GrupniTrening> sortiraniTreninzi = new Dictionary<string, GrupniTrening>();
                    foreach (KeyValuePair<string, GrupniTrening> grupni in pretrazeniTrening.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniTreninzi.Add(grupni.Value.naziv, grupni.Value);

                    HttpContext.Application["istorija"] = sortiraniTreninzi;
                }
            }

            if (!nazivCentra.Equals(string.Empty))
            {
                pretrazeniTrening.Clear();
                istorija = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];

                foreach (GrupniTrening g in istorija.Values)
                {
                        if (g.fitnesCentar.naziv == nazivCentra)
                            if (!pretrazeniTrening.ContainsKey(g.naziv))
                                pretrazeniTrening.Add(g.naziv, g);

                    Dictionary<string, GrupniTrening> sortiraniTreninzi = new Dictionary<string, GrupniTrening>();
                    foreach (KeyValuePair<string, GrupniTrening> grupni in pretrazeniTrening.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniTreninzi.Add(grupni.Value.naziv, grupni.Value);

                    HttpContext.Application["istorija"] = sortiraniTreninzi;
                }
            }

            if (!nazivTreninga.Equals(string.Empty))
            {
                pretrazeniTrening.Clear();
                istorija = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];

                foreach (GrupniTrening g in istorija.Values)
                {
                        if (g.naziv == nazivTreninga)
                            if (!pretrazeniTrening.ContainsKey(g.naziv))
                                pretrazeniTrening.Add(g.naziv, g);

                    Dictionary<string, GrupniTrening> sortiraniTreninzi = new Dictionary<string, GrupniTrening>();
                    foreach (KeyValuePair<string, GrupniTrening> grupni in pretrazeniTrening.OrderBy(naziv => naziv.Value.naziv))
                        sortiraniTreninzi.Add(grupni.Value.naziv, grupni.Value);

                    HttpContext.Application["istorija"] = sortiraniTreninzi;
                }
            }

            HttpContext.Application["istorija"] = pretrazeniTrening;
            return View("~/Views/IstorijaTrening/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Sortiranje(string podatakZaSortiranje, string tipSortiranja)
        {
            Dictionary<string, GrupniTrening> istorija = (Dictionary<string, GrupniTrening>)HttpContext.Application["istorija"];
            Dictionary<string, GrupniTrening> sortiraniTrening = new Dictionary<string, GrupniTrening>();

            switch (podatakZaSortiranje)
            {
                case "Naziv treninga":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderBy(x => x.Value.naziv))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderByDescending(x => x.Value.naziv))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }

                case "Tip treninga":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderBy(x => x.Value.tipTreninga))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderByDescending(x => x.Value.tipTreninga))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }
                case "Datum i vreme":
                    {
                        if (tipSortiranja.Equals("Rastuce"))
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderBy(x => x.Value.datumTreninga))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, GrupniTrening> fit in istorija.OrderByDescending(x => x.Value.datumTreninga))
                                sortiraniTrening.Add(fit.Value.naziv, fit.Value);
                        }
                        break;
                    }
                default:
                    {
                        foreach (KeyValuePair<string, GrupniTrening> f in istorija.OrderBy(naziv => naziv.Value.naziv))
                            sortiraniTrening.Add(f.Value.naziv, f.Value);
                        break;
                    }
            }
            HttpContext.Application["istorija"] = sortiraniTrening;
            return View("~/Views/IstorijaTrening/Index.cshtml");

        }
    }
}