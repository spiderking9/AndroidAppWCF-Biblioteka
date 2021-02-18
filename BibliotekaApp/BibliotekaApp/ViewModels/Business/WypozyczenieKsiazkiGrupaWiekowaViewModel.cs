using BibliotekaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Business
{
    public class WypozyczenieKsiazkiGrupaWiekowaViewModel : BaseViewModel
    {

        private int _DataOd;
        public int DataOd
        {
            get => _DataOd;
            set => SetProperty(ref _DataOd, value);
        }
        private int _DataDo;

        public int DataDo
        {
            get => _DataDo;
            set => SetProperty(ref _DataDo, value);
        }
        private decimal? _WypozyczenieKsiazkiGrupaWiekowaPracownik;
        public decimal? WypozyczenieKsiazkiGrupaWiekowaPracownik
        {
            get => _WypozyczenieKsiazkiGrupaWiekowaPracownik;
            set => SetProperty(ref _WypozyczenieKsiazkiGrupaWiekowaPracownik, value);
        }
        public Command WypozyczenieKsiazkiGrupaWiekowaPracownikCommand { get; }
        public WypozyczenieKsiazkiGrupaWiekowaViewModel()
        {
            //IdKsiazki = 1;
            DataOd = 1950;
            DataDo = 2000;
            WypozyczenieKsiazkiGrupaWiekowaPracownikCommand = new Command(OnWypozyczenieKsiazkiGrupaWiekowaPracownik);
            WypozyczenieKsiazkiGrupaWiekowaPracownik = 0;
        }

        private void OnWypozyczenieKsiazkiGrupaWiekowaPracownik()
        {
            WypozyczenieKsiazkiGrupaWiekowaPracownik = new WypozyczenieKsiazkiDataStore().IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowa(DataOd, DataDo) ?? 0;
        }
    }
}
