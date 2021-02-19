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
    public class CzytelnikViewModel : AItemsViewModel<Czytelnicy>
    {
        public CzytelnikViewModel()
            : base()
        {
            Title = "Czytelnicy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyCzytelnikPage));
        }
        public async override void GoToEditPage(Czytelnicy item)
        {
            await Shell.Current.GoToAsync($"{nameof(CzytelnikDetailPage)}?{nameof(CzytelnikDetailViewModel.IdCzytelnika)}={item.IdCzytelnika}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie DSC", "Imie ASC", "Nazwisko DSC", "Nazwisko ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Imie DSC")
                Items = new ObservableCollection<Czytelnicy>(Items.OrderByDescending(item => item.Imie));
            if (SortField == "Imie ASC")
                Items = new ObservableCollection<Czytelnicy>(Items.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko DSC")
                Items = new ObservableCollection<Czytelnicy>(Items.OrderByDescending(item => item.Nazwisko));
            if (SortField == "Nazwisko ASC")
                Items = new ObservableCollection<Czytelnicy>(Items.OrderBy(item => item.Nazwisko));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Czytelnicy>(Items.Where(item =>
                item.Imie.ToLower().Contains(FiltrField.ToLower()) ||
                item.Nazwisko.ToLower().Contains(FiltrField.ToLower()) ||
                item.Adres.ToLower().Contains(FiltrField.ToLower()) ||
                item.Pesel.ToString().Contains(FiltrField)));
        }
    }
}