using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class PracownikDataStore : ItemDataStore<Pracownicyy>
    {

        public PracownikDataStore()
        {
            items = bibliotekaServices.GetPracownicy(null).GetPracownicyResult.Select(k => new Pracownicyy
            {
                IdPracownika=k.IdPracownika,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Pesel = k.Pesel,
                FiliaNazwa=k.FiliaNazwa
            }).ToList();
        }

        public override void AddItem(Pracownicyy item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddPracownicy(new AddPracownicyRequest(
                new Pracownicy
                {
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Pesel = item.Pesel,
                    IdFilii=item.IdFilii,
                    IsActive = true
                }));
        }

        public override Pracownicyy Find(Pracownicyy item)
        {
            return items.Where((Pracownicyy arg) => arg.IdPracownika == item.IdPracownika).FirstOrDefault();
        }
        public override Pracownicyy Find(int id)
        {
            return items.Where((Pracownicyy arg) => arg.IdPracownika == id).FirstOrDefault();
        }

    }
}