using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyPracownikViewModel : ANewItemViewModel<Pracownicyy>
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Pesel;
        private int _IdFilii;

        public NowyPracownikViewModel()
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
        public string Pesel
        {
            get => _Pesel;
            set => SetProperty(ref _Pesel, value);
        }
        public int IdFilii
        {
            get => _IdFilii;
            set => SetProperty(ref _IdFilii, value);
        }
        public override Pracownicyy SetItem()
        {
            Pracownicyy newItem = new Pracownicyy()
            {
                Imie = Imie,
                Nazwisko = Nazwisko,
                Pesel = Pesel,
                IdFilii= IdFilii
            };
            return newItem;
        }
    }
}
