﻿using BibliotekaApp.Services;
using BibliotekaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotekaApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            DependencyService.Register<AutorDataStore>();
            DependencyService.Register<EgzemplarzDataStore>();
            DependencyService.Register<CzytelnikDataStore>();
            DependencyService.Register<FilieDataStore>();
            DependencyService.Register<KsiazkaDataStore>();
            DependencyService.Register<KsiegarniaDataStore>();
            DependencyService.Register<PracownikDataStore>();
            DependencyService.Register<ZamownieniaDataStore>();
            DependencyService.Register<GatunekDataStore>();

            DependencyService.Register<WypozyczenieKsiazkiDataStore>();

            DependencyService.Register<ServiceReferenceBiblioteka.ServiceBibliotekaClient>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
