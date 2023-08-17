--DQL Health CLinic

USE Projeto_Health_ClinicTD

--SCRIPT

/*Criar script que exiba os seguintes dados:

- Id Consulta
- Data da Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- Prontuário ou Descricao
- FeedBack(Comentario da consulta)

*/

SELECT
	Consulta.IdConsulta,
	Consulta.DataAgendamento,
	Consulta.HorarioAgendamento,
	Clinica.NomeFantasia AS [NomeClinica],
	P.Nome AS [NomePaciente],
	M.Nome AS [NomeMédico],
	Especialidade.TituloEspecialidade AS [Especialidade],
	Medico.CRM,
	Consulta.Prontuario,
	Comentario.Descricao AS [FeedbackConsulta]
FROM
	Consulta
	INNER JOIN Paciente ON Paciente.IdPaciente = Consulta.IdPaciente
	INNER JOIN Medico ON Medico.IdMedico = Consulta.IdMedico
	INNER JOIN Usuario M ON Medico.IdUsuario = M.IdUsuario
	INNER JOIN Usuario P ON Paciente.IdUsuario = P.IdUsuario
	INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	INNER JOIN Clinica ON Clinica.IdClinica = Medico.IdClinica
	LEFT JOIN Comentario ON Comentario.IdPaciente = Paciente.IdPaciente

--FUNCTION DESAFIO

CREATE FUNCTION BuscaMedico
(
	@Especialidade VARCHAR(100)
)
RETURNS TABLE AS
RETURN
(
	SELECT MedicoUsuario.Nome AS Médico, 
	Especialidade.TituloEspecialidade AS Especialidade
	FROM Especialidade
	INNER JOIN Medico ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	INNER JOIN Usuario AS MedicoUsuario ON Medico.IdUsuario = MedicoUsuario.IdUsuario
	WHERE Especialidade.TituloEspecialidade = @Especialidade
);

SELECT * FROM BuscaMedico('Cardiologia')