-- DQL 

---- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usu�rio..!
Tipo do usu�rio..!
Data do evento..!
Local do evento (Institui��o)..!
Titulo do evento..!
Nome do evento..!
Descri��o do evento..!
Situa��o do evento!
Coment�rio do evento!
*/

SELECT 
	Usuario.Nome AS NomeUsuario,
	TiposDeUsuario.TituloTipoDeUsuario AS [TipoDeUsuario],
	Evento.DataEvento,Evento.Nome AS NomeEvento,
	TiposDeEvento.TituloTipoDeEvento AS TipoDoEvento,
	Instituicao.NomeFantasia + ', ' + Instituicao.Endereco [LocalDoEvento],
	Evento.Descricao AS DescricaoEvento,
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmado' ELSE 'N�o Confirmado' END AS SituacaoPresenca,
	ComentarioEvento.Descricao AS ComentarioEvento
FROM
	Usuario
	INNER JOIN TiposDeUsuario ON Usuario.IdTiposDeUsuario = TiposDeUsuario.IdTiposDeUsuario
	INNER JOIN PresencasEvento ON PresencasEvento.IdUsuario = Usuario.IdUsuario
	INNER JOIN Evento ON Evento.IdEvento = PresencasEvento.IdEvento
	INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
	INNER JOIN TiposDeEvento ON Evento.IdTiposDeEvento = TiposDeEvento.IdTipoDeEvento
	LEFT JOIN ComentarioEvento ON ComentarioEvento.IdUsuario = Usuario.IdUsuario