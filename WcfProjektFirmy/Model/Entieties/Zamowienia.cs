//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfProjektFirmy.Model.Entieties
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zamowienia
    {
        public int IdZamowienia { get; set; }
        public Nullable<int> IdKsiazki { get; set; }
        public Nullable<int> IdPracownika { get; set; }
        public Nullable<int> IdKsiegarni { get; set; }
        public Nullable<int> RokWydania { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Ksiazka Ksiazka { get; set; }
        public virtual Ksiazka Ksiazka1 { get; set; }
        public virtual Ksiegarnia Ksiegarnia { get; set; }
        public virtual Pracownicy Pracownicy { get; set; }
    }
}
