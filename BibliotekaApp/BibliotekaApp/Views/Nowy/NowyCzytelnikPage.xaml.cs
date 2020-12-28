using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Nowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyCzytelnikPage : ContentPage
    {
        public Czytelnicy Item { get; set; }

        public NowyCzytelnikPage()
        {
            InitializeComponent();
            BindingContext = new NowyCzytelnikViewModel();
        }

    }
}
