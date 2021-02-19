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
    public class KsiazkaViewModel : AItemsViewModel<Ksiazki>
    {
        public KsiazkaViewModel()
            : base()
        {
            Title = "Ksiazki";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyKsiazkaPage));
        }
        public async override void GoToEditPage(Ksiazki item)
        {
            await Shell.Current.GoToAsync($"{nameof(KsiazkiDetailPage)}?{nameof(KsiazkiDetailViewModel.IdKsiazki)}={item.IdKsiazki}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytul DSC", "Tytul ASC", "Nazwa Gatunku DSC", "Nazwa Gatunku ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Tytul DSC")
                Items = new ObservableCollection<Ksiazki>(Items.OrderByDescending(item => item.Tytul));
            if (SortField == "Tytul ASC")
                Items = new ObservableCollection<Ksiazki>(Items.OrderBy(item => item.Tytul));
            if (SortField == "Nazwa Gatunku DSC")
                Items = new ObservableCollection<Ksiazki>(Items.OrderByDescending(item => item.NazwaGatunku));
            if (SortField == "Nazwa Gatunku ASC")
                Items = new ObservableCollection<Ksiazki>(Items.OrderBy(item => item.NazwaGatunku));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Ksiazki>(Items.Where(item =>
                item.Tytul.ToLower().Contains(FiltrField.ToLower()) ||
                item.NazwaGatunku.ToLower().Contains(FiltrField.ToLower())));
        }
    }
}