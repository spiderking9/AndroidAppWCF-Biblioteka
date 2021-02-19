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
    public class GatunekViewModel : AItemsViewModel<Gatunki>
    {
        public GatunekViewModel()
            : base()
        {
            Title = "Gatunki";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyGatunekPage));
        }
        public async override void GoToEditPage(Gatunki item)
        {
            await Shell.Current.GoToAsync($"{nameof(GatunekDetailPage)}?{nameof(GatunekDetailViewModel.IdGatunku)}={item.IdGatunku}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa Gatunku DSC", "Nazwa Gatunku ASC", "Opis DSC", "Opis ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Nazwa Gatunku DSC")
                Items = new ObservableCollection<Gatunki>(Items.OrderByDescending(item => item.NazwaGatunku));
            if (SortField == "Nazwa Gatunku ASC")
                Items = new ObservableCollection<Gatunki>(Items.OrderBy(item => item.NazwaGatunku));
            if (SortField == "Opis DSC")
                Items = new ObservableCollection<Gatunki>(Items.OrderByDescending(item => item.Opis));
            if (SortField == "Opis ASC")
                Items = new ObservableCollection<Gatunki>(Items.OrderBy(item => item.Opis));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Gatunki>(Items.Where(item =>
                item.NazwaGatunku.ToLower().Contains(FiltrField.ToLower()) ||
                item.Opis.ToLower().Contains(FiltrField.ToLower())));
        }
    }
}