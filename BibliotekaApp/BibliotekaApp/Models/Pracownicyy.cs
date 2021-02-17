using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.Models
{
    public class Pracownicyy
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public int? IdFili { get; set; }
        public string FiliaNazwa { get; set; }
    }
}
