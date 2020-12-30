using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Views.Nowy;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class KsiegarniaViewModel : AItemsViewModel<Ksiegarnie>
    {
        public KsiegarniaViewModel()
            : base()
        {
            Title = "Ksiegarnie";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyKsiegarniaPage));
        }
    }
}