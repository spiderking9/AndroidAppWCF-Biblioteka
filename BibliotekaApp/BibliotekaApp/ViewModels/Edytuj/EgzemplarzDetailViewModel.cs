using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Lista;
using BibliotekaApp.ViewModels.Nowy;
using System.Diagnostics;
using BibliotekaApp.Views.Edytuj;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Edytuj
{
    [QueryProperty(nameof(IdEgzemplarza), nameof(IdEgzemplarza))]
    public class EgzemplarzDetailViewModel : NowyEgzemplarzViewModel
    {
        private int _IdEgzemplarza;
        private int _IdKsiazki; 
        private int _IdCzytelnika;
        private int _IdPracownika;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public EgzemplarzDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdEgzemplarza
        {
            get => _IdEgzemplarza.ToString();
            set
            {
                _IdEgzemplarza = Convert.ToInt32(value);
                LoadItemId(_IdEgzemplarza);
            }
        }

        public int IdKsiazki
        {
            get => _IdKsiazki;
            set => SetProperty(ref _IdKsiazki, value);
        }
        public int IdCzytelnika
        {
            get => _IdCzytelnika;
            set => SetProperty(ref _IdCzytelnika, value);
        }
        public int IdPracownika
        {
            get => _IdPracownika;
            set => SetProperty(ref _IdPracownika, value);
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                RokWydania = item.RokWydania;
                IdKsiazki = item.IdKsiazki;
                IdCzytelnika = item.IdCzytelnika;
                DataOddania = item.Data_Oddania ?? DateTime.Now;
                DataWypozyczenia = item.Data_Wypozyczenia ?? DateTime.Now;
                IdPracownika = item.IdPracownika;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Egzemplarze() {
                IdEgzemplarza = _IdEgzemplarza,
                IdKsiazki = IdKsiazki,
                RokWydania = RokWydania,
                IdCzytelnika = IdCzytelnika,
                Data_Wypozyczenia = DataWypozyczenia,
                Data_Oddania = DataOddania,
                IdPracownika = IdPracownika
            });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdEgzemplarza);
            await Shell.Current.GoToAsync("..");
        }
    }
}
