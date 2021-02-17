using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BibliotekaApp.ViewModels.Edytuj;

namespace BibliotekaApp.Views.Edytuj
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracownikDetailPage : ContentPage
    {
        public PracownikDetailPage()
        {
            InitializeComponent();
            BindingContext = new PracownikDetailViewModel();
        }
    }
}