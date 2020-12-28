using BibliotekaApp.ViewModels.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CzytelnikPage : ContentPage
    {
        CzytelnikViewModel _viewModel;
        public CzytelnikPage()
        {
            InitializeComponent(); 
            BindingContext = _viewModel = new CzytelnikViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}