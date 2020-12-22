using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class AutorDataStore : ItemDataStore<Autorzy>
    {

        public AutorDataStore()
        {
            //items = new List<Autorzy>()
            //{
            //    new Autorzy {  Imie = "First item", Nazwisko="This is an item description.",Opis="sdgdfgd" },
            //    new Autorzy { Imie = "Second item", Nazwisko="This is an item description.",Opis="sdgdfgd" }
            //};
            items = bibliotekaServices.GetAutor(null).GetAutorResult.Select(k => new Autorzy
            {
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Opis = k.Opis
            }).ToList();
        }

        public override void AddItem(Autorzy item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddAutor(new AddAutorRequest(
                new Autor
                {
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Opis = item.Opis,
                    IsActive = true
                }));
        }

        public override Autorzy Find(Autorzy item)
        {
            return items.Where((Autorzy arg) => arg.IdAutora == item.IdAutora).FirstOrDefault();
        }
        public override Autorzy Find(int id)
        {
            return items.Where((Autorzy arg) => arg.IdAutora == id).FirstOrDefault();
        }

    }
}