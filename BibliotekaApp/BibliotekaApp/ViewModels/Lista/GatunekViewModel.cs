using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
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
    }
}