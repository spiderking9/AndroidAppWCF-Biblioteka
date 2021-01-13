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
            items = bibliotekaServices.GetZamowienia(null).GetZamowieniaResult.Select(k => new Zamowieniaa
            {
                IdZamowienia=k.IdZamowienia,
                IdKsiazki = k.IdKsiazki,
                IdPracownika = k.IdPracownika,
                IdKsiegarni = k.IdKsiegarni,
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
        }

        public override Zamowieniaa Find(Zamowieniaa item)
        {
            return items.Where((Zamowieniaa arg) => arg.IdZamowienia == item.IdZamowienia).FirstOrDefault();
        }
        public override Zamowieniaa Find(int id)
        {
            return items.Where((Zamowieniaa arg) => arg.IdZamowienia == id).FirstOrDefault();
        }

    }
}