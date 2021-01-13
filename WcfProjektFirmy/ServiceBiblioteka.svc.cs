using System;
using System.Collections.Generic;
using System.Linq;
using WcfProjektFirmy.Model.Entieties;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfProjektFirmy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceBiblioteka : IServiceBiblioteka
    {
        public List<AutorForView> GetAutor()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return
            (
                from autor in db.Autor
                where autor.IsActive == true
                select new AutorForView
                {
                    IdAutora=autor.IdAutora,
                    Imie=autor.Imie,
                    Nazwisko=autor.Nazwisko,
                    Opis=autor.Opis
                }
            ).ToList();
        }

        public List<CzytelnikForView> GetCzytelnik()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return
            (
                from czyte in db.Czytelnik
                where czyte.IsActive == true
                select new CzytelnikForView
                {
                    IdCzytelnika=czyte.IdCzytelnika,
                    Imie=czyte.Imie,
                    Nazwisko=czyte.Nazwisko,
                    Adres=czyte.Adres,
                    Pesel = czyte.Pesel
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
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return
            (
                from egz in db.Egzemplarz
                where egz.IsActive == true
                select new EgzemplarzForView
                {
                    IdEgzemplarza = egz.IdEgzemplarza,
                    IdKsiazki=egz.IdKsiazki,
                    KsiazkaTytul=egz.Ksiazka.Tytul,
                    RokWydania=egz.RokWydania,
                    IdCzytelnika=egz.IdCzytelnika,
                    CzytelnikNazwisko=egz.Czytelnik.Imie.Trim()+" "+ egz.Czytelnik.Nazwisko,
                    DataWypozyczenia=egz.DataWypozyczenia,
                    DataOddania=egz.DataOddania,
                    IdPracownika=egz.IdPracownika,
                    PracownikNazwisko=egz.Pracownicy.Imie.Trim() + " "+egz.Pracownicy.Nazwisko
                }
            ).ToList();
        }

        public List<FilieForView> GetFilie()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
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
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return (
                from gat in db.Gatunek
                where gat.IsActive==true
                select new GatunekForView
                {
                    IdGatunku=gat.IdGatunku,
                    NazwaGatunku=gat.NazwaGatunku,
                    Opis=gat.Opis
                }
                ).ToList();
        }

        public List<KsiazkaForView> GetKsiazka()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return (    
                from ksiaz in db.Ksiazka
                where ksiaz.IsActive==true
                select new KsiazkaForView
                {
                    IdKsiazki=ksiaz.IdKsiazki,
                    IdGatunku=ksiaz.IdGatunku,
                    GatunekNazwa=ksiaz.Gatunek.NazwaGatunku,
                    LiczbaEgzDostepnych=ksiaz.LiczbaEgzDostepnych,
                    Tytul=ksiaz.Tytul
                }
                ).ToList();
    }

        public List<KsiegarniaForView> GetKsiegarnia()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return (
                from ksieg in db.Ksiegarnia
                where ksieg.IsActive==true
                select new KsiegarniaForView
                {
                    IdKsiegarni=ksieg.IdKsiegarni,
                    Nazwa=ksieg.Nazwa,
                    Adres=ksieg.Adres
                }
                ).ToList();
        }

        public List<PracownicyForView> GetPracownicy()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return (
                from prac in db.Pracownicy
                where prac.IsActive==true
                select new PracownicyForView
                {
                    IdPracownika=prac.IdPracownika,
                    IdFilii=prac.IdFilii,
                    FiliaNazwa=prac.FilieBiblioteki.Nazwa,
                    Imie=prac.Imie,
                    Nazwisko=prac.Nazwisko,
                    Pesel=prac.Pesel
                }
                ).ToList();
        }

        public List<ZamowieniaForView> GetZamowienia()
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            return (
                from zamow in db.Zamowienia
                where zamow.IsActive==true
                select new ZamowieniaForView
                {
                    IdZamowienia=zamow.IdZamowienia,
                    IdKsiazki=zamow.IdKsiazki,
                    KsiazkaTytul=zamow.Ksiazka.Tytul,
                    IdKsiegarni=zamow.IdKsiegarni,
                    KsiegarniaNazwa=zamow.Ksiegarnia.Nazwa,
                    IdPracownika=zamow.IdPracownika,
                    PracownikNazwisko=zamow.Pracownicy.Imie + " " + zamow.Pracownicy.Nazwisko,
                    RokWydania=zamow.RokWydania
                }
                ).ToList();
        }
        public void AddAutor(Autor autor)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Autor.Add(autor);
            db.SaveChanges();
        }
        public void AddCzytelnik(Czytelnik czytelnik)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Czytelnik.Add(czytelnik);
            db.SaveChanges();
        }

        public void AddEgzemplarz(Egzemplarz egzem)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Egzemplarz.Add(egzem);
            db.SaveChanges();
        }

        public void AddFilia(FilieBiblioteki filie)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.FilieBiblioteki.Add(filie);
            db.SaveChanges();
        }

        public void AddKsiazka(Ksiazka ksiazka)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Ksiazka.Add(ksiazka);
            db.SaveChanges();
        }

        public void AddKsiegarnia(Ksiegarnia ksieg)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Ksiegarnia.Add(ksieg);
            db.SaveChanges();
        }

        public void AddPracownicy(Pracownicy prac)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Pracownicy.Add(prac);
            db.SaveChanges();
        }

        public void AddZamowienia(Zamowienia zamow)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Zamowienia.Add(zamow);
            db.SaveChanges();
        }

        public void AddGatunki(Gatunek gatunek)
        {
            BibliotekaPlutaLukaszEntities db = new BibliotekaPlutaLukaszEntities();
            db.Gatunek.Add(gatunek);
            db.SaveChanges();
        }
    }

}
