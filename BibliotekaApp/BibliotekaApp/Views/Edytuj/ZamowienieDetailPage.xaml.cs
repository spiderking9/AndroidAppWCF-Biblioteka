using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.ViewModels.Nowy;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Edytuj
{
    public partial class ZamowienieDetailPage : ContentPage
    {
        public ZamowienieDetailPage()
        {
            InitializeComponent();
            BindingContext = new ZamowieniaDetailViewModel();
        }
    }
}