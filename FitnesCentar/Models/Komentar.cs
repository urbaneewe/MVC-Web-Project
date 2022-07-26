using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnesCentar.Models
{
    public class Komentar
    {
        public Komentar(Korisnik posetilac, FitnessCentar naziv, string tekst, int ocena, bool status)
        {
            this.posetilac = posetilac;
            this.naziv = naziv;
            this.tekst = tekst;
            this.ocena = ocena;
            this.status = status;
        }

        public Korisnik posetilac { get; set; }
        public FitnessCentar naziv { get; set; }
        public string tekst { get; set; }
        public int ocena { get; set; }
        public bool status { get; set; }
    }
}