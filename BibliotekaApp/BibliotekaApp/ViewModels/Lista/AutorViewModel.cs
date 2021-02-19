using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.Views.Edytuj;
using BibliotekaApp.Views.Nowy;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class AutorViewModel : AItemsViewModel<Autorzy>
    {
        public AutorViewModel()
            : base()
        {
            Title = "Autorzy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyAutorPage));
        }

        public async override void GoToEditPage(Autorzy item)
        {
            await Shell.Current.GoToAsync($"{nameof(AutorDetailPage)}?{nameof(AutorDetailViewModel.IdAutora)}={item.IdAutora}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie DSC", "Imie ASC", "Nazwisko DSC", "Nazwisko ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Imie DSC")
                Items = new ObservableCollection<Autorzy>(Items.OrderByDescending(item => item.Imie));
            if (SortField == "Imie ASC")
                Items = new ObservableCollection<Autorzy>(Items.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko DSC")
                Items = new ObservableCollection<Autorzy>(Items.OrderByDescending(item => item.Nazwisko));
            if (SortField == "Nazwisko ASC")
                Items = new ObservableCollection<Autorzy>(Items.OrderBy(item => item.Nazwisko));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Autorzy>(Items.Where(item =>
                item.Imie.ToLower().Contains(FiltrField.ToLower()) ||
                item.Nazwisko.ToLower().Contains(FiltrField.ToLower()) ||
                item.Opis.ToLower().Contains(FiltrField.ToLower())));
        }
    }
}