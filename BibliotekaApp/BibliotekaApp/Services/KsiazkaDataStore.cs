﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;

namespace BibliotekaApp.Services
{
    public class KsiazkaDataStore : ItemDataStore<Ksiazki>
    {

        public KsiazkaDataStore()
        {
            items = bibliotekaServices.GetKsiazka(null).GetKsiazkaResult.Select(k => new Ksiazki
            {
                Tytul = k.Tytul,
                LiczbaEgzDostepnych = k.LiczbaEgzDostepnych<1?"brak dostepnych egzeplarzy": k.LiczbaEgzDostepnych?.ToString(),
                IdGatunku = k.IdGatunku
            }).ToList();
        }

        public override void AddItem(Ksiazki item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddKsiazka(new AddKsiazkaRequest(
                new Ksiazka
                {
                    Tytul = item.Tytul,
                    LiczbaEgzDostepnych = Int32.Parse(item.LiczbaEgzDostepnych),
                    IdGatunku = item.IdGatunku,
                    IsActive = true
                }));
        }

        public override Ksiazki Find(Ksiazki item)
        {
            return items.Where((Ksiazki arg) => arg.IdKsiazki == item.IdKsiazki).FirstOrDefault();
        }
        public override Ksiazki Find(int id)
        {
            return items.Where((Ksiazki arg) => arg.IdKsiazki == id).FirstOrDefault();
        }

    }
}