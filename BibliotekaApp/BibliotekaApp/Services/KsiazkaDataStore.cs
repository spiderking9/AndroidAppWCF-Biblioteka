using System;
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
            Load();
        }

        private void Load()
        {
            items = bibliotekaServices.GetKsiazka(null).GetKsiazkaResult.Select(k => new Ksiazki
            {
                IdKsiazki = k.IdKsiazki,
                Tytul = k.Tytul,
                LiczbaEgzDostepnych = k.LiczbaEgzDostepnych,
                NazwaGatunku = k.GatunekNazwa,
                Autorzy = k.Autorzy
            }).ToList();
        }

        public override void AddItem(Ksiazki item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddKsiazka(new AddKsiazkaRequest(
                new Ksiazka
                {
                    Tytul = item.Tytul,
                    LiczbaEgzDostepnych = item.LiczbaEgzDostepnych,
                    IdGatunku = item.IdGatunku,
                    IsActive = true
                }));
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelKsiazka(new DelKsiazkaRequest(id));
            items.Remove(items.Where(s => s.IdKsiazki == id).FirstOrDefault());
            Load();
        }

        public override Ksiazki Find(Ksiazki item)
        {
            return items.Where((Ksiazki arg) => arg.IdKsiazki == item.IdKsiazki).FirstOrDefault();
        }
        public override Ksiazki Find(int id)
        {
            return items.Where((Ksiazki arg) => arg.IdKsiazki == id).FirstOrDefault();
        }

        public override void UpdateItem(Ksiazki item)
        {
            var zmienna = items.Where(x => x.IdKsiazki == item.IdKsiazki).FirstOrDefault();
            zmienna.Tytul = item.Tytul;
            zmienna.LiczbaEgzDostepnych = item.LiczbaEgzDostepnych;
            zmienna.IdGatunku = item.IdGatunku;


            bibliotekaServices.EditKsiazka(new EditKsiazkaRequest(new Ksiazka
            {
                IdKsiazki = item.IdKsiazki,
                Tytul = item.Tytul,
                LiczbaEgzDostepnych = item.LiczbaEgzDostepnych,
                IdGatunku = item.IdGatunku,
                IsActive = true
            }));
        }
    }
}