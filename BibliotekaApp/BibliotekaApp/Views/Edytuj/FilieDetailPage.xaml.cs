using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.ViewModels.Nowy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Edytuj
{

    public partial class FilieDetailPage : ContentPage
    {
        public FilieDetailPage()
        {
            InitializeComponent();
            BindingContext = new FilieDetailViewModel();
        }
    }
}