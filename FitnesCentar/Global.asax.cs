using FitnesCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FitnesCentar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpContext.Current.Application["istorija"] = new Dictionary<string, GrupniTrening>();


            Dictionary<string, FitnessCentar> startCentar = Baza.ReadCentar("~/App_Data/Centri.txt");
            HttpContext.Current.Application["centri"] = startCentar;

            Dictionary<string, Korisnik> startKorisnici = Baza.ReadKorisnike("~/App_Data/Korisnici.txt");
            HttpContext.Current.Application["korisnici"] = startKorisnici;

            Dictionary<string, GrupniTrening> startTreninzi = Baza.ReadTreninge("~/App_Data/Grupni.txt");
            HttpContext.Current.Application["treninzi"] = startTreninzi;

            Dictionary<int, Komentar> startKomentari = Baza.ReadKomentare("~/App_Data/Komentari.txt");
            HttpContext.Current.Application["komentari"] = startKomentari;

        }
    }
}
