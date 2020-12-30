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
            items = bibliotekaServices.GetKsiegarnia(null).GetKsiegarniaResult.Select(k => new Ksiegarnie
            {
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
        }

        public override Ksiegarnie Find(Ksiegarnie item)
        {
            return items.Where((Ksiegarnie arg) => arg.IdKsiegarni == item.IdKsiegarni).FirstOrDefault();
        }
        public override Ksiegarnie Find(int id)
        {
            return items.Where((Ksiegarnie arg) => arg.IdKsiegarni == id).FirstOrDefault();
        }

    }
}