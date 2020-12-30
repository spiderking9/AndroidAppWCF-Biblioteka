using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.Models
{
    public class Zamowieniaa
    {
        public int IdZamowienia { get; set; }
        public int? IdKsiazki { get; set; }
        public int? IdPracownika { get; set; }
        public int? IdKsiegarni { get; set; }
        public int? RokWydania { get; set; }
    }
}
