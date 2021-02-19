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
    public class KsiegarniaViewModel : AItemsViewModel<Ksiegarnie>
    {
        public KsiegarniaViewModel()
            : base()
        {
            Title = "Ksiegarnie";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyKsiegarniaPage));
        }
        public async override void GoToEditPage(Ksiegarnie item)
        {
            await Shell.Current.GoToAsync($"{nameof(KsiegarnieDetailPage)}?{nameof(KsiegarnieDetailViewModel.IdKsiegarni)}={item.IdKsiegarni}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa DSC", "Nazwa ASC", "Adres DSC", "Adres ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Nazwa DSC")
                Items = new ObservableCollection<Ksiegarnie>(Items.OrderByDescending(item => item.Nazwa));
            if (SortField == "Nazwa ASC")
                Items = new ObservableCollection<Ksiegarnie>(Items.OrderBy(item => item.Nazwa));
            if (SortField == "Adres DSC")
                Items = new ObservableCollection<Ksiegarnie>(Items.OrderByDescending(item => item.Adres));
            if (SortField == "Adres ASC")
                Items = new ObservableCollection<Ksiegarnie>(Items.OrderBy(item => item.Adres));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Ksiegarnie>(Items.Where(item =>
                item.Nazwa.ToLower().Contains(FiltrField.ToLower()) ||
                item.Adres.ToLower().Contains(FiltrField.ToLower())));
        }
    }
}