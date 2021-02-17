using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    }
}