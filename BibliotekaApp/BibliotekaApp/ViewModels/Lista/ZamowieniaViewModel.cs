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
    }
}