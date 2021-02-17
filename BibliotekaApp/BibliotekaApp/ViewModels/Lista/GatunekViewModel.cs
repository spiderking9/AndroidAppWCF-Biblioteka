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
        public async override void GoToEditPage(Gatunki item)
        {
            await Shell.Current.GoToAsync($"{nameof(GatunekDetailPage)}?{nameof(GatunekDetailViewModel.IdGatunku)}={item.IdGatunku}");
        }
    }
}