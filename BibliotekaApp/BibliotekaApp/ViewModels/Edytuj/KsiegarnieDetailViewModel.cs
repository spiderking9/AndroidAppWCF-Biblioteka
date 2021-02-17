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
    [QueryProperty(nameof(IdKsiegarni), nameof(IdKsiegarni))]
    public class KsiegarnieDetailViewModel: NowyKsiegarniaViewModel
    {
        private int _IdKsiegarni;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public KsiegarnieDetailViewModel():base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdKsiegarni
        {
            get => _IdKsiegarni.ToString();
            set
            {
                _IdKsiegarni = Convert.ToInt32(value);
                LoadItemId(_IdKsiegarni);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Nazwa = item.Nazwa;
                Adres = item.Adres;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Ksiegarnie() { IdKsiegarni = _IdKsiegarni, Nazwa = Nazwa, Adres = Adres});
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdKsiegarni);
            await Shell.Current.GoToAsync("..");
        }
    }
}
