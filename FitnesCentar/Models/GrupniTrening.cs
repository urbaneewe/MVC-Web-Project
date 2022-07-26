using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnesCentar.Models
{
    public enum TipTreninga { YOGA, BODYPUMP, CARDIO }

    public class GrupniTrening
    {
        public string naziv { get; set; }
        public TipTreninga tipTreninga { get; set; }
        public FitnessCentar fitnesCentar { get; set; }
        public int trajanjeTreninga { get; set; }
        public DateTime datumTreninga { get; set; }
        public int maxPosetilaca { get; set; }
        public Dictionary<string, Korisnik> korisnici { get; set; }

        public GrupniTrening() { korisnici = new Dictionary<string, Korisnik>(); }

        public GrupniTrening(string naziv, TipTreninga tipTreninga, FitnessCentar fitnesCentar, int trajanjeTreninga, DateTime datumTreninga, int maxPosetilaca)
        {           
            this.naziv = naziv;
            this.tipTreninga = tipTreninga;
            this.fitnesCentar = fitnesCentar;
            this.trajanjeTreninga = trajanjeTreninga;
            this.datumTreninga = datumTreninga;
            this.maxPosetilaca = maxPosetilaca;

            korisnici = new Dictionary<string, Korisnik>();
        }
    }
}