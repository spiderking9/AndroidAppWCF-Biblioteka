using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class FilieDataStore : ItemDataStore<Filie>
    {

        public FilieDataStore()
        {
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetFilie(null).GetFilieResult.Select(k => new Filie
            {
                IdFili = k.IdFili,
                Nazwa = k.Nazwa,
                Adres = k.Adres
            }).ToList();
        }

        public override void AddItem(Filie item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddFilia(new AddFiliaRequest(
                new FilieBiblioteki
                {
                    Nazwa = item.Nazwa,
                    Adres = item.Adres,
                    IsActive = true
                }));
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelFilia(new DelFiliaRequest(id));
            items.Remove(items.Where(s => s.IdFili == id).FirstOrDefault());
            Load();
        }

        public override Filie Find(Filie item)
        {
            return items.Where((Filie arg) => arg.IdFili == item.IdFili).FirstOrDefault();
        }
        public override Filie Find(int id)
        {
            return items.Where((Filie arg) => arg.IdFili == id).FirstOrDefault();
        }

        public override void UpdateItem(Filie item)
        {
            var zmienna = items.Where(x => x.IdFili == item.IdFili).FirstOrDefault();
            zmienna.Nazwa = item.Nazwa;
            zmienna.Adres = item.Adres;
            bibliotekaServices.EditFilia(new EditFiliaRequest(new FilieBiblioteki
            {
                IdFili = item.IdFili,
                Nazwa = item.Nazwa,
                Adres = item.Adres,
                IsActive = true
            }));
        }
    }
}