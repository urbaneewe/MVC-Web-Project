using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnesCentar.Models
{
    public class FitnessCentar
    {
        public string naziv { get; set; }
        public string adresa { get; set; }
        public int godinaOtvaranja { get; set; }
        public Korisnik vlasnik { get; set; }
        public int mesecnaClanarina { get; set; }
        public int godisnjaClanarina { get; set; }
        public int cenaTreninga { get; set; }
        public int cenaGrupnogTreninga { get; set; }
        public int cenaPersonalnogTreninga { get; set; }
        public bool obrisan { get; set; }

        public FitnessCentar() { }

        public FitnessCentar(string naziv, string adresa, int godinaOtvaranja, Korisnik vlasnik, int mesecnaClanarina, int godisnjaClanarina, int cenaTreninga, int cenaGrupnogTreninga, int cenaPersonalnogTreninga, bool obrisan)
        {
            this.naziv = naziv;
            this.adresa = adresa;
            this.godinaOtvaranja = godinaOtvaranja;
            this.vlasnik = vlasnik;
            this.mesecnaClanarina = mesecnaClanarina;
            this.godisnjaClanarina = godisnjaClanarina;
            this.cenaTreninga = cenaTreninga;
            this.cenaGrupnogTreninga = cenaGrupnogTreninga;
            this.cenaPersonalnogTreninga = cenaPersonalnogTreninga;
            this.obrisan = obrisan;
        }
    }
}