using BibliotekaApp.ViewModels.Nowy;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.ViewModels;
using BibliotekaApp.Views.Nowy;
using BibliotekaApp.Views.Edytuj;
using BibliotekaApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BibliotekaApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AutorDetailPage), typeof(AutorDetailPage));
            Routing.RegisterRoute(nameof(CzytelnikDetailPage), typeof(CzytelnikDetailPage));
            Routing.RegisterRoute(nameof(EgzemplarzDetailPage), typeof(EgzemplarzDetailPage));


            Routing.RegisterRoute(nameof(NowyAutorPage), typeof(NowyAutorPage));
            Routing.RegisterRoute(nameof(NowyCzytelnikPage), typeof(NowyCzytelnikPage));
            Routing.RegisterRoute(nameof(NowyEgzemplarzPage), typeof(NowyEgzemplarzPage));
            Routing.RegisterRoute(nameof(NowyFiliePage), typeof(NowyFiliePage));
            Routing.RegisterRoute(nameof(NowyKsiazkaPage), typeof(NowyKsiazkaPage));
            Routing.RegisterRoute(nameof(NowyKsiegarniaPage), typeof(NowyKsiegarniaPage));
            Routing.RegisterRoute(nameof(NowyPracownikPage), typeof(NowyPracownikPage));
            Routing.RegisterRoute(nameof(NowyZamowieniePage), typeof(NowyZamowieniePage));
            Routing.RegisterRoute(nameof(NowyGatunekPage), typeof(NowyGatunekPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
