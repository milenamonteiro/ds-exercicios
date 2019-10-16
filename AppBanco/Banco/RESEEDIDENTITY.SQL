select * from tbUsuario;
GO
declare ultimo  = select top 1 idUsu from tbUsuario order by IdUsu desc; 
dbcc checkident(tbUsuario, reseed, 9);

Insert into tbUsuario(NomeUsu,Cargo,Data) VALUES( 'Epaminondas', 'Provador de Caixão', CONVERT(DATETIME,'25/04/2009',103))