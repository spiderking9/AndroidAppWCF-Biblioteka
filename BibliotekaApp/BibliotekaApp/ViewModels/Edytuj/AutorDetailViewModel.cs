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
    [QueryProperty(nameof(IdAutora), nameof(IdAutora))]
    public class AutorDetailViewModel: NowyAutorViewModel
    {
        private int _IdAutora;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public AutorDetailViewModel():base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdAutora
        {
            get => _IdAutora.ToString();
            set
            {
                _IdAutora = Convert.ToInt32(value);
                LoadItemId(_IdAutora);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Imie = item.Imie;
                Nazwisko = item.Nazwisko;
                Opis = item.Opis;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Autorzy() { IdAutora = _IdAutora, Imie=Imie, Nazwisko=Nazwisko, Opis=Opis});
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdAutora);
            await Shell.Current.GoToAsync("..");
        }
    }
}
