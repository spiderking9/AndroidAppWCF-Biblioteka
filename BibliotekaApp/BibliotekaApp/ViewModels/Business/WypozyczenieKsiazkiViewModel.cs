using BibliotekaApp.Models;
using BibliotekaApp.Services;
using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Business
{
    public class WypozyczenieKsiazkiViewModel : BaseViewModel
    {
        private Ksiazki _SelectedKsiazka;
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
        //private int _IdKsiazki;
        //public int IdKsiazki
        //{
        //    get => _IdKsiazki;
        //    set => SetProperty(ref _IdKsiazki, value);
        //}
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
        private decimal? _WypozyczenieKsiazki;
        public decimal? WypozyczenieKsiazki
        {
            get => _WypozyczenieKsiazki;
            set => SetProperty(ref _WypozyczenieKsiazki, value);
        }
        public Command WypozyczenieKsiazkiCommand { get; }
        public WypozyczenieKsiazkiViewModel()
        {
            //IdKsiazki = 1;
            DataOd = new DateTime(1999, 01, 01);
            DataDo = new DateTime(2021, 02, 20);
            WypozyczenieKsiazkiCommand = new Command(OnWypozyczenieKsiazki);
            WypozyczenieKsiazki = 0;
        }

        private void OnWypozyczenieKsiazki()
        {
            WypozyczenieKsiazki = new WypozyczenieKsiazkiDataStore().LiczbaDniWypozyczonejKsiazki(SelectedKsiazka.IdKsiazki, DataOd, DataDo)??0;
        }
    }
}
