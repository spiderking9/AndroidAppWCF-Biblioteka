using BibliotekaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyCzytelnikViewModel : ANewItemViewModel<Czytelnicy>
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Adres;
        private long _Pesel;

        public NowyCzytelnikViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_Imie);
        }
        public string Imie
        {
            get => _Imie;
            set => SetProperty(ref _Imie, value);
        }
        public string Nazwisko
        {
            get => _Nazwisko;
            set => SetProperty(ref _Nazwisko, value);
        }
        public string Adres
        {
            get => _Adres;
            set => SetProperty(ref _Adres, value);
        }
        public long Pesel
        {
            get => _Pesel;
            set => SetProperty(ref _Pesel, value);
        }
        public override Czytelnicy SetItem()
        {
            Czytelnicy newItem = new Czytelnicy()
            {
                Imie = Imie,
                Nazwisko = Nazwisko,
                Adres = Adres,
                Pesel=Pesel
            };
            return newItem;
        }
    }
}
