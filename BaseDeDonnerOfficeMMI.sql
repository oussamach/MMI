create database OfficeMMI
use OfficeMMI
--table service
create table Service(
	IdService int primary key identity ,
	LibelleService  varchar(255),
	--Bureau varchar(255),
)
create table Utilisateur(
	IdUtilisateur int  primary key identity,
	NomUtilisateur varchar(255),
	PrenomUtilisateur varchar(255),
	TelephoneUtilisateur varchar(255),
	IdService int foreign key (IdService) references Service(IdService) on delete cascade  on update cascade
)
create table Material( 
	NumInventaire int primary key identity,
	Marque varchar(255),
	NumSerie varchar(100),
	IdUtilisateur int  foreign key (IdUtilisateur) references  Utilisateur(IdUtilisateur) on delete cascade  on update cascade
)
create table panne(
	IdPanne int primary key identity , 
	NumInventaire int  foreign key (NumInventaire) references  Material(NumInventaire)on delete cascade  on update cascade,
	objet varchar(255),
	DateDePanne date,
	--DateSortie date,
	traitement  varchar(255),
	EtatPanne varchar(255),--transferer vers la socieite ou cellule,
	Effectuer  varchar(255), --true= panner reparer , false = en cours 

)
Create table Cellule (
	IdCellule int primary key identity ,
	NomCellule varchar(255)
)
create table Reparateur (
	IdRep int primary key identity ,
	NomRep varchar(255) ,
	PrenomRep  varchar(255),
	TelephoneRep Varchar(100),
	IdCellule int  foreign key (IdCellule) references Cellule(IdCellule)on delete cascade  on update cascade,
)
Create Table Societe(
	IdSociete int primary key identity ,
	NomSociete varchar(255),
)
create table pieces(
	IdPieces int primary key identity,
	NomPieces varchar(255),   
)
create table logiciel (
	Idlogiciel int primary key identity,
	Nomlogiciel varchar(255),   
)

create table Intervention (
	IdIntervention int primary key identity ,
	TypeIntervention varchar(255), 
	IdPanne int  foreign key  (IdPanne) references Panne(IdPanne)on delete cascade  on update cascade,
	IdSociete int foreign key  (IdSociete) references Societe(IdSociete)   on delete cascade  on update cascade NULL,
	IdRep int  foreign key (IdRep) references Reparateur(IdRep) on delete cascade  on update cascade NULL,
	DateDebutIntervention date,
	DateFinIntervention date,
	IdPieces int  foreign key (IdPieces) references pieces(IdPieces) on delete cascade  on update cascade NULL,
	Idlogiciel int  foreign key (Idlogiciel) references logiciel(Idlogiciel) on delete cascade  on update cascade NULL,	
	commentaire  text,
	EtatIntervention varchar (255), --remplcer le material / reapartion effectuer /En cours
)


