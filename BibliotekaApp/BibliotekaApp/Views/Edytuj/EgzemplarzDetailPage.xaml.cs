using BibliotekaApp.ViewModels.Edytuj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Edytuj
{
    public partial class EgzemplarzDetailPage : ContentPage
    {
        public EgzemplarzDetailPage()
        {
            InitializeComponent();
            BindingContext = new EgzemplarzDetailViewModel();
        }
    }
}