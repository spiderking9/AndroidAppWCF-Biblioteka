using BibliotekaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyEgzemplarzViewModel : ANewItemViewModel<Egzemplarze>
    {
        private int _IdKsiazki;
        private int _RokWydania;
        private int _IdCzytelnika;
        private DateTime _DataWypozyczenia;
        private DateTime _DataOddania;
        private int _IdPracownika;

        public NowyEgzemplarzViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return true;
                //!String.IsNullOrWhiteSpace(_IdKsiazki);
        }
        public int IdKsiazki
        {
            get => _IdKsiazki;
            set => SetProperty(ref _IdKsiazki, value);
        }
        public int RokWydania
        {
            get => _RokWydania;
            set => SetProperty(ref _RokWydania, value);
        }
        public int IdCzytelnika
        {
            get => _IdCzytelnika;
            set => SetProperty(ref _IdCzytelnika, value);
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
        public int IdPracownika
        {
            get => _IdPracownika;
            set => SetProperty(ref _IdPracownika, value);
        }
        public override Egzemplarze SetItem()
        {
            Egzemplarze newItem = new Egzemplarze();
            //{
            //    IdKsiazki = IdKsiazki,
            //    RokWydania = RokWydania,
            //    IdCzytelnika = IdCzytelnika,
            //    DataWypozyczenia = DataWypozyczenia,
            //    DataOddania = DataOddania,
            //    IdPracownika = IdPracownika

            //};
            return newItem;
        }
    }
}
