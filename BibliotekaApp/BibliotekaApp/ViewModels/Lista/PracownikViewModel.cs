using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Views.Nowy;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class PracownikViewModel : AItemsViewModel<Pracownicyy>
    {
        public PracownikViewModel()
            : base()
        {
            Title = "Pracownicy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyPracownikPage));
        }
    }
}