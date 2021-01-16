using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Services;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyPracownikViewModel : ANewItemViewModel<Pracownicyy>
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Pesel;
        private Filie _SelectedFilie;

        public NowyPracownikViewModel()
            : base()
        {
            _SelectedFilie = new Filie();
        }
        public List<Filie> Filie
        {
            get
            {
                return new FilieDataStore().items;
            }
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
        public Filie SelectedFilie
        {
            get => _SelectedFilie;
            set => SetProperty(ref _SelectedFilie, value);
        }
        public override Pracownicyy SetItem()
        {
            Pracownicyy newItem = new Pracownicyy()
            {
                Imie = Imie,
                Nazwisko = Nazwisko,
                Pesel = Pesel,
                IdFilii= SelectedFilie.IdFili
            };
            return newItem;
        }
    }
}
