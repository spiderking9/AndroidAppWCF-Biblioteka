using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.Models
{
    public class Egzemplarze
    {
        public int IdEgzemplarza { get; set; }
        public string KsiazkaTytul { get; set; }
        public int RokWydania { get; set; }
        public string CzytelnikNazwisko { get; set; }
        public string DataWypozyczenia { get; set; }
        public String DataOddania { get; set; }
        public string PracownikNazwisko { get; set; }
    }
}
