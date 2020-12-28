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
        public DateTime? DataWypozyczenia { get; set; }
        public DateTime? DataOddania { get; set; }
        public string PracownikNazwisko { get; set; }
    }
}
