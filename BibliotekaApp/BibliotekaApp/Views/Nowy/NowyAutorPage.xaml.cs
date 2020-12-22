using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;
using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Nowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyAutorPage : ContentPage
    {
        public Autorzy Item { get; set; }
        public NowyAutorPage()
        {
            InitializeComponent();
            BindingContext = new NowyAutorViewModel();
        }
    }
}