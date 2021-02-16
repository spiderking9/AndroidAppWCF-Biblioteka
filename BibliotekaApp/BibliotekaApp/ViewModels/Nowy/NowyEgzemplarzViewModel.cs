using BibliotekaApp.Models;
using BibliotekaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyEgzemplarzViewModel : ANewItemViewModel<Egzemplarze>
    {
        private Ksiazki _SelectedKsiazka;
        private Czytelnicy _SelectedCzytelnik;
        private Pracownicyy _SelectedPracownik;
        private int _RokWydania;
        private DateTime _DataWypozyczenia;
        private DateTime _DataOddania;

        public List<Ksiazki> Ksiazki
        {
            get
            {
                return new KsiazkaDataStore().items;
            }
        }
        public List<Czytelnicy> Czytelnik
        {
            get
            {
                return new CzytelnikDataStore().items;
            }
        }
        public List<Pracownicyy> Pracownik
        {
            get
            {
                return new PracownikDataStore().items;
            }
        }
        public NowyEgzemplarzViewModel()
            : base()
        {
            _SelectedCzytelnik = new Czytelnicy();
            _SelectedKsiazka = new Ksiazki();
            _SelectedPracownik = new Pracownicyy();
            DataOddania = DateTime.Now;
            DataWypozyczenia = DateTime.Now;
        }
        public override bool ValidateSave()
        {
            return true; 
                //!String.IsNullOrWhiteSpace(_SelectedKsiazka.Tytul);
        }
        public Ksiazki SelectedKsiazka
        {
            get => _SelectedKsiazka;
            set => SetProperty(ref _SelectedKsiazka, value);
        }
        public int RokWydania
        {
            get => _RokWydania;
            set => SetProperty(ref _RokWydania, value);
        }
        public Czytelnicy SelectedCzytelnik
        {
            get => _SelectedCzytelnik;
            set => SetProperty(ref _SelectedCzytelnik, value);
        }
        public DateTime DataWypozyczenia
        {
            get => _DataWypozyczenia;
            set => SetProperty(ref _DataWypozyczenia, value);
        }
        public DateTime DataOddania
        {
            get => _DataOddania;
            set => SetProperty(ref _DataOddania, value);
        }
        public Pracownicyy SelectedPracownik
        {
            get => _SelectedPracownik;
            set => SetProperty(ref _SelectedPracownik, value);
        }
        public override Egzemplarze SetItem()
        {
            Egzemplarze newItem = new Egzemplarze()
            {
                IdKsiazki = SelectedKsiazka.IdKsiazki,
                KsiazkaTytul=SelectedKsiazka.Tytul,
                RokWydania = RokWydania,
                IdCzytelnika = SelectedCzytelnik.IdCzytelnika,
                CzytelnikNazwisko=SelectedCzytelnik.Nazwisko,
                DataWypozyczenia=DataWypozyczenia.ToString(),
                Data_Wypozyczenia = DataWypozyczenia,
                DataOddania=DataOddania.ToString(),
                Data_Oddania = DataOddania,
                IdPracownika = SelectedPracownik.IdPracownika,
                PracownikNazwisko=SelectedPracownik.Nazwisko
            };
            return newItem;
        }
    }
}
