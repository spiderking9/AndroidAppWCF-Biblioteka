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
    [QueryProperty(nameof(IdKsiazki), nameof(IdKsiazki))]
    public class KsiazkiDetailViewModel : NowyKsiazkaViewModel
    {
        private int _IdKsiazki; 
        private int _IdGatunku;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public KsiazkiDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdKsiazki
        {
            get => _IdKsiazki.ToString();
            set 
            {
                _IdKsiazki = Convert.ToInt32(value);
                LoadItemId(_IdKsiazki);
            }
        }
        public int IdGatunku
        {
            get => _IdGatunku;
            set => SetProperty(ref _IdGatunku, value);
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Tytul = item.Tytul;
                LiczbaEgzDostepnych = item.LiczbaEgzDostepnych??0;
                IdGatunku = item.IdGatunku;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Ksiazki() {
                IdKsiazki = _IdKsiazki,
                Tytul = Tytul,
                LiczbaEgzDostepnych = LiczbaEgzDostepnych,
                IdGatunku = IdGatunku
            });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdKsiazki);
            await Shell.Current.GoToAsync("..");
        }
    }
}
