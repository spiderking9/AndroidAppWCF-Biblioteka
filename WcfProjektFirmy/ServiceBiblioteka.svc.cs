using System;
using System.Collections.Generic;
using System.Linq;
using WcfProjektFirmy.Model.Entieties;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;

namespace WcfProjektFirmy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceBiblioteka : IServiceBiblioteka
    {
        BibliotekaPlutaLukaszEntities db;
        public ServiceBiblioteka()
        {
            db = new BibliotekaPlutaLukaszEntities();
        }

        public List<AutorForView> GetAutor()
        {
            return
            (
                from autor in db.Autor
                where autor.IsActive == true
                select new
                {
                    IdAutora = autor.IdAutora,
                    Imie = autor.Imie,
                    Nazwisko = autor.Nazwisko,
                    Opis = autor.Opis,
                    Ksiazki = autor.Ksiazka_Autor.Select(ksiazka => ksiazka.Ksiazka.Tytul).ToList(),
                    IsActive = autor.IsActive
                }
                ).AsEnumerable().Select(autor =>
               new AutorForView
               {
                   IdAutora = autor.IdAutora,
                   Imie = autor.Imie,
                   Nazwisko = autor.Nazwisko,
                   Opis = autor.Opis,
                   Ksiazki = autor.Ksiazki.Count > 0 ? autor.Ksiazki.Aggregate((x, y) => x + ',' + y) : "brak",
                   IsActive = autor.IsActive
               }

            ).ToList();
        }

        public List<CzytelnikForView> GetCzytelnik()
        {
            return
            (
                from czyte in db.Czytelnik
                where czyte.IsActive == true
                select new CzytelnikForView
                {
                    IdCzytelnika = czyte.IdCzytelnika,
                    Imie = czyte.Imie,
                    Nazwisko = czyte.Nazwisko,
                    Adres = czyte.Adres,
                    Pesel = czyte.Pesel,
                    IsActive = czyte.IsActive
                }
            ).ToList();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<EgzemplarzForView> GetEgzemplarz()
        {
            return
            (
                from egz in db.Egzemplarz
                where egz.IsActive == true
                select new EgzemplarzForView
                {
                    IdEgzemplarza = egz.IdEgzemplarza,
                    IdKsiazki = egz.IdKsiazki,
                    KsiazkaTytul = egz.Ksiazka.Tytul,
                    RokWydania = egz.RokWydania,
                    IdCzytelnika = egz.IdCzytelnika,
                    CzytelnikNazwisko = egz.Czytelnik.Imie.Trim() + " " + egz.Czytelnik.Nazwisko,
                    DataWypozyczenia = egz.DataWypozyczenia,
                    DataOddania = egz.DataOddania,
                    IdPracownika = egz.IdPracownika,
                    PracownikNazwisko = egz.Pracownicy.Imie.Trim() + " " + egz.Pracownicy.Nazwisko
                }
            ).ToList();
        }

        public List<FilieForView> GetFilie()
        {
            return
            (
                from filie in db.FilieBiblioteki
                where filie.IsActive == true
                select new FilieForView
                {
                    IdFili = filie.IdFili,
                    Adres = filie.Adres,
                    Nazwa = filie.Nazwa
                }).ToList();
        }

        public List<GatunekForView> GetGatunek()
        {
            return (
                from gat in db.Gatunek
                where gat.IsActive == true
                select new GatunekForView
                {
                    IdGatunku = gat.IdGatunku,
                    NazwaGatunku = gat.NazwaGatunku,
                    Opis = gat.Opis
                }
                ).ToList();
        }

        public List<KsiazkaForView> GetKsiazka()
        {
            return (
                from ksiaz in db.Ksiazka
                where ksiaz.IsActive == true
                select new
                {
                    IdKsiazki = ksiaz.IdKsiazki,
                    IdGatunku = ksiaz.IdGatunku,
                    GatunekNazwa = ksiaz.Gatunek.NazwaGatunku,
                    LiczbaEgzDostepnych = ksiaz.LiczbaEgzDostepnych,
                    Tytul = ksiaz.Tytul,
                    Autorzy = ksiaz.Ksiazka_Autor.Select(autorzy => autorzy.Autor.Imie + " " + autorzy.Autor.Nazwisko).ToList()
                }
                ).AsEnumerable().Select(
                ksiaz => new KsiazkaForView
                {
                    IdKsiazki = ksiaz.IdKsiazki,
                    IdGatunku = ksiaz.IdGatunku,
                    GatunekNazwa = ksiaz.GatunekNazwa,
                    LiczbaEgzDostepnych = ksiaz.LiczbaEgzDostepnych,
                    Tytul = ksiaz.Tytul,
                    Autorzy = ksiaz.Autorzy.Count > 0 ? ksiaz.Autorzy.Aggregate((x, y) => x + ',' + y) : "brak"
                }
                ).ToList();
        }

        public List<KsiegarniaForView> GetKsiegarnia()
        {
            return (
                from ksieg in db.Ksiegarnia
                where ksieg.IsActive == true
                select new KsiegarniaForView
                {
                    IdKsiegarni = ksieg.IdKsiegarni,
                    Nazwa = ksieg.Nazwa,
                    Adres = ksieg.Adres
                }
                ).ToList();
        }

        public List<PracownicyForView> GetPracownicy()
        {
            return (
                from prac in db.Pracownicy
                where prac.IsActive == true
                select new PracownicyForView
                {
                    IdPracownika = prac.IdPracownika,
                    IdFilii = prac.IdFilii,
                    FiliaNazwa = prac.FilieBiblioteki.Nazwa,
                    Imie = prac.Imie,
                    Nazwisko = prac.Nazwisko,
                    Pesel = prac.Pesel
                }
                ).ToList();
        }

        public List<ZamowieniaForView> GetZamowienia()
        {
            return (
                from zamow in db.Zamowienia
                where zamow.IsActive == true
                select new ZamowieniaForView
                {
                    IdZamowienia = zamow.IdZamowienia,
                    IdKsiazki = zamow.IdKsiazki,
                    KsiazkaTytul = zamow.Ksiazka.Tytul,
                    IdKsiegarni = zamow.IdKsiegarni,
                    KsiegarniaNazwa = zamow.Ksiegarnia.Nazwa,
                    IdPracownika = zamow.IdPracownika,
                    PracownikNazwisko = zamow.Pracownicy.Imie + " " + zamow.Pracownicy.Nazwisko,
                    RokWydania = zamow.RokWydania
                }
                ).ToList();
        }
        public void AddAutor(Autor autor)
        {
            db.Autor.Add(autor);
            db.SaveChanges();
        }
        public void AddCzytelnik(Czytelnik czytelnik)
        {
            db.Czytelnik.Add(czytelnik);
            db.SaveChanges();
        }

        public void AddEgzemplarz(Egzemplarz egzem)
        {
            db.Egzemplarz.Add(egzem);
            db.SaveChanges();
        }

        public void AddFilia(FilieBiblioteki filie)
        {
            db.FilieBiblioteki.Add(filie);
            db.SaveChanges();
        }

        public void AddKsiazka(Ksiazka ksiazka)
        {
            db.Ksiazka.Add(ksiazka);
            db.SaveChanges();
        }

        public void AddKsiegarnia(Ksiegarnia ksieg)
        {
            db.Ksiegarnia.Add(ksieg);
            db.SaveChanges();
        }

        public void AddPracownicy(Pracownicy prac)
        {
            db.Pracownicy.Add(prac);
            db.SaveChanges();
        }

        public void AddZamowienia(Zamowienia zamow)
        {
            db.Zamowienia.Add(zamow);
            db.SaveChanges();
        }

        public void AddGatunki(Gatunek gatunek)
        {
            db.Gatunek.Add(gatunek);
            db.SaveChanges();
        }

        public void EditAutor(Autor autor)
        {
            var zmiana = db.Autor.Where(a => a.IdAutora == autor.IdAutora).FirstOrDefault();
            zmiana.Imie = autor.Imie;
            zmiana.Nazwisko = autor.Nazwisko;
            zmiana.Opis = autor.Opis;
            db.SaveChanges();
        }

        public void EditCzytelnik(Czytelnik czytelnik)
        {
            var zmiana = db.Czytelnik.Where(a => a.IdCzytelnika == czytelnik.IdCzytelnika).FirstOrDefault();
            zmiana.Imie = czytelnik.Imie;
            zmiana.Nazwisko = czytelnik.Nazwisko;
            zmiana.Pesel = czytelnik.Pesel;
            zmiana.Adres = czytelnik.Adres;
            db.SaveChanges();
        }

        public void EditEgzemplarz(Egzemplarz egzem)
        {
            var zmiana = db.Egzemplarz.Where(a => a.IdEgzemplarza == egzem.IdEgzemplarza).FirstOrDefault();
            zmiana.IdKsiazki = egzem.IdKsiazki;
            zmiana.RokWydania = egzem.RokWydania;
            zmiana.IdCzytelnika = egzem.IdCzytelnika;
            zmiana.DataWypozyczenia = egzem.DataWypozyczenia;
            zmiana.DataOddania = egzem.DataOddania;
            zmiana.IdPracownika = egzem.IdPracownika;
            db.SaveChanges();
        }

        public void EditFilia(FilieBiblioteki filie)
        {
            var zmiana = db.FilieBiblioteki.Where(a => a.IdFili == filie.IdFili).FirstOrDefault();
            zmiana.Nazwa = filie.Nazwa;
            zmiana.Adres = filie.Adres;
            db.SaveChanges();
        }

        public void EditKsiazka(Ksiazka ksiazka)
        {
            var zmiana = db.Ksiazka.Where(a => a.IdKsiazki == ksiazka.IdKsiazki).FirstOrDefault();
            zmiana.Tytul = ksiazka.Tytul;
            zmiana.LiczbaEgzDostepnych = ksiazka.LiczbaEgzDostepnych;
            zmiana.IdGatunku = ksiazka.IdGatunku;
            db.SaveChanges();
        }

        public void EditKsiegarnia(Ksiegarnia ksieg)
        {
            var zmiana = db.Ksiegarnia.Where(a => a.IdKsiegarni == ksieg.IdKsiegarni).FirstOrDefault();
            zmiana.Nazwa = ksieg.Nazwa;
            zmiana.Adres = ksieg.Adres;
            db.SaveChanges();
        }

        public void EditPracownicy(Pracownicy prac)
        {
            var zmiana = db.Pracownicy.Where(a => a.IdPracownika == prac.IdPracownika).FirstOrDefault();
            zmiana.Imie = prac.Imie;
            zmiana.Nazwisko = prac.Nazwisko;
            zmiana.Pesel = prac.Pesel;
            zmiana.IdFilii = prac.IdFilii;
            db.SaveChanges();
        }

        public void EditZamowienia(Zamowienia zamow)
        {
            var zmiana = db.Zamowienia.Where(a => a.IdZamowienia == zamow.IdZamowienia).FirstOrDefault();
            zmiana.IdKsiazki = zamow.IdKsiazki;
            zmiana.IdPracownika = zamow.IdPracownika;
            zmiana.IdKsiegarni = zamow.IdKsiegarni;
            zmiana.RokWydania = zamow.RokWydania;
            db.SaveChanges();
        }

        public void EditGatunki(Gatunek gatunek)
        {
            var zmiana = db.Gatunek.Where(a => a.IdGatunku == gatunek.IdGatunku).FirstOrDefault();
            zmiana.NazwaGatunku = gatunek.NazwaGatunku;
            zmiana.Opis = gatunek.Opis;
            db.SaveChanges();
        }

        public void DelAutor(int id)
        {
            var zmiana = db.Autor.Where(a => a.IdAutora == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelCzytelnik(int id)
        {
            var zmiana = db.Czytelnik.Where(a => a.IdCzytelnika == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelEgzemplarz(int id)
        {
            var zmiana = db.Egzemplarz.Where(a => a.IdEgzemplarza == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelFilia(int id)
        {
            var zmiana = db.FilieBiblioteki.Where(a => a.IdFili == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelKsiazka(int id)
        {
            var zmiana = db.Ksiazka.Where(a => a.IdKsiazki == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelKsiegarnia(int id)
        {
            var zmiana = db.Ksiegarnia.Where(a => a.IdKsiegarni == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelPracownicy(int id)
        {
            var zmiana = db.Pracownicy.Where(a => a.IdPracownika == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelZamowienia(int id)
        {
            var zmiana = db.Zamowienia.Where(a => a.IdZamowienia == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public void DelGatunki(int id)
        {
            var zmiana = db.Gatunek.Where(a => a.IdGatunku == id).FirstOrDefault();
            zmiana.IsActive = false;
            db.SaveChanges();
        }

        public decimal? LiczbaDniWypozyczonejKsiazki(int idKsiazki, DateTime DataOd, DateTime DataDo)
        {
            return
            (
                from egz in db.Egzemplarz
                where egz.IsActive == true && egz.IdKsiazki == idKsiazki && (
                (egz.DataWypozyczenia <= DataOd && egz.DataWypozyczenia <= DataDo && egz.DataOddania >= DataDo && egz.DataOddania >= DataOd) ||
                (egz.DataWypozyczenia <= DataOd && egz.DataWypozyczenia >= DataDo && egz.DataOddania >= DataDo && egz.DataOddania <= DataOd) ||
                (egz.DataWypozyczenia <= DataOd && egz.DataOddania >= DataOd && egz.DataOddania <= DataDo) ||
                (egz.DataWypozyczenia >= DataOd && egz.DataWypozyczenia <= DataDo && egz.DataOddania <= DataDo))
                select DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) > 0 ? DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) + 1 :
                    egz.DataWypozyczenia == egz.DataOddania ? 1 : 0
                ).Sum();
        }

        public decimal? LiczbaDniWypozyczeniaKsiazekPrzezPracownika(int IdPracownika, DateTime DataOd, DateTime DataDo)
        {
            return
            (
                from egz in db.Egzemplarz
                where egz.IsActive == true && egz.IdPracownika == IdPracownika && (
                (egz.DataWypozyczenia <= DataOd && egz.DataWypozyczenia <= DataDo && egz.DataOddania >= DataDo && egz.DataOddania >= DataOd) ||
                (egz.DataWypozyczenia <= DataOd && egz.DataWypozyczenia >= DataDo && egz.DataOddania >= DataDo && egz.DataOddania <= DataOd) ||
                (egz.DataWypozyczenia <= DataOd && egz.DataOddania >= DataOd && egz.DataOddania <= DataDo) ||
                (egz.DataWypozyczenia >= DataOd && egz.DataWypozyczenia <= DataDo && egz.DataOddania <= DataDo))
                select DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) > 0 ? DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) + 1 :
                    egz.DataWypozyczenia == egz.DataOddania ? 1 : 0
            ).Sum();
        }

        public decimal? IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowa(int RokOd, int RokDo)
        {
            var idCzytelnikow =
            (
                from czyt in db.Czytelnik
                where czyt.IsActive == true
                select new
                {
                    id= czyt.IdCzytelnika,
                    wiek= czyt.Pesel.ToString().Substring(0, 2)
                }
            ).ToList();
            var www = idCzytelnikow.Where(x => 1900+ int.Parse(x.wiek) >= RokOd && 1900+int.Parse(x.wiek) <= RokDo).Select(x=>x.id).ToArray();
            return
            (from egz in db.Egzemplarz
             where egz.IsActive == true && www.Contains(egz.IdCzytelnika) //select egz.IdEgzemplarza
             select DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) > 0 ? DbFunctions.DiffDays(egz.DataWypozyczenia, egz.DataOddania) + 1 :
                 egz.DataWypozyczenia == egz.DataOddania ? 1 : 0
            ).Sum();
        }
    }

}
