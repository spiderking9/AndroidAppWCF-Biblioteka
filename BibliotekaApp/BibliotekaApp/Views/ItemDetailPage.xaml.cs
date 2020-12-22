using BibliotekaApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BibliotekaApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}