using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyFilieViewModel : ANewItemViewModel<Filie>
    {
        private string _Nazwa;
        private string _Adres;
        public NowyFilieViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_Nazwa);
        }
        public string Nazwa
        {
            get => _Nazwa;
            set => SetProperty(ref _Nazwa, value);
        }
        public string Adres
        {
            get => _Adres;
            set => SetProperty(ref _Adres, value);
        }
        public override Filie SetItem()
        {
            Filie newItem = new Filie()
            {
                Nazwa = Nazwa,
                Adres = Adres
            };
            return newItem;
        }
    }
}
