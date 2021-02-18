using BibliotekaApp.ViewModels.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Business
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WypozyczenieKsiazkiGrupaWiekowaPage : ContentPage
    {
        public WypozyczenieKsiazkiGrupaWiekowaPage()
        {
            InitializeComponent();
            BindingContext = new WypozyczenieKsiazkiGrupaWiekowaViewModel();
        }
    }
}