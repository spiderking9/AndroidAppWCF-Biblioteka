using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class GatunekDataStore : ItemDataStore<Gatunki>
    {

        public GatunekDataStore()
        {
            items = bibliotekaServices.GetGatunek(null).GetGatunekResult.Select(k => new Gatunki
            {
                IdGatunku=k.IdGatunku,
                NazwaGatunku = k.NazwaGatunku,
                Opis = k.Opis?? "brak opisu",
            }).ToList();
        }

        public override void AddItem(Gatunki item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddGatunki(new AddGatunkiRequest(
                new Gatunek
                {
                    NazwaGatunku = item.NazwaGatunku,
                    Opis = item.Opis,
                    IsActive = true
                }));
        }

        public override Gatunki Find(Gatunki item)
        {
            return items.Where((Gatunki arg) => arg.IdGatunku == item.IdGatunku).FirstOrDefault();
        }
        public override Gatunki Find(int id)
        {
            return items.Where((Gatunki arg) => arg.IdGatunku == id).FirstOrDefault();
        }

    }
}