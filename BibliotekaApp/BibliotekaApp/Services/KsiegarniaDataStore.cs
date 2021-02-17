using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class KsiegarniaDataStore : ItemDataStore<Ksiegarnie>
    {

        public KsiegarniaDataStore()
        {
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetKsiegarnia(null).GetKsiegarniaResult.Select(k => new Ksiegarnie
            {
                IdKsiegarni = k.IdKsiegarni,
                Nazwa = k.Nazwa,
                Adres = k.Adres
            }).ToList();
        }

        public override void AddItem(Ksiegarnie item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddKsiegarnia(new AddKsiegarniaRequest(
                new Ksiegarnia
                {
                    Nazwa = item.Nazwa,
                    Adres = item.Adres,
                    IsActive = true
                }));
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelKsiegarnia(new DelKsiegarniaRequest(id));
            items.Remove(items.Where(s => s.IdKsiegarni == id).FirstOrDefault());
            Load();
        }

        public override Ksiegarnie Find(Ksiegarnie item)
        {
            return items.Where((Ksiegarnie arg) => arg.IdKsiegarni == item.IdKsiegarni).FirstOrDefault();
        }
        public override Ksiegarnie Find(int id)
        {
            return items.Where((Ksiegarnie arg) => arg.IdKsiegarni == id).FirstOrDefault();
        }

        public override void UpdateItem(Ksiegarnie item)
        {
            var zmienna = items.Where(x => x.IdKsiegarni == item.IdKsiegarni).FirstOrDefault();
            zmienna.Nazwa = item.Nazwa;
            zmienna.Adres = item.Adres;


            bibliotekaServices.EditKsiegarnia(new EditKsiegarniaRequest(new Ksiegarnia
            {
                IdKsiegarni = item.IdKsiegarni,
                Nazwa = item.Nazwa,
                Adres = item.Adres,
                IsActive = true
            }));
        }
    }
}