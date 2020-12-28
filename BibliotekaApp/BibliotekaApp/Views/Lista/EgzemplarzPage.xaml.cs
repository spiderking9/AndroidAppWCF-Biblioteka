﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaApp.ViewModels.Lista;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EgzemplarzPage : ContentPage
    {
        EgzemplarzViewModel _viewModel;
        public EgzemplarzPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EgzemplarzViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}