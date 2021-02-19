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
    public class PracownikViewModel : AItemsViewModel<Pracownicyy>
    {
        public PracownikViewModel()
            : base()
        {
            Title = "Pracownicy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyPracownikPage));
        }
        public async override void GoToEditPage(Pracownicyy item)
        {
            await Shell.Current.GoToAsync($"{nameof(PracownikDetailPage)}?{nameof(PracownikDetailViewModel.IdPracownika)}={item.IdPracownika}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie DSC", "Imie ASC", "Nazwisko DSC", "Nazwisko ASC" };

        }
        public override void Sort()
        {
            if (SortField == "Imie DSC")
                Items = new ObservableCollection<Pracownicyy>(Items.OrderByDescending(item => item.Imie));
            if (SortField == "Imie ASC")
                Items = new ObservableCollection<Pracownicyy>(Items.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko DSC")
                Items = new ObservableCollection<Pracownicyy>(Items.OrderByDescending(item => item.Nazwisko));
            if (SortField == "Nazwisko ASC")
                Items = new ObservableCollection<Pracownicyy>(Items.OrderBy(item => item.Nazwisko));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Pracownicyy>(Items.Where(item =>
                item.Imie.ToLower().Contains(FiltrField.ToLower()) ||
                item.Nazwisko.ToLower().Contains(FiltrField.ToLower()) ||
                item.FiliaNazwa.ToLower().Contains(FiltrField.ToLower()) ||
                item.Pesel.ToString().Contains(FiltrField)));
        }
    }
}