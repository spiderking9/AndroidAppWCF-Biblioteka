using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
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
    }
}