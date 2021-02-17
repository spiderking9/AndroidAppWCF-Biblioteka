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
            Load();
        }
        public void Load()
        {
            items = bibliotekaServices.GetEgzemplarz(null).GetEgzemplarzResult.Select(k => new Egzemplarze
            {
                IdEgzemplarza=k.IdEgzemplarza,
                CzytelnikNazwisko = k.CzytelnikNazwisko,
                IdCzytelnika=k.IdCzytelnika??1,
                RokWydania = k.RokWydania,
                KsiazkaTytul = k.KsiazkaTytul,
                IdKsiazki=k.IdKsiazki,
                Data_Wypozyczenia=k.DataWypozyczenia,
                DataWypozyczenia = k.DataWypozyczenia?.ToString("dd/MM/yyyy") ?? "brak danych",
                Data_Oddania=k.DataOddania,
                DataOddania = k.DataOddania?.ToString("dd/MM/yyyy") ?? "brak danych",
                PracownikNazwisko = k.PracownikNazwisko,
                IdPracownika=k.IdPracownika??1
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
            Load();
        }

        public override void DelItem(int id)
        {
            bibliotekaServices.DelEgzemplarz(new DelEgzemplarzRequest(id));
            items.Remove(items.Where(s => s.IdEgzemplarza == id).FirstOrDefault());
            Load();
        }

        public override Egzemplarze Find(Egzemplarze item)
        {
            return items.Where((Egzemplarze arg) => arg.IdEgzemplarza == item.IdEgzemplarza).FirstOrDefault();
        }
        public override Egzemplarze Find(int id)
        {
            return items.Where((Egzemplarze arg) => arg.IdEgzemplarza == id).FirstOrDefault();
        }

        public override void UpdateItem(Egzemplarze item)
        {
            var zmienna = items.Where(x => x.IdEgzemplarza == item.IdEgzemplarza).FirstOrDefault();
            zmienna.IdCzytelnika = item.IdCzytelnika;
            zmienna.CzytelnikNazwisko = item.CzytelnikNazwisko;
            zmienna.IdKsiazki = item.IdKsiazki;
            zmienna.KsiazkaTytul = item.KsiazkaTytul;
            zmienna.IdPracownika = item.IdPracownika;
            zmienna.PracownikNazwisko = item.PracownikNazwisko; 
            zmienna.RokWydania = item.RokWydania;
            zmienna.DataOddania = item.DataOddania;
            zmienna.DataWypozyczenia = item.DataWypozyczenia;


            bibliotekaServices.EditEgzemplarz(new EditEgzemplarzRequest(new Egzemplarz
            {
                IdEgzemplarza = item.IdEgzemplarza,
                IdCzytelnika=item.IdCzytelnika,
                IdKsiazki=item.IdKsiazki,
                IdPracownika=item.IdPracownika,
                DataOddania=item.Data_Oddania,
                DataWypozyczenia=item.Data_Wypozyczenia,
                RokWydania=item.RokWydania,
                IsActive = true
            }));
        }
    }
}