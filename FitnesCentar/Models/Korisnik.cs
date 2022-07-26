using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnesCentar.Models
{
    public enum Uloga
    {
        POSETILAC,
        TRENER,
        VLASNIK
    }

    public enum Pol
    {
        MUSKI,
        ZENSKI
    }

    public class Korisnik
    {
        public string username { get; set; }
        public string lozinka { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public Pol pol { get; set; }
        public string email { get; set; }
        public DateTime datumRodjenja { get; set; }
        public Uloga uloga { get; set; }
        public Dictionary<string, GrupniTrening> listaTreninga { get; set; }
        public List<FitnessCentar> angazovanje { get; set; }

        public Korisnik() { listaTreninga = new Dictionary<string, GrupniTrening>(); angazovanje = new List<FitnessCentar>(); }

        public Korisnik(string username, string lozinka, string ime, string prezime, Pol pol, string email, DateTime datumRodjenja, Uloga uloga)
        {
            this.username = username;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
            this.pol = pol;
            this.email = email;
            this.datumRodjenja = datumRodjenja;
            this.uloga = uloga;

            listaTreninga = new Dictionary<string, GrupniTrening>();
            angazovanje = new List<FitnessCentar>();
        }
        

    }
}