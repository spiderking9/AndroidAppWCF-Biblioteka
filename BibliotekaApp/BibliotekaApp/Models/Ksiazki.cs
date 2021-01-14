using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.Models
{
    public class Ksiazki
    {
        public int IdKsiazki { get; set; }
        public string Tytul { get; set; }
        public string LiczbaEgzDostepnych { get; set; }
        public int IdGatunku { get; set; }
        public string NazwaGatunku { get; set; }
        public string Autorzy { get; set; }
    }
}
