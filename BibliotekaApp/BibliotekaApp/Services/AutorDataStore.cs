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
            Load();
        }

        public override void AddItem(Autorzy item)
        {
            bibliotekaServices.AddAutor(new AddAutorRequest(
                new Autor
                {
                    IdAutora=item.IdAutora,
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Opis = item.Opis,
                    IsActive = true
                }));
            Load();
        }

        void Load()
        {
            items = bibliotekaServices.GetAutor(null).GetAutorResult.Select(k => new Autorzy
            {
                IdAutora = k.IdAutora,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Opis = k.Opis,
                Ksiazki = k.Ksiazki
            }).ToList();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelAutor(new DelAutorRequest(id));
            items.Remove(items.Where(s=>s.IdAutora==id).FirstOrDefault());
        }

        public override Autorzy Find(Autorzy item)
        {
            return items.Where((Autorzy arg) => arg.IdAutora == item.IdAutora).FirstOrDefault();
        }
        public override Autorzy Find(int id)
        {
            return items.Where((Autorzy arg) => arg.IdAutora == id).FirstOrDefault();
        }

        public override void UpdateItem(Autorzy item)
        {
            var zmienna = items.Where(x => x.IdAutora == item.IdAutora).FirstOrDefault();
            zmienna.Imie = item.Imie;
            zmienna.Nazwisko = item.Nazwisko;
            zmienna.Opis = item.Opis;
            bibliotekaServices.EditAutor(new EditAutorRequest(new Autor
            {
                IdAutora=item.IdAutora,
                Imie = item.Imie,
                Nazwisko = item.Nazwisko,
                Opis = item.Opis,
                IsActive = true
            }));
        }
    }
}