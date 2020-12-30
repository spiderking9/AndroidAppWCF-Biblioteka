using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
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
    }
}