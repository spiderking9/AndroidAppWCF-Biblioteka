using ServiceReferenceBiblioteka;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibliotekaApp.Services
{
    public class WypozyczenieKsiazkiDataStore
    {
        public IServiceBiblioteka bibliotekaServices { get; set; }
        public WypozyczenieKsiazkiDataStore()
        {
            bibliotekaServices = DependencyService.Get<ServiceReferenceBiblioteka.IServiceBiblioteka>();
        }

        public decimal? LiczbaDniWypozyczonejKsiazki(int idKsiazki, DateTime DataOd, DateTime DataDo)
        {
            return bibliotekaServices
                .LiczbaDniWypozyczonejKsiazki(new LiczbaDniWypozyczonejKsiazkiRequest(idKsiazki, DataOd, DataDo))
                .LiczbaDniWypozyczonejKsiazkiResult;
        }

        public decimal? LiczbaDniWypozyczeniaKsiazekPrzezPracownika(int IdPracownika, DateTime DataOd, DateTime DataDo)
        {
            return bibliotekaServices
                .LiczbaDniWypozyczeniaKsiazekPrzezPracownika(new LiczbaDniWypozyczeniaKsiazekPrzezPracownikaRequest(IdPracownika, DataOd, DataDo))
                .LiczbaDniWypozyczeniaKsiazekPrzezPracownikaResult;
        }
        public decimal? IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowa(int RokOd, int RokDo)
        {
            return bibliotekaServices
                .IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowa(new IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowaRequest(RokOd, RokDo))
                .IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowaResult;
        }
    }
}
