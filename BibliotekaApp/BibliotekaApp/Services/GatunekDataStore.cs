﻿using System;
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
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetGatunek(null).GetGatunekResult.Select(k => new Gatunki
            {
                IdGatunku = k.IdGatunku,
                NazwaGatunku = k.NazwaGatunku,
                Opis = k.Opis ?? "brak opisu",
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
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelGatunki(new DelGatunkiRequest(id));
            items.Remove(items.Where(s => s.IdGatunku == id).FirstOrDefault());
            Load();
        }

        public override Gatunki Find(Gatunki item)
        {
            return items.Where((Gatunki arg) => arg.IdGatunku == item.IdGatunku).FirstOrDefault();
        }
        public override Gatunki Find(int id)
        {
            return items.Where((Gatunki arg) => arg.IdGatunku == id).FirstOrDefault();
        }

        public override void UpdateItem(Gatunki item)
        {
            var zmienna = items.Where(x => x.IdGatunku == item.IdGatunku).FirstOrDefault();
            zmienna.NazwaGatunku = item.NazwaGatunku;
            zmienna.Opis = item.Opis;
            bibliotekaServices.EditGatunki(new EditGatunkiRequest(new Gatunek
            {
                IdGatunku = item.IdGatunku,
                NazwaGatunku = item.NazwaGatunku,
                Opis = item.Opis,
                IsActive = true
            }));
        }
    }
}