using BibliotekaApp.Models;
using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaApp.Services
{
    public class EgzemplarzDataStore : ItemDataStore<Egzemplarze>
    {
        public EgzemplarzDataStore()
        {
            items = bibliotekaServices.GetEgzemplarz(null).GetEgzemplarzResult.Select(k => new Egzemplarze
            {
                CzytelnikNazwisko =k.CzytelnikNazwisko,
                RokWydania = k.RokWydania,
                KsiazkaTytul = k.KsiazkaTytul,
                DataWypozyczenia = k.DataWypozyczenia?.ToString("dd/MM/yyyy")?? "brak danych",
                DataOddania = k.DataOddania?.ToString("dd/MM/yyyy") ?? "brak danych",
                PracownikNazwisko = k.PracownikNazwisko
            }).ToList();
        }

        public override void AddItem(Egzemplarze item)
        {
            //throw new NotImplementedException();
            bibliotekaServices.AddEgzemplarz(new AddEgzemplarzRequest(
                new Egzemplarz
                {
                    IdKsiazki = item.IdKsiazki,
                    RokWydania = item.RokWydania,
                    IdCzytelnika = item.IdCzytelnika,
                    DataWypozyczenia = item.Data_Wypozyczenia,
                    DataOddania = item.Data_Oddania,
                    IdPracownika = item.IdPracownika,
                    IsActive = true
                }));
        }

        public override Egzemplarze Find(Egzemplarze item)
        {
            return items.Where((Egzemplarze arg) => arg.IdEgzemplarza == item.IdEgzemplarza).FirstOrDefault();
        }
        public override Egzemplarze Find(int id)
        {
            return items.Where((Egzemplarze arg) => arg.IdEgzemplarza == id).FirstOrDefault();
        }

    }
}