using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaApp.ViewModels.Lista;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutorPage : ContentPage
    {
        AutorViewModel _viewModel;
        public AutorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AutorViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}