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
        public async override void GoToEditPage(Ksiegarnie item)
        {
            await Shell.Current.GoToAsync($"{nameof(KsiegarnieDetailPage)}?{nameof(KsiegarnieDetailViewModel.IdKsiegarni)}={item.IdKsiegarni}");
        }
    }
}