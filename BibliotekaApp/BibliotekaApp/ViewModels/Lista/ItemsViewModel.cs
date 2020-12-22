using BibliotekaApp.Models;
using BibliotekaApp.Views.Nowy;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class ItemsViewModel : AItemsViewModel<Item>
    {
        public ItemsViewModel()
            : base()
        {
            Title = "Items";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}