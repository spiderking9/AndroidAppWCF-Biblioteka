using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.Views.Edytuj;
using BibliotekaApp.Views.Nowy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class FilieViewModel : AItemsViewModel<Filie>
    {
        public FilieViewModel()
            : base()
        {
            Title = "Filie";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyFiliePage));
        }
        public async override void GoToEditPage(Filie item)
        {
            await Shell.Current.GoToAsync($"{nameof(FilieDetailPage)}?{nameof(FilieDetailViewModel.IdFili)}={item.IdFili}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa DSC", "Nazwa ASC", "Adres DSC", "Adres ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Nazwa DSC")
                Items = new ObservableCollection<Filie>(Items.OrderByDescending(item => item.Nazwa));
            if (SortField == "Nazwa ASC")
                Items = new ObservableCollection<Filie>(Items.OrderBy(item => item.Nazwa));
            if (SortField == "Adres DSC")
                Items = new ObservableCollection<Filie>(Items.OrderByDescending(item => item.Adres));
            if (SortField == "Adres ASC")
                Items = new ObservableCollection<Filie>(Items.OrderBy(item => item.Adres));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Filie>(Items.Where(item =>
                item.Nazwa.ToLower().Contains(FiltrField.ToLower()) ||
                item.Adres.ToLower().Contains(FiltrField.ToLower())));
        }
    }
}