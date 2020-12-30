using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Nowy;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Nowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyPracownikPage : ContentPage
    {
        public Pracownicyy Item { get; set; }
        public NowyPracownikPage()
        {
            InitializeComponent();
            BindingContext = new NowyPracownikViewModel();
        }
    }
}