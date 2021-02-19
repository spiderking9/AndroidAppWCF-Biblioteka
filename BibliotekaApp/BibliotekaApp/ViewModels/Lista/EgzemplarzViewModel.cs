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
    public class EgzemplarzViewModel : AItemsViewModel<Egzemplarze>
    {
        public EgzemplarzViewModel()
            : base()
        {
            Title = "Egzemplarze";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyEgzemplarzPage));
        }
        public async override void GoToEditPage(Egzemplarze item)
        {
            await Shell.Current.GoToAsync($"{nameof(EgzemplarzDetailPage)}?{nameof(EgzemplarzDetailViewModel.IdEgzemplarza)}={item.IdEgzemplarza}");
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytul Ksiazka ASC", "Tytul Ksiazka DSC" , "Pracownik DSC" , "Pracownik ASC" };

        }

        public override void Sort()
        {
            if (SortField == "Tytul Ksiazka DSC")
                Items = new ObservableCollection<Egzemplarze>(Items.OrderByDescending(item => item.KsiazkaTytul));
            if (SortField == "Tytul Ksiazka ASC")
                Items = new ObservableCollection<Egzemplarze>(Items.OrderBy(item => item.KsiazkaTytul));
            if (SortField == "Pracownik DSC")
                Items = new ObservableCollection<Egzemplarze>(Items.OrderByDescending(item => item.PracownikNazwisko));
            if (SortField == "Pracownik ASC")
                Items = new ObservableCollection<Egzemplarze>(Items.OrderBy(item => item.PracownikNazwisko));
        }

        public override void Filtr()
        {
            Items = new ObservableCollection<Egzemplarze>(Items.Where(item => 
                item.KsiazkaTytul.Contains(FiltrField)|| 
                item.PracownikNazwisko.Contains(FiltrField) ||
                item.RokWydania.ToString().Contains(FiltrField)));
        }
    }
}