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
    
    public partial class Autor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autor()
        {
            this.Ksiazka_Autor = new HashSet<Ksiazka_Autor>();
        }
    
        public int IdAutora { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Opis { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ksiazka_Autor> Ksiazka_Autor { get; set; }
    }
}
