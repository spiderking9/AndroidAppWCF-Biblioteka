﻿using System;
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
    }
}