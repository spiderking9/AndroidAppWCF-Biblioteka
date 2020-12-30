using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyKsiazkaViewModel : ANewItemViewModel<Ksiazki>
    {
        private string _Tytul;
        private int _LiczbaEgzDostepnych;
        private int _IdGatunku;
        public NowyKsiazkaViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_Tytul);
        }
        public string Tytul
        {
            get => _Tytul;
            set => SetProperty(ref _Tytul, value);
        }
        public int LiczbaEgzDostepnych
        {
            get => _LiczbaEgzDostepnych;
            set => SetProperty(ref _LiczbaEgzDostepnych, value);
        }
        public int IdGatunku
        {
            get => _IdGatunku;
            set => SetProperty(ref _IdGatunku, value);
        }
        public override Ksiazki SetItem()
        {
            Ksiazki newItem = new Ksiazki()
            {
                Tytul = Tytul,
                LiczbaEgzDostepnych = LiczbaEgzDostepnych.ToString(),
                IdGatunku = IdGatunku
            };
            return newItem;
        }
    }
}
