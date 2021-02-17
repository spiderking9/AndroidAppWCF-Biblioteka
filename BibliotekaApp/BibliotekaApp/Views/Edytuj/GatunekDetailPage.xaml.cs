using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.ViewModels.Nowy;
using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Edytuj
{
    public partial class GatunekDetailPage : ContentPage
    {
        public GatunekDetailPage()
        {
            InitializeComponent();
            BindingContext = new GatunekDetailViewModel();
        }
    }
}