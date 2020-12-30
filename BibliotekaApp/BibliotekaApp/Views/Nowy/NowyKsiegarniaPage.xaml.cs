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
    public partial class NowyKsiegarniaPage : ContentPage
    {
        public Autorzy Item { get; set; }
        public NowyKsiegarniaPage()
        {
            InitializeComponent();
            BindingContext = new NowyKsiegarniaViewModel();
        }
    }
}