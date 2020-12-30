using BibliotekaApp.Models;
using BibliotekaApp.Views.Nowy;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class FilieViewModel : AItemsViewModel<Filie>
    {
        public FilieViewModel()
            : base()
        {
            Title = "Filie";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyFiliePage));
        }
    }
}