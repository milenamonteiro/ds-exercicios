USE master;
GO

IF DB_ID('dbEXEMPLO') is not null DROP DATABASE dbExemplo;
GO

CREATE DATABASE dbEXEMPLO;
GO

USE dbEXEMPLO;
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

SELECT * FROM tbUsuario;
begin tran
delete from tbUsuario where IdUsu >= 1002 
--commit tran
GO