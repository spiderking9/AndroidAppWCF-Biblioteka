using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.Services;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyKsiazkaViewModel : ANewItemViewModel<Ksiazki>
    {
        private string _Tytul;
        private int _LiczbaEgzDostepnych;
        private Gatunki _SelectedGatunki;

        public List<Gatunki> Gatunki
        {
            get
            {
                return new GatunekDataStore().items;
            }
        }
        public NowyKsiazkaViewModel()
            : base()
        {
            SelectedGatunki = new Gatunki();
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(SelectedGatunki.NazwaGatunku);
        }
        public Gatunki SelectedGatunki
        {
            get => _SelectedGatunki;
            set => SetProperty(ref _SelectedGatunki, value);
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

        public override Ksiazki SetItem()
        {
            Ksiazki newItem = new Ksiazki()
            {
                Tytul = Tytul,
                LiczbaEgzDostepnych = LiczbaEgzDostepnych.ToString(),
                IdGatunku = SelectedGatunki.IdGatunku
            };
            return newItem;
        }
    }
}
