using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Lista;
using BibliotekaApp.ViewModels.Nowy;
using BibliotekaApp.Views.Edytuj;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Edytuj
{
    [QueryProperty(nameof(IdFili), nameof(IdFili))]
    public class FilieDetailViewModel : NowyFilieViewModel
    {
        private int _IdFili;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public FilieDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdFili
        {
            get => _IdFili.ToString();
            set
            {
                _IdFili = Convert.ToInt32(value);
                LoadItemId(_IdFili);
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
            await DataStore.UpdateItemAsync(new Filie() { IdFili = _IdFili, Nazwa = Nazwa, Adres = Adres});
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdFili);
            await Shell.Current.GoToAsync("..");
        }
    }
}
