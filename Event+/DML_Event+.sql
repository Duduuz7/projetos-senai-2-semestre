--DML 

INSERT INTO TiposDeUsuario(TituloTipoDeUsuario)
VALUES('Comum'),('Administrador');

INSERT INTO TiposDeEvento(TituloTipoDeEvento)
VALUES('SQL Server');

INSERT INTO Instituicao(CNPJ,Endereco,NomeFantasia)
VALUES('83094672000130','Rua Niter�i, 180 S�o Caetano do Sul','DevSchool')

INSERT INTO Usuario(IdTiposDeUsuario,Nome,Email,Senha)
VALUES(1,'Eduardo','eduardo.felipe.2005@hotmail.com','1234567'),(2,'Felipe','felipe.eduardo.2002@hotmail.com','7654321')

INSERT INTO Evento(IdInstituicao,IdTiposDeEvento,Nome,Descricao,DataEvento,HorarioEvento)
VALUES(1,1,'Introdu��o ao Banco de Dados','Aula introdut�ria ao SQL Server','2023-08-12','17:00:00')

INSERT INTO PresencasEvento(IdUsuario,IdEvento,Situacao)
VALUES(1,1,1)

INSERT INTO ComentarioEvento(IdUsuario,IdEvento,Descricao,Exibe)
VALUES(1,1,'Amei o evento, foi incr�vel !!!',1)


SELECT * FROM ComentarioEvento