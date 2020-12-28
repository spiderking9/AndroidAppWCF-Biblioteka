using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Views.Nowy;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class CzytelnikViewModel : AItemsViewModel<Czytelnicy>
    {
        public CzytelnikViewModel()
            : base()
        {
            Title = "Czytelnicy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyCzytelnikPage));
        }
    }
}