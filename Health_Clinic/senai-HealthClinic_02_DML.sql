--DML Health CLinic

USE Projeto_Health_ClinicTD

--INSERIR DADOS NAS TABELAS

INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES('Paciente'),('Administrador'),('Médico');

INSERT INTO Clinica(NomeFantasia,RazaoSocial,CNPJ,Endereco,HorarioAbertura,HorarioFechamento)
VALUES('Health Clinic','Health Clinic Atendimnetos Ltda','18713923000156','Rua Niterói, 180 - São Caetano do Sul','07:00:00','20:00:00');

INSERT INTO Especialidade(TituloEspecialidade)
VALUES('Cardiologia'),('Ortopedia'),('Dermatologia');

INSERT INTO Usuario(IdTipoUsuario,Nome,Email,Senha)
VALUES(1,'Eduardo','eduardo1@email.com','12345'),(1,'José','jose2@email.com','54321'),(1,'Maria','maria3@email.com','56789'),
(3,'Carlos','carlos4@email.com','98765'),(3,'Felipe','felipe5@email.com','11111'),(3,'Vinicius','vinicius6@email.com','22222');

INSERT INTO Paciente(IdUsuario,RG,CPF,DataNascimento,Telefone)
VALUES(1,'204057826','73167749083','2005-06-10','11983251603'),(2,'452435687','65870147042','1980-08-15','11983162816'),
(3,'146116288','03341912037','1968-01-23','11997144505');

INSERT INTO Medico(IdUsuario,IdClinica,IdEspecialidade,CRM)
VALUES(4,1,1,'678901/SP'),(5,1,2,'654321/SP'),(6,1,3,'123456/SP');

INSERT INTO Consulta(IdPaciente,IdMedico,Prontuario,DataAgendamento,HorarioAgendamento)
VALUES(2,1,'Precórdio calmo, sem abaulamentos, retrações ou deformidades.','2023-08-15','18:30:00'),(3,2,'Contusão no tornozelo direito.','2023-08-11','08:00:00'),
(4,3,'Lesão primária na mão direita.','2023-08-14','13:45:00');

INSERT INTO Comentario(IdConsulta,IdPaciente,Descricao)
VALUES(1,2,'Consulta expetacular, doutor muito bom !!!'),(2,3,'Achei esse doutor Felipe muito ignorante.'),(3,4,'Doutor me ajudou muito, um fofo !');

SELECT * FROM TipoUsuario
SELECT * FROM Paciente
SELECT * FROM Medico
SELECT * FROM Comentario
SELECT * FROM Consulta