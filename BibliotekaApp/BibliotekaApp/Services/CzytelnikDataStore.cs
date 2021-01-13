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
            //items = new List<Czytelnicy>()
            //{
            //    new Czytelnicy {  Imie = "First item", Nazwisko="This is an item description.",Adres="fdsfsd" },
            //    new Czytelnicy {  Imie = "First item", Nazwisko="This is an item description.",Adres="fdsfsd" },
            //};

            items = bibliotekaServices.GetCzytelnik(null).GetCzytelnikResult.Select(k => new Czytelnicy
            {
                IdCzytelnika=k.IdCzytelnika,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Adres = k.Adres,
                Pesel = k.Pesel
            }).ToList();
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
        }

        public override Czytelnicy Find(Czytelnicy item)
        {
            return items.Where((Czytelnicy arg) => arg.IdCzytelnika == item.IdCzytelnika).FirstOrDefault();
        }
        public override Czytelnicy Find(int id)
        {
            return items.Where((Czytelnicy arg) => arg.IdCzytelnika == id).FirstOrDefault();
        }

    }
}