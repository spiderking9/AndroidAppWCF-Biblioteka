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
    public class ZamowieniaViewModel : AItemsViewModel<Zamowieniaa>
    {
        public ZamowieniaViewModel()
            : base()
        {
            Title = "Zamowienia";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyZamowieniePage));
        }

        public async override void GoToEditPage(Zamowieniaa item)
        {
            await Shell.Current.GoToAsync($"{nameof(ZamowienieDetailPage)}?{nameof(ZamowieniaDetailViewModel.IdZamowienia)}={item.IdZamowienia}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Ksiazka DSC", "Ksiazka ASC", "Ksiegarnia DSC", "Ksiegarnia ASC", "Pracownik DSC", "Pracownik ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Ksiazka DSC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderByDescending(item => item.KsiazkaTytul));
            if (SortField == "Ksiazka ASC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderBy(item => item.KsiazkaTytul));
            if (SortField == "Ksiegarnia DSC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderByDescending(item => item.KsiegarniaNazwa));
            if (SortField == "Ksiegarnia ASC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderBy(item => item.KsiegarniaNazwa));
            if (SortField == "Pracownik DSC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderByDescending(item => item.PracownikNazwisko));
            if (SortField == "Pracownik ASC")
                Items = new ObservableCollection<Zamowieniaa>(Items.OrderBy(item => item.PracownikNazwisko));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Zamowieniaa>(Items.Where(item =>
                item.KsiazkaTytul.ToLower().Contains(FiltrField.ToLower()) ||
                item.KsiegarniaNazwa.ToLower().Contains(FiltrField.ToLower()) ||
                item.PracownikNazwisko.ToLower().Contains(FiltrField.ToLower()) ||
                item.RokWydania.ToString().Contains(FiltrField)));
        }
    }
}