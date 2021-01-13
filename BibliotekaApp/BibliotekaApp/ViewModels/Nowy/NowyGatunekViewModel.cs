using System;
using System.Collections.Generic;
using System.Text;
using BibliotekaApp.Models;

namespace BibliotekaApp.ViewModels.Nowy
{
    public class NowyGatunekViewModel : ANewItemViewModel<Gatunki>
    {
        private string _NazwaGatunku;
        private string _Opis;
        public NowyGatunekViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_NazwaGatunku);
        }
        public string NazwaGatunku
        {
            get => _NazwaGatunku;
            set => SetProperty(ref _NazwaGatunku, value);
        }
        public string Opis
        {
            get => _Opis;
            set => SetProperty(ref _Opis, value);
        }
        public override Gatunki SetItem()
        {
            Gatunki newItem = new Gatunki()
            {
                NazwaGatunku = NazwaGatunku,
                Opis = Opis
            };
            return newItem;
        }
    }
}
