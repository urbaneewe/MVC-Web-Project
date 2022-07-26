using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnesCentar.Models
{
    public enum Status { AKTIVAN, OTKAZAN }

    public class GrupnePrijave
    {
        public string id { get; set; }
        public Korisnik korisnik { get; set; }
        public GrupniTrening trening { get; set; }
        public Status status { get; set; }

        public GrupnePrijave() { }

        public GrupnePrijave(string id, Korisnik korisnik, GrupniTrening trening, Status status)
        {
            this.id = id;
            this.korisnik = korisnik;
            this.trening = trening;
            this.status = status;
        }
    }
}