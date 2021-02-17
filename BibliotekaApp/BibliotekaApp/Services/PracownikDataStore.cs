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
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetPracownicy(null).GetPracownicyResult.Select(k => new Pracownicyy
            {
                IdPracownika = k.IdPracownika,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Pesel = k.Pesel,
                FiliaNazwa = k.FiliaNazwa
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
                    IdFilii=item.IdFili,
                    IsActive = true
                }));
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelPracownicy(new DelPracownicyRequest(id));
            items.Remove(items.Where(s => s.IdPracownika == id).FirstOrDefault());
            Load();
        }

        public override Pracownicyy Find(Pracownicyy item)
        {
            return items.Where((Pracownicyy arg) => arg.IdPracownika == item.IdPracownika).FirstOrDefault();
        }
        public override Pracownicyy Find(int id)
        {
            return items.Where((Pracownicyy arg) => arg.IdPracownika == id).FirstOrDefault();
        }

        public override void UpdateItem(Pracownicyy item)
        {
            var zmienna = items.Where(x => x.IdPracownika == item.IdPracownika).FirstOrDefault();
            zmienna.Imie = item.Imie;
            zmienna.Nazwisko = item.Nazwisko;
            zmienna.IdFili = item.IdFili;
            zmienna.Pesel = item.Pesel;
            bibliotekaServices.EditPracownicy(new EditPracownicyRequest(new Pracownicy
            {
                IdPracownika = item.IdPracownika,
                Imie = item.Imie,
                Nazwisko = item.Nazwisko,
                IdFilii = item.IdFili,
                Pesel = item.Pesel,
                IsActive = true
            }));
        }
    }
}