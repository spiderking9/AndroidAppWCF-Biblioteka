using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyAutorViewModel : ANewItemViewModel<Autorzy>
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Opis;
        public NowyAutorViewModel()
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
        public string Opis
        {
            get => _Opis;
            set => SetProperty(ref _Opis, value);
        }
        public override Autorzy SetItem()
        {
            Autorzy newItem = new Autorzy()
            {
                Imie = Imie,
                Nazwisko = Nazwisko,
                Opis = Opis
            };
            return newItem;
        }
    }
}
