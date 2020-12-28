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
            //items = new List<Egzemplarze>()
            //{
            //    new Egzemplarze {  
            //        IdKsiazki = 23, 
            //        RokWydania=23,
            //        IdCzytelnika=1,
            //        DataWypozyczenia=DateTime.Now,
            //        DataOddania=DateTime.Now,
            //        IdPracownika=23
            //    }
            //};
            items = bibliotekaServices.GetEgzemplarz(null).GetEgzemplarzResult.Select(k => new Egzemplarze
            {
                CzytelnikNazwisko =k.CzytelnikNazwisko,
                RokWydania = k.RokWydania,
                KsiazkaTytul = k.KsiazkaTytul,
                DataWypozyczenia = k.DataWypozyczenia,
                DataOddania = k.DataOddania,
                PracownikNazwisko = k.PracownikNazwisko
            }).ToList();
        }

        public override void AddItem(Egzemplarze item)
        {
            throw new NotImplementedException();
            //bibliotekaServices.AddEgzemplarz(new AddEgzemplarzRequest(
            //    new Egzemplarz
            //    {
            //        IdKsiazki = item.IdKsiazki,
            //        RokWydania = item.RokWydania,
            //        IdCzytelnika = item.IdCzytelnika,
            //        DataWypozyczenia = item.DataWypozyczenia,
            //        DataOddania = item.DataOddania,
            //        IdPracownika = item.IdPracownika,
            //        IsActive = true
            //    }));
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