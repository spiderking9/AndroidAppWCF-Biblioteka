using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaApp.Services
{
    public class CzytelnikDataStore : ItemDataStore<Czytelnicy>
    {
        public CzytelnikDataStore()
        {
            Load();
        }

        public override void AddItem(Czytelnicy item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddCzytelnik(new AddCzytelnikRequest(
                new Czytelnik
                {
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Pesel = item.Pesel,
                    Adres=item.Adres,
                    IsActive = true
                }));
            Load();
        }
        public void Load()
        {
            items = bibliotekaServices.GetCzytelnik(null).GetCzytelnikResult.Select(k => new Czytelnicy
            {
                IdCzytelnika = k.IdCzytelnika,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Adres = k.Adres,
                Pesel = k.Pesel
            }).ToList();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelCzytelnik(new DelCzytelnikRequest(id));
            items.Remove(items.Where(s => s.IdCzytelnika == id).FirstOrDefault());
        }

        public override Czytelnicy Find(Czytelnicy item)
        {
            return items.Where((Czytelnicy arg) => arg.IdCzytelnika == item.IdCzytelnika).FirstOrDefault();
        }
        public override Czytelnicy Find(int id)
        {
            return items.Where((Czytelnicy arg) => arg.IdCzytelnika == id).FirstOrDefault();
        }

        public override void UpdateItem(Czytelnicy item)
        {
            var zmienna = items.Where(x => x.IdCzytelnika == item.IdCzytelnika).FirstOrDefault();
            zmienna.Imie = item.Imie;
            zmienna.Nazwisko = item.Nazwisko;
            zmienna.Adres = item.Adres;
            zmienna.Pesel = item.Pesel;
            bibliotekaServices.EditCzytelnik(new EditCzytelnikRequest(new Czytelnik
            {
                IdCzytelnika = item.IdCzytelnika,
                Imie = item.Imie,
                Nazwisko = item.Nazwisko,
                Adres = item.Adres,
                Pesel=item.Pesel,
                IsActive = true
            }));
        }
    }
}