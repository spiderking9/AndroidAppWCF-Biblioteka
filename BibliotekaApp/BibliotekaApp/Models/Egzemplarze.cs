using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaApp.Models
{
    public class Egzemplarze
    {
        public int IdEgzemplarza { get; set; }
        public int IdKsiazki { get; set; }
        public string KsiazkaTytul { get; set; }
        public int RokWydania { get; set; }
        public int IdCzytelnika { get; set; }
        public string CzytelnikNazwisko { get; set; }
        public string DataWypozyczenia { get; set; }
        public DateTime? Data_Wypozyczenia { get; set; }
        public string DataOddania { get; set; }
        public DateTime? Data_Oddania { get; set; }
        public int IdPracownika { get; set; }
        public string PracownikNazwisko { get; set; }
    }
}
