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
    [QueryProperty(nameof(IdGatunku), nameof(IdGatunku))]
    public class GatunekDetailViewModel : NowyGatunekViewModel
    {
        private int _IdGatunku;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public GatunekDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdGatunku
        {
            get => _IdGatunku.ToString();
            set
            {
                _IdGatunku = Convert.ToInt32(value);
                LoadItemId(_IdGatunku);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                NazwaGatunku = item.NazwaGatunku;
                Opis = item.Opis;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Gatunki() { IdGatunku = _IdGatunku, NazwaGatunku = NazwaGatunku, Opis = Opis });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdGatunku);
            await Shell.Current.GoToAsync("..");
        }
    }
}
