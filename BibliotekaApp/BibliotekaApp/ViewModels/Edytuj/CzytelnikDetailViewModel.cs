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
    [QueryProperty(nameof(IdCzytelnika), nameof(IdCzytelnika))]
    public class CzytelnikDetailViewModel : NowyCzytelnikViewModel
    {
        private int _IdCzytelnika;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public CzytelnikDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdCzytelnika
        {
            get => _IdCzytelnika.ToString();
            set
            {
                _IdCzytelnika = Convert.ToInt32(value);
                LoadItemId(_IdCzytelnika);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Imie = item.Imie;
                Nazwisko = item.Nazwisko;
                Adres = item.Adres;
                Pesel = item.Pesel;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Czytelnicy() { IdCzytelnika = _IdCzytelnika, Imie = Imie, Nazwisko = Nazwisko, Adres= Adres, Pesel = Pesel });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdCzytelnika);
            await Shell.Current.GoToAsync("..");
        }
    }
}
