USE [master]
GO
/****** Object:  Database [BibliotekaPlutaLukasz]    Script Date: 30.12.2020 21:30:05 ******/
CREATE DATABASE [BibliotekaPlutaLukasz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BibliotekaPlutaLukasz', FILENAME = N'C:\Users\Luk\BibliotekaPlutaLukasz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BibliotekaPlutaLukasz_log', FILENAME = N'C:\Users\Luk\BibliotekaPlutaLukasz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BibliotekaPlutaLukasz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ARITHABORT OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET  MULTI_USER 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET QUERY_STORE = OFF
GO
USE [BibliotekaPlutaLukasz]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BibliotekaPlutaLukasz]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutora] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](60) NOT NULL,
	[Nazwisko] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ksiazka]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ksiazka](
	[IdKsiazki] [int] IDENTITY(1,1) NOT NULL,
	[Tytul] [nvarchar](60) NOT NULL,
	[LiczbaEgzDostepnych] [int] NULL,
	[IdGatunku] [int] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKsiazki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ksiazka_Autor]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ksiazka_Autor](
	[IdKsiazki] [int] NOT NULL,
	[IdAutora] [int] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKsiazki] ASC,
	[IdAutora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Ksiazki_Autorzy]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Ksiazki_Autorzy] 
as
select K.IdKsiazki,K.Tytul,A.Imie,A.Nazwisko from Ksiazka K join Ksiazka_Autor KA 
on K.IdKsiazki=KA.IdKsiazki join Autor A on A.IdAutora=KA.IdAutora
GO
/****** Object:  Table [dbo].[Egzemplarz]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Egzemplarz](
	[IdEgzemplarza] [int] IDENTITY(1,1) NOT NULL,
	[IdKsiazki] [int] NOT NULL,
	[RokWydania] [int] NOT NULL,
	[IdCzytelnika] [int] NULL,
	[DataWypozyczenia] [datetime] NULL,
	[DataOddania] [datetime] NULL,
	[IdPracownika] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEgzemplarza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Pokaz_Ile_Egzeplarzy]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Pokaz_Ile_Egzeplarzy]
as
Select C.IdKsiazki,K.Tytul,C.IleEgzemplarzy from (select Count(E.IdEgzemplarza) IleEgzemplarzy ,IdKsiazki from Egzemplarz E group by IdKsiazki) C join Ksiazka K
on C.IdKsiazki=K.IdKsiazki
GO
/****** Object:  View [dbo].[Liczba_Egz_Stan]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Liczba_Egz_Stan]
as
select Count(IdEgzemplarza) IleEgzemplarzy from Egzemplarz
GO
/****** Object:  View [dbo].[Liczba_Ksia_Stan]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Liczba_Ksia_Stan]
as
select Count(IdKsiazki) IleKsiazek from Ksiazka
GO
/****** Object:  Table [dbo].[Czytelnik]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Czytelnik](
	[IdCzytelnika] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](60) NOT NULL,
	[Nazwisko] [nvarchar](50) NOT NULL,
	[Adres] [nvarchar](150) NOT NULL,
	[Pesel] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCzytelnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Liczba_Czytelnikow]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Liczba_Czytelnikow]
as
select Count(IdCzytelnika) IleCzytelnikow from Czytelnik
GO
/****** Object:  View [dbo].[Spoznienia]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Spoznienia]
as
Select C.IdCzytelnika,C.Imie,C.Nazwisko,C.Adres,E.IleZaleglosci from (select Distinct E1.*,E2.DataOddania from 
(Select Count(IdCzytelnika) IleZaleglosci,IdCzytelnika from Egzemplarz group by IdCzytelnika) E1 join Egzemplarz E2
on E1.IdCzytelnika=E2.IdCzytelnika) E join Czytelnik C on E.IdCzytelnika=C.IdCzytelnika where E.DataOddania<Getdate()
GO
/****** Object:  Table [dbo].[Gatunek]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gatunek](
	[IdGatunku] [int] IDENTITY(1,1) NOT NULL,
	[NazwaGatunku] [nvarchar](60) NOT NULL,
	[Opis] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGatunku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[JakieKsiazkiGatunku]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[JakieKsiazkiGatunku] (@Gatunek nvarchar(60))
returns table
as
return (select K.IdKsiazki,K.Tytul,K.LiczbaEgzDostepnych from Ksiazka K join Gatunek G On K.IdGatunku=G.IdGatunku 
where G.NazwaGatunku=@Gatunek)
GO
/****** Object:  UserDefinedFunction [dbo].[PokazWypozyczoneKsiazki]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[PokazWypozyczoneKsiazki] (@Imie nvarchar(60),@Nazwisko nvarchar(60))
returns table
as
return (select E.IdEgzemplarza,K.IdKsiazki,K.Tytul from Egzemplarz E join Czytelnik C on E.IdCzytelnika=C.IdCzytelnika join Ksiazka K 
on K.IdKsiazki=E.IdKsiazki where C.Imie=@Imie and C.Nazwisko=@Nazwisko)
GO
/****** Object:  UserDefinedFunction [dbo].[JakieKsiazkiAutora]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[JakieKsiazkiAutora] (@AutorImie nvarchar(60),@AutorNazwisko nvarchar(50))
returns table
as
return (select K.IdKsiazki,K.Tytul,K.LiczbaEgzDostepnych from Ksiazka K join Ksiazka_Autor KA on K.IdKsiazki=KA.IdKsiazki join Autor A on KA.IdAutora=A.IdAutora
where A.Imie=@AutorImie and A.Nazwisko=@AutorNazwisko)
GO
/****** Object:  Table [dbo].[FilieBiblioteki]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilieBiblioteki](
	[IdFili] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nchar](10) NULL,
	[Adres] [nchar](10) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_FilieBiblioteki] PRIMARY KEY CLUSTERED 
(
	[IdFili] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ksiegarnia]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ksiegarnia](
	[IdKsiegarni] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nchar](10) NULL,
	[Adres] [nchar](10) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Ksiegarnia] PRIMARY KEY CLUSTERED 
(
	[IdKsiegarni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pracownicy]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pracownicy](
	[IdPracownika] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nchar](10) NULL,
	[Nazwisko] [nchar](10) NULL,
	[Pesel] [nchar](10) NULL,
	[IdFilii] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Pracownicy] PRIMARY KEY CLUSTERED 
(
	[IdPracownika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zamowienia]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienia](
	[IdZamowienia] [int] IDENTITY(1,1) NOT NULL,
	[IdKsiazki] [int] NULL,
	[IdPracownika] [int] NULL,
	[IdKsiegarni] [int] NULL,
	[RokWydania] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Zamowienia] PRIMARY KEY CLUSTERED 
(
	[IdZamowienia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Gatunek] ADD  CONSTRAINT [DF_Gatunek_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Egzemplarz]  WITH CHECK ADD  CONSTRAINT [FK_Egzemplarz_Czytelnik] FOREIGN KEY([IdCzytelnika])
REFERENCES [dbo].[Czytelnik] ([IdCzytelnika])
GO
ALTER TABLE [dbo].[Egzemplarz] CHECK CONSTRAINT [FK_Egzemplarz_Czytelnik]
GO
ALTER TABLE [dbo].[Egzemplarz]  WITH CHECK ADD  CONSTRAINT [FK_Egzemplarz_Ksiazka] FOREIGN KEY([IdKsiazki])
REFERENCES [dbo].[Ksiazka] ([IdKsiazki])
GO
ALTER TABLE [dbo].[Egzemplarz] CHECK CONSTRAINT [FK_Egzemplarz_Ksiazka]
GO
ALTER TABLE [dbo].[Egzemplarz]  WITH CHECK ADD  CONSTRAINT [FK_Egzemplarz_Pracownicy] FOREIGN KEY([IdPracownika])
REFERENCES [dbo].[Pracownicy] ([IdPracownika])
GO
ALTER TABLE [dbo].[Egzemplarz] CHECK CONSTRAINT [FK_Egzemplarz_Pracownicy]
GO
ALTER TABLE [dbo].[Ksiazka]  WITH CHECK ADD FOREIGN KEY([IdGatunku])
REFERENCES [dbo].[Gatunek] ([IdGatunku])
GO
ALTER TABLE [dbo].[Ksiazka_Autor]  WITH CHECK ADD FOREIGN KEY([IdAutora])
REFERENCES [dbo].[Autor] ([IdAutora])
GO
ALTER TABLE [dbo].[Ksiazka_Autor]  WITH CHECK ADD FOREIGN KEY([IdKsiazki])
REFERENCES [dbo].[Ksiazka] ([IdKsiazki])
GO
ALTER TABLE [dbo].[Pracownicy]  WITH CHECK ADD  CONSTRAINT [FK_Pracownicy_FilieBiblioteki] FOREIGN KEY([IdFilii])
REFERENCES [dbo].[FilieBiblioteki] ([IdFili])
GO
ALTER TABLE [dbo].[Pracownicy] CHECK CONSTRAINT [FK_Pracownicy_FilieBiblioteki]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Ksiazka] FOREIGN KEY([IdKsiazki])
REFERENCES [dbo].[Ksiazka] ([IdKsiazki])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Ksiazka]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Ksiazka1] FOREIGN KEY([IdKsiazki])
REFERENCES [dbo].[Ksiazka] ([IdKsiazki])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Ksiazka1]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Ksiegarnia] FOREIGN KEY([IdKsiegarni])
REFERENCES [dbo].[Ksiegarnia] ([IdKsiegarni])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Ksiegarnia]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Pracownicy] FOREIGN KEY([IdPracownika])
REFERENCES [dbo].[Pracownicy] ([IdPracownika])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Pracownicy]
GO
ALTER TABLE [dbo].[Czytelnik]  WITH CHECK ADD CHECK  ((len([Pesel])=(11)))
GO
/****** Object:  StoredProcedure [dbo].[DodajKsiazke]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DodajKsiazke] (@Tytul NVARCHAR(60), @NazwaGatunku NVARCHAR(60),@RokWydania INT)
as
BEGIN TRAN
if exists(select * from Ksiazka where Tytul=@Tytul)
begin
	insert into Egzemplarz values ((select IdKsiazki from Ksiazka where Tytul=@Tytul),@RokWydania,null,null,null)
	update Ksiazka Set LiczbaEgzDostepnych=LiczbaEgzDostepnych+1 where Tytul=@Tytul
end
else
begin
	if not exists(select * from Gatunek where NazwaGatunku=@NazwaGatunku)
		insert into Gatunek values (@NazwaGatunku,null)
	insert into Ksiazka values (@Tytul,1,(select IdGatunku from Gatunek where NazwaGatunku=@NazwaGatunku))
	insert into Egzemplarz values ((select IdKsiazki from Ksiazka where Tytul=@Tytul),@RokWydania,null,null,null)
end
IF @@ERROR <> 0
	ROLLBACK
ELSE
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[KtoNajwiecejZalega]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KtoNajwiecejZalega]
as
select * from Spoznienia where IleZaleglosci=(select Max(IleZaleglosci) Egzemplarzy from Spoznienia)
GO
/****** Object:  StoredProcedure [dbo].[UsunCzytelnika]    Script Date: 30.12.2020 21:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UsunCzytelnika] (@Pesel BigInt)
as
BEGIN TRAN
update Egzemplarz Set DataOddania=null, DataWypozyczenia=null, IdCzytelnika=null where IdEgzemplarza in (select E.IdEgzemplarza from Egzemplarz E join Czytelnik C on E.IdCzytelnika=C.IdCzytelnika where Pesel=@Pesel)
delete from Czytelnik where Pesel=@Pesel
IF @@ERROR <> 0
	ROLLBACK
ELSE
	COMMIT
GO
USE [master]
GO
ALTER DATABASE [BibliotekaPlutaLukasz] SET  READ_WRITE 
GO
