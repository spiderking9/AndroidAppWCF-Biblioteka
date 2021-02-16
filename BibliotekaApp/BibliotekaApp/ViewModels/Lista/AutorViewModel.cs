using System;
using System.Collections.Generic;
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
    }
}