using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class ZamownieniaDataStore : ItemDataStore<Zamowieniaa>
    {

        public ZamownieniaDataStore()
        {
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetZamowienia(null).GetZamowieniaResult.Select(k => new Zamowieniaa
            {
                IdZamowienia = k.IdZamowienia,
                KsiazkaTytul = k.KsiazkaTytul,
                IdKsiazki=k.IdKsiazki,
                IdKsiegarni=k.IdKsiegarni,
                IdPracownika=k.IdPracownika,
                PracownikNazwisko = k.PracownikNazwisko,
                KsiegarniaNazwa = k.KsiegarniaNazwa,
                RokWydania = k.RokWydania
            }).ToList();
        }

        public override void AddItem(Zamowieniaa item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddZamowienia(new AddZamowieniaRequest(
                new Zamowienia
                {
                    IdKsiazki = item.IdKsiazki,
                    IdPracownika = item.IdPracownika,
                    IdKsiegarni = item.IdKsiegarni,
                    RokWydania = item.RokWydania,
                    IsActive = true
                }));
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelZamowienia(new DelZamowieniaRequest(id));
            items.Remove(items.Where(s => s.IdZamowienia == id).FirstOrDefault());
            Load();
        }

        public override Zamowieniaa Find(Zamowieniaa item)
        {
            return items.Where((Zamowieniaa arg) => arg.IdZamowienia == item.IdZamowienia).FirstOrDefault();
        }
        public override Zamowieniaa Find(int id)
        {
            return items.Where((Zamowieniaa arg) => arg.IdZamowienia == id).FirstOrDefault();
        }

        public override void UpdateItem(Zamowieniaa item)
        {
            var zmienna = items.Where(x => x.IdZamowienia == item.IdZamowienia).FirstOrDefault();
            zmienna.IdKsiazki = item.IdKsiazki;
            zmienna.IdPracownika = item.IdPracownika;
            zmienna.IdKsiegarni = item.IdKsiegarni;
            zmienna.RokWydania = item.RokWydania;
            bibliotekaServices.EditZamowienia(new EditZamowieniaRequest(new Zamowienia
            {
                IdZamowienia=item.IdZamowienia,
                IdKsiazki = item.IdKsiazki,
                IdPracownika = item.IdPracownika,
                IdKsiegarni = item.IdKsiegarni,
                RokWydania = item.RokWydania,
                IsActive = true
            }));
        }
    }
}