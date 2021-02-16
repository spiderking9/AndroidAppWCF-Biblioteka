using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Lista;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BibliotekaApp.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KsiazkaPage : ContentPage
    {
        KsiazkaViewModel _viewModel;
        public KsiazkaPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new KsiazkaViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}