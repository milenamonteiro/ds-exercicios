USE master;
GO

IF DB_ID('dbEXEMPLO1') is not null DROP DATABASE dbEXEMPLO1;
CREATE DATABASE dbEXEMPLO1;
GO

USE dbEXEMPLO1;
GO

CREATE TABLE tbUsuario (
IdUsu int primary key identity(1,1),
NomeUsu varchar(50) not null,
Cargo varchar(50) not null,
Data date 
);
GO

INSERT INTO tbUsuario (NomeUsu, Cargo, Data)
	VALUES ('Bob', 'Motorista', '04/06/2019'),
	('Maria', '171', '04/16/2019');
GO

delete from tbUsuario where IdUsu = 1017 or IdUsu = 1018;

SET IDENTITY_INSERT tbUsuario off

insert into tbUsuario(NomeUsu, Cargo, data)
 values('Emma', 'Cerimonialista', '2000-04-17'),
	   ('Matheus', 'a', '2002-08-22'),
	   ('Gina', 'Limpadora de Vomito', '2001-01-28'),
	   ('Astrogildo', 'Pentelho', '2009-04-25'),
	   ('Epaminondasx', 'provador de caixao', '2019-05-01'),
	   ('Gratiano', 'resgatador de bola de golfe', '2009-05-02'),
	   ('Alem do mar', 'dorminhoco', '2008-07-02');


SELECT * FROM tbUsuario;
GO

