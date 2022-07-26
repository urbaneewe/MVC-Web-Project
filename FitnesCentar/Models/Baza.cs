using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FitnesCentar.Models
{
    public class Baza
    {
        public static Dictionary<string, FitnessCentar> ReadCentar(string path)
        {
            Dictionary<string, FitnessCentar> centri = new Dictionary<string, FitnessCentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";

            while((line = sr.ReadLine()) != null)
            {
                string[] podaci = line.Split(';');
                int.TryParse(podaci[2], out int godinaOtvaranja);
                Enum.TryParse(podaci[7], true, out Pol pol);
                DateTime datumRodjenja = DateTime.ParseExact(podaci[9], "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Enum.TryParse(podaci[10], true, out Uloga uloga);
                Korisnik korisnik = new Korisnik(podaci[3], podaci[4], podaci[5], podaci[6], pol, podaci[8], datumRodjenja, uloga);
                int.TryParse(podaci[11], out int mesecnaClanarina);
                int.TryParse(podaci[12], out int godisnjaClanarina);
                int.TryParse(podaci[13], out int cenaTreninga);
                int.TryParse(podaci[14], out int cenaGrupnogTreninga);
                int.TryParse(podaci[15], out int cenaPersonalnogTreninga);
                bool.TryParse(podaci[16], out bool obrisan);

                FitnessCentar centar = new FitnessCentar(podaci[0], podaci[1], godinaOtvaranja, korisnik, mesecnaClanarina, godisnjaClanarina, 
                                                    cenaTreninga, cenaGrupnogTreninga, cenaPersonalnogTreninga, obrisan);
                centri.Add(centar.naziv, centar);
            }
            sr.Close();
            fs.Close();

            return centri;
        }

        public static Dictionary<int, Komentar> ReadKomentare(string path)
        {
            Dictionary<int, Komentar> komentari = new Dictionary<int, Komentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] podaci = line.Split(';');
                Enum.TryParse(podaci[4], true, out Pol pol);
                DateTime datumRodjenja = DateTime.ParseExact(podaci[6], "dd/MM/yyyy", CultureInfo.CurrentCulture);
                Enum.TryParse(podaci[7], true, out Uloga uloga);

                Korisnik korisnik = new Korisnik(podaci[0], podaci[1], podaci[2], podaci[3], pol, podaci[5], datumRodjenja, uloga);

                int.TryParse(podaci[10], out int godinaOtvaranja);
                int.TryParse(podaci[19], out int mesecnaClanarina);
                int.TryParse(podaci[20], out int godisnjaClanarina);
                int.TryParse(podaci[21], out int cenaTreninga);
                int.TryParse(podaci[22], out int cenaGrupnogTreninga);
                int.TryParse(podaci[23], out int cenaPersonalnogTreninga);
                bool.TryParse(podaci[24], out bool obrisan);

                FitnessCentar centar = new FitnessCentar(podaci[8], podaci[9], godinaOtvaranja, korisnik, mesecnaClanarina, godisnjaClanarina,
                                                    cenaTreninga, cenaGrupnogTreninga, cenaPersonalnogTreninga, obrisan);

                int.TryParse(podaci[26], out int ocena);
                bool.TryParse(podaci[27], out bool status);

                Komentar kom = new Komentar(korisnik, centar, podaci[25], ocena, status);

                komentari.Add(komentari.Count, kom);
            }
            sr.Close();
            fs.Close();

            return komentari;
        }

        public static Dictionary<string, GrupniTrening> ReadTreninge(string path)
        {
            Dictionary<string, GrupniTrening> grupni = new Dictionary<string, GrupniTrening>();
            path = HostingEnvironment.MapPath(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] podaci = line.Split(';');
                Enum.TryParse(podaci[1], true, out TipTreninga tipTreninga);
                Enum.TryParse(podaci[9], true, out Pol pol);
                DateTime datumRodjenja = DateTime.ParseExact(podaci[11], "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Enum.TryParse(podaci[7], true, out Uloga uloga);
                Korisnik korisnik = new Korisnik(podaci[5], podaci[6], podaci[7], podaci[8], pol, podaci[10], datumRodjenja, uloga);
                int.TryParse(podaci[4], out int godinaOtvaranja);
                int.TryParse(podaci[13], out int mesecnaClanarina);
                int.TryParse(podaci[14], out int godisnjaClanarina);
                int.TryParse(podaci[15], out int cenaTreninga);
                int.TryParse(podaci[16], out int cenaGrupnogTreninga);
                int.TryParse(podaci[17], out int cenaPersonalnogTreninga);
                bool.TryParse(podaci[18], out bool obrisan);
                FitnessCentar centar = new FitnessCentar(podaci[2], podaci[3], godinaOtvaranja, korisnik, mesecnaClanarina, godisnjaClanarina, cenaTreninga, cenaGrupnogTreninga,
                    cenaPersonalnogTreninga, obrisan);
                int.TryParse(podaci[19], out int trajanjeTreninga);
                DateTime datumTreninga = DateTime.ParseExact(podaci[20], "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                int.TryParse(podaci[21], out int maxPosetilaca);
                GrupniTrening treninzi = new GrupniTrening(podaci[0], tipTreninga, centar, trajanjeTreninga, datumTreninga, maxPosetilaca);

                grupni.Add(treninzi.naziv, treninzi);
            }
            sr.Close();
            fs.Close();

            return grupni;
        }

        public static Dictionary<string, Korisnik> ReadKorisnike(string path)
        {
            Dictionary<string, Korisnik> korisnici = new Dictionary<string, Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while((line = sr.ReadLine()) != null)
            {
                string[] podaci = line.Split(';');
                Enum.TryParse(podaci[4], true, out Pol pol);
                DateTime datumRodjenja = DateTime.ParseExact(podaci[6], "dd/MM/yyyy", CultureInfo.CurrentCulture);
                Enum.TryParse(podaci[7], true, out Uloga uloga);
                Korisnik korisnik = new Korisnik(podaci[0], podaci[1], podaci[2], podaci[3], pol, podaci[5], datumRodjenja, uloga);
                korisnici.Add(korisnik.username, korisnik);
            }
            sr.Close();
            fs.Close();

            return korisnici;
        }

        public static void LoadTreninge(GrupniTrening trening)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Grupni.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21}",
                    trening.naziv, trening.tipTreninga, trening.fitnesCentar.naziv, trening.fitnesCentar.adresa, trening.fitnesCentar.godinaOtvaranja,
                    trening.fitnesCentar.vlasnik.username, trening.fitnesCentar.vlasnik.lozinka, trening.fitnesCentar.vlasnik.ime, trening.fitnesCentar.vlasnik.prezime,
                    trening.fitnesCentar.vlasnik.pol, trening.fitnesCentar.vlasnik.email, trening.fitnesCentar.vlasnik.datumRodjenja.ToString("dd/MM/yyyy"), trening.fitnesCentar.vlasnik.uloga,
                    trening.fitnesCentar.mesecnaClanarina, trening.fitnesCentar.godisnjaClanarina, trening.fitnesCentar.cenaTreninga, trening.fitnesCentar.cenaGrupnogTreninga,
                    trening.fitnesCentar.cenaPersonalnogTreninga, trening.fitnesCentar.obrisan, trening.trajanjeTreninga, trening.datumTreninga.ToString("dd/MM/yyyy HH:mm"), trening.maxPosetilaca);
        }

        public static void LoadKomentare(Komentar komentar)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Komentari.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27}",
                    komentar.posetilac.username, komentar.posetilac.lozinka, komentar.posetilac.ime, komentar.posetilac.prezime, komentar.posetilac.pol,
                    komentar.posetilac.email, komentar.posetilac.datumRodjenja.ToString("dd/MM/yyyy"), komentar.posetilac.uloga, komentar.naziv.naziv, komentar.naziv.adresa,
                    komentar.naziv.godinaOtvaranja, komentar.naziv.vlasnik.username, komentar.naziv.vlasnik.lozinka, komentar.naziv.vlasnik.ime, komentar.naziv.vlasnik.prezime,
                    komentar.naziv.vlasnik.pol, komentar.naziv.vlasnik.email, komentar.naziv.vlasnik.datumRodjenja.ToString("dd/MM/yyyy"), komentar.naziv.vlasnik.uloga,
                    komentar.naziv.mesecnaClanarina, komentar.naziv.godisnjaClanarina, komentar.naziv.cenaTreninga, komentar.naziv.cenaGrupnogTreninga, komentar.naziv.cenaPersonalnogTreninga,komentar.naziv.obrisan,
                    komentar.tekst, komentar.ocena, komentar.status);
        }

        public static void LoadCentre(FitnessCentar centar)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Centri.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16}",
                    centar.naziv, centar.adresa, centar.godinaOtvaranja, centar.vlasnik.username, centar.vlasnik.lozinka, centar.vlasnik.ime,
                    centar.vlasnik.prezime, centar.vlasnik.pol, centar.vlasnik.email, centar.vlasnik.datumRodjenja.ToString("dd/MM/yyyy"), centar.vlasnik.uloga,
                    centar.mesecnaClanarina, centar.godisnjaClanarina, centar.cenaTreninga, centar.cenaGrupnogTreninga, centar.cenaPersonalnogTreninga, centar.obrisan);
        }

        public static void LoadKorisnika(Korisnik korisnik)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Korisnici.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}", korisnik.username,korisnik.lozinka, korisnik.ime, korisnik.prezime, korisnik.pol, 
                                                                  korisnik.email, korisnik.datumRodjenja.ToString("dd/MM/yyyy"), korisnik.uloga);
        }

        public static void DeleteCentre()
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Centri.txt");
            var file = File.Create(path);
            file.Close();
        }

        public static void DeleteTreninge()
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Grupni.txt");
            var file = File.Create(path);
            file.Close();
        }

        public static void DeleteKorisnike()
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Korisnici.txt");
            var file = File.Create(path);
            file.Close();
        }
    }
}