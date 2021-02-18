using BibliotekaApp.Models;
using BibliotekaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Business
{
    public class WypozyczenieKsiazkiPracownikViewModel : BaseViewModel
    {
        private Pracownicyy _SelectedPracownik;
        public List<Pracownicyy> Pracownik
        {
            get
            {
                return new PracownikDataStore().items;
            }
        }
        public Pracownicyy SelectedPracownicy
        {
            get => _SelectedPracownik;
            set => SetProperty(ref _SelectedPracownik, value);
        }

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get => _DataOd;
            set => SetProperty(ref _DataOd, value);
        }
        private DateTime _DataDo;

        public DateTime DataDo
        {
            get => _DataDo;
            set => SetProperty(ref _DataDo, value);
        }
        private decimal? _WypozyczenieKsiazkiPracownik;
        public decimal? WypozyczenieKsiazkiPracownik
        {
            get => _WypozyczenieKsiazkiPracownik;
            set => SetProperty(ref _WypozyczenieKsiazkiPracownik, value);
        }
        public Command WypozyczenieKsiazkiPracownikCommand { get; }
        public WypozyczenieKsiazkiPracownikViewModel()
        {
            //IdKsiazki = 1;
            DataOd = new DateTime(1999, 01, 01);
            DataDo = new DateTime(2021, 02, 20);
            WypozyczenieKsiazkiPracownikCommand = new Command(OnWypozyczenieKsiazkiPracownik);
            WypozyczenieKsiazkiPracownik = 0;
        }

        private void OnWypozyczenieKsiazkiPracownik()
        {
            WypozyczenieKsiazkiPracownik = new WypozyczenieKsiazkiDataStore().LiczbaDniWypozyczeniaKsiazekPrzezPracownika(SelectedPracownicy.IdPracownika, DataOd, DataDo) ?? 0;
        }
    }
}
