﻿using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.Views.Edytuj;
using BibliotekaApp.Views.Nowy;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class EgzemplarzViewModel : AItemsViewModel<Egzemplarze>
    {
        public EgzemplarzViewModel()
            : base()
        {
            Title = "Egzemplarze";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyEgzemplarzPage));
        }
        public async override void GoToEditPage(Egzemplarze item)
        {
            await Shell.Current.GoToAsync($"{nameof(EgzemplarzDetailPage)}?{nameof(EgzemplarzDetailViewModel.IdEgzemplarza)}={item.IdEgzemplarza}");
        }
    }
}