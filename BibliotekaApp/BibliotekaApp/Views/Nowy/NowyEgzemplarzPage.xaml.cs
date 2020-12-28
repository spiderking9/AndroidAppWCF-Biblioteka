using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;
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
    public partial class NowyEgzemplarzPage : ContentPage
    {
        public Egzemplarze Item { get; set; }
        public NowyEgzemplarzPage()
        {
            InitializeComponent();
            BindingContext = new NowyEgzemplarzViewModel();
        }
    }
}