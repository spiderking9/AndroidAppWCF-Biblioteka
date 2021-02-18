using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfProjektFirmy.Model.Entieties;

namespace WcfProjektFirmy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceBiblioteka
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<AutorForView> GetAutor();
        [OperationContract]
        List<CzytelnikForView> GetCzytelnik();
        [OperationContract]
        List<EgzemplarzForView> GetEgzemplarz();
        [OperationContract]
        List<FilieForView> GetFilie();
        [OperationContract]
        List<GatunekForView> GetGatunek();
        [OperationContract]
        List<KsiazkaForView> GetKsiazka();
        [OperationContract]
        List<KsiegarniaForView> GetKsiegarnia();
        [OperationContract]
        List<PracownicyForView> GetPracownicy();
        [OperationContract]
        List<ZamowieniaForView> GetZamowienia();
        [OperationContract]
        void AddAutor(Autor autor);
        [OperationContract]
        void AddCzytelnik (Czytelnik czytelnik);
        [OperationContract]
        void AddEgzemplarz(Egzemplarz egzem);
        [OperationContract]
        void AddFilia(FilieBiblioteki filie);
        [OperationContract]
        void AddKsiazka(Ksiazka ksiazka);
        [OperationContract]
        void AddKsiegarnia(Ksiegarnia ksieg);
        [OperationContract]
        void AddPracownicy(Pracownicy prac);
        [OperationContract]
        void AddZamowienia(Zamowienia zamow);
        [OperationContract]
        void AddGatunki(Gatunek gatunek);


        [OperationContract]
        void EditAutor(Autor autor);
        [OperationContract]
        void EditCzytelnik(Czytelnik czytelnik);
        [OperationContract]
        void EditEgzemplarz(Egzemplarz egzem);
        [OperationContract]
        void EditFilia(FilieBiblioteki filie);
        [OperationContract]
        void EditKsiazka(Ksiazka ksiazka);
        [OperationContract]
        void EditKsiegarnia(Ksiegarnia ksieg);
        [OperationContract]
        void EditPracownicy(Pracownicy prac);
        [OperationContract]
        void EditZamowienia(Zamowienia zamow);
        [OperationContract]
        void EditGatunki(Gatunek gatunek);

        [OperationContract]
        void DelAutor(int id);
        [OperationContract]
        void DelCzytelnik(int id);
        [OperationContract]
        void DelEgzemplarz(int id);
        [OperationContract]
        void DelFilia(int id);
        [OperationContract]
        void DelKsiazka(int id);
        [OperationContract]
        void DelKsiegarnia(int id);
        [OperationContract]
        void DelPracownicy(int id);
        [OperationContract]
        void DelZamowienia(int id);
        [OperationContract]
        void DelGatunki(int id);


        [OperationContract]
        decimal? LiczbaDniWypozyczonejKsiazki(int idKsiazki, DateTime DataOd, DateTime DataDo);
        [OperationContract]
        decimal? LiczbaDniWypozyczeniaKsiazekPrzezPracownika(int IdPracownika, DateTime DataOd, DateTime DataDo);
        [OperationContract]
        decimal? IleDniMialaKsiazkiWypozyczoneDanaGrupaWiekowa(int RokOd, int RokDo);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class AutorForView
    {
        [DataMember]
        public int IdAutora { get; set; }
        [DataMember]
        public string Imie { get; set; }
        [DataMember]
        public string Nazwisko { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public string Ksiazki { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
    [DataContract]
    public class CzytelnikForView
    {
        [DataMember]
        public int IdCzytelnika { get; set; }
        [DataMember]
        public string Imie { get; set; }
        [DataMember]
        public string Nazwisko { get; set; }
        [DataMember]
        public string Adres { get; set; }
        [DataMember]
        public long Pesel { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

    }
    [DataContract]
    public class EgzemplarzForView
    {
        [DataMember]
        public int IdEgzemplarza { get; set; }
        [DataMember]
        public int IdKsiazki { get; set; }
        [DataMember]
        public string KsiazkaTytul { get; set; }
        [DataMember]
        public int RokWydania { get; set; }
        [DataMember]
        public int? IdCzytelnika { get; set; }
        [DataMember]
        public string CzytelnikNazwisko { get; set; }
        [DataMember]
        public DateTime? DataWypozyczenia { get; set; }
        [DataMember]
        public DateTime? DataOddania { get; set; }
        [DataMember]
        public int? IdPracownika { get; set; }
        [DataMember]
        public string PracownikNazwisko { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class FilieForView
    {
        [DataMember]
        public int IdFili { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public string Adres { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class GatunekForView
    {
        [DataMember]
        public int IdGatunku { get; set; }
        [DataMember]
        public string NazwaGatunku { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
    [DataContract]
    public class KsiazkaForView
    {
        [DataMember]
        public int IdKsiazki { get; set; }
        [DataMember]
        public string Tytul { get; set; }
        [DataMember]
        public int? LiczbaEgzDostepnych { get; set; }
        [DataMember]
        public int IdGatunku { get; set; }
        [DataMember]
        public string GatunekNazwa { get; set; }
        [DataMember]
        public string Autorzy { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class KsiegarniaForView
    {
        [DataMember]
        public int IdKsiegarni { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public string Adres { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
    [DataContract]
    public class PracownicyForView
    {
        [DataMember]
        public int IdPracownika { get; set; }
        [DataMember]
        public string Imie { get; set; }
        [DataMember]
        public string Nazwisko { get; set; }
        [DataMember]
        public string Pesel { get; set; }
        [DataMember]
        public int? IdFilii { get; set; }
        [DataMember]
        public string FiliaNazwa { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
    [DataContract]
    public class ZamowieniaForView
    {
        [DataMember]
        public int IdZamowienia { get; set; }
        [DataMember]
        public int? IdKsiazki { get; set; }
        [DataMember]
        public string KsiazkaTytul { get; set; }
        [DataMember]
        public int? IdPracownika { get; set; }
        [DataMember]
        public string PracownikNazwisko { get; set; }
        [DataMember]
        public int? IdKsiegarni { get; set; }
        [DataMember]
        public string KsiegarniaNazwa { get; set; }
        [DataMember]
        public int? RokWydania { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
