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
    [QueryProperty(nameof(IdPracownika), nameof(IdPracownika))]
    public class PracownikDetailViewModel : NowyPracownikViewModel
    {
        private int _IdPracownika;
        private int _IdFili;
        public Command EditCommand { get; }
        public Command DelCommand { get; }

        public PracownikDetailViewModel() : base()
        {
            EditCommand = new Command(OnEdit);
            DelCommand = new Command(OnDel);
        }


        public string IdPracownika
        {
            get => _IdPracownika.ToString();
            set
            {
                _IdPracownika = Convert.ToInt32(value);
                LoadItemId(_IdPracownika);
            }
        }
        public int IdFili
        {
            get => _IdFili;
            set => SetProperty(ref _IdFili, value);
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Imie = item.Imie;
                Nazwisko = item.Nazwisko;
                Pesel = item.Pesel;
                IdFili = item.IdFili??0;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await DataStore.UpdateItemAsync(new Pracownicyy() {
                IdPracownika = _IdPracownika,
                Imie = Imie,
                Nazwisko = Nazwisko,
                Pesel = Pesel,
                IdFili = IdFili
            });
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDel()
        {
            await DataStore.DeleteItemAsync(_IdPracownika);
            await Shell.Current.GoToAsync("..");
        }
    }
}
