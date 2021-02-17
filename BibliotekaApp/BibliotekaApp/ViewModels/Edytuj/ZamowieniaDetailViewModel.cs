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
    [QueryProperty(nameof(IdZamowienia), nameof(IdZamowienia))]
    public class ZamowieniaDetailViewModel : NowyZamownienieViewModel
    {
        private int _IdZamowienia;
        private int _IdKsiazki; 
        private int _IdPracownika;
        private int _IdKsiegarni;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public ZamowieniaDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdZamowienia
        {
            get => _IdZamowienia.ToString();
            set
            {
                _IdZamowienia = Convert.ToInt32(value);
                LoadItemId(_IdZamowienia);
            }
        }

        public int IdKsiazki
        {
            get => _IdKsiazki;
            set => SetProperty(ref _IdKsiazki, value);
        }
        public int IdKsiegarni
        {
            get => _IdKsiegarni;
            set => SetProperty(ref _IdKsiegarni, value);
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
                IdKsiazki = item.IdKsiazki??0;
                RokWydania = item.RokWydania??0;
                IdPracownika = item.IdPracownika??0;
                IdKsiegarni = item.IdKsiegarni??0;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Zamowieniaa() {
                IdZamowienia = _IdZamowienia,
                IdKsiazki = IdKsiazki,
                IdPracownika = IdPracownika,
                IdKsiegarni = IdKsiegarni,
                RokWydania = RokWydania
            });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdZamowienia);
            await Shell.Current.GoToAsync("..");
        }
    }
}
