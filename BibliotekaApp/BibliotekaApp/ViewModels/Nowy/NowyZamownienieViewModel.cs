using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Services;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyZamownienieViewModel : ANewItemViewModel<Zamowieniaa>
    {
        private Ksiazki _SelectedKsiazka;
        private Pracownicyy _SelectedPracownik;
        private Ksiegarnie _SelectedKsiegarnia;
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
        public List<Ksiazki> Ksiazki
        {
            get
            {
                return new KsiazkaDataStore().items;
            }
        }
        public Ksiazki SelectedKsiazka
        {
            get => _SelectedKsiazka;
            set => SetProperty(ref _SelectedKsiazka, value);
        }
        public List<Pracownicyy> Pracownicy
        {
            get
            {
                return new PracownikDataStore().items;
            }
        }
        public Pracownicyy SelectedPracownik
        {
            get => _SelectedPracownik;
            set => SetProperty(ref _SelectedPracownik, value);
        }
        public List<Ksiegarnie> Ksiegarnie
        {
            get
            {
                return new KsiegarniaDataStore().items;
            }
        }
        public Ksiegarnie SelectedKsiegarnia
        {
            get => _SelectedKsiegarnia;
            set => SetProperty(ref _SelectedKsiegarnia, value);
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
                IdKsiazki = SelectedKsiazka.IdKsiazki,
                IdPracownika = SelectedPracownik.IdPracownika,
                IdKsiegarni = SelectedKsiegarnia.IdKsiegarni,
                RokWydania = RokWydania
            };
            return newItem;
        }
    }
}
