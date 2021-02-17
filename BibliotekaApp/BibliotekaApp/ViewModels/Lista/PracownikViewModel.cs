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
        public async override void GoToEditPage(Pracownicyy item)
        {
            await Shell.Current.GoToAsync($"{nameof(PracownikDetailPage)}?{nameof(PracownikDetailViewModel.IdPracownika)}={item.IdPracownika}");
        }
    }
}