using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Nowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyKsiazkaPage : ContentPage
    {
        public Ksiazki Item { get; set; }
        public NowyKsiazkaPage()
        {
            InitializeComponent();
            BindingContext = new NowyKsiazkaViewModel();
        }
    }
}