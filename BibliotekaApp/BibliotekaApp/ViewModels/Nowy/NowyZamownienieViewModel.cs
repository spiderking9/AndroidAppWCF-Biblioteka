using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyZamownienieViewModel : ANewItemViewModel<Zamowieniaa>
    {
        private int _IdKsiazki;
        private int _IdPracownika;
        private int _IdKsiegarni;
        private int _RokWydania;

        public NowyZamownienieViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return true;
            //return !String.IsNullOrWhiteSpace(_Imie);
        }
        public int IdKsiazki
        {
            get => _IdKsiazki;
            set => SetProperty(ref _IdKsiazki, value);
        }
        public int IdPracownika
        {
            get => _IdPracownika;
            set => SetProperty(ref _IdPracownika, value);
        }
        public int IdKsiegarni
        {
            get => _IdKsiegarni;
            set => SetProperty(ref _IdKsiegarni, value);
        }
        public int RokWydania
        {
            get => _RokWydania;
            set => SetProperty(ref _RokWydania, value);
        }
        public override Zamowieniaa SetItem()
        {
            Zamowieniaa newItem = new Zamowieniaa()
            {
                IdKsiazki = IdKsiazki,
                IdPracownika = IdPracownika,
                IdKsiegarni = IdKsiegarni,
                RokWydania = RokWydania
            };
            return newItem;
        }
    }
}
