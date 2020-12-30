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
    public partial class NowyFiliePage : ContentPage
    {
        public Filie Item { get; set; }
        public NowyFiliePage()
        {
            InitializeComponent();
            BindingContext = new NowyFilieViewModel();
        }
    }
}