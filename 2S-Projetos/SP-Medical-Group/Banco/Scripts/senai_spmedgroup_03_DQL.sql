--DQL

USE SPMEDGROUP
GO

-- Sele��o para mostrar as tabelas

-- tipos de usuarios
SELECT * FROM tipoUsuario;

-- usuarios
SELECT * FROM usuario;

-- endere�os
SELECT * FROM endereco;

-- pacientes
SELECT * FROM paciente;

-- situa��o da consulta
SELECT * FROM situacao;

-- especialidades 
SELECT * FROM especialidades;

-- clinicas 
SELECT * FROM clinica;

-- medicos 
SELECT * FROM medicos;

-- consultas
SELECT * FROM consultas;


-- Quantidade de Usu�rios
SELECT COUNT(idUsuario) 'Qtde Usu�rios' FROM usuario;
GO

-- Mostrar m�dicos e especialidade correspondente
SELECT nomeMedico 'Nome do m�dico',especialidades
FROM medicos
INNER JOIN especialidades
ON especialidades.idEpecialidade = medicos.idEspecialidade;

-- Mostrar dados no modelo do Prontu�rio 
SELECT nome 'Nome', dataNasc 'Data de nascimento', telefone 'Telefone',RG,CPF
FROM paciente;
GO

-- Convertendo a data de nascimento do usu�rio para o formato (mm-dd-yyyy) 
SELECT FORMAT(dataNasc, 'dd/MM/yyyy')  FROM paciente;
GO

-- Lista de Consultas 
SELECT nome 'Prontu�rio', nomeMedico 'M�dico', FORMAT(dataHora, 'dd/MM/yyyy hh.mm') 'Data e hor�rio', situacao 'Situa��o', nomeClinica 'Clinica', Endereco.logadouro 'Logadouro', Endereco.numero 'N�', Endereco.municipio 'Munic�pio', Endereco.estado 'Estado'
FROM consultas
INNER JOIN medicos
ON medicos.idMedico = consultas.idMedico
INNER JOIN clinica
ON clinica.idClinica = medicos.idClinica
INNER JOIN endereco
On endereco.idEndereco = clinica.idEndereco
INNER JOIN paciente
ON paciente.idPaciente = consultas.idPaciente
INNER JOIN endereco E
ON E.idEndereco = paciente.idEndereco
INNER JOIN situacao
ON situacao.idSituacao = consultas.idSituacao
ORDER BY consultas.idConsulta asc;
GO

-- Function que mostra o Paciente e a situa��o da consulta
CREATE FUNCTION SituacaoPaciente()
RETURNS TABLE
AS
RETURN
 SELECT nome 'Nome do Paciente',situacao 'Situa��o da Consulta'
 FROM consultas
 INNER JOIN situacao
 ON situacao.idSituacao = consultas.idSituacao
 INNER JOIN paciente
 ON consultas.idPaciente = paciente.idPaciente;
 GO


-- Stored Procedurew para retornar o tempo que falta para a consulta
CREATE PROCEDURE TempoRestante
@Nome VARCHAR(30)
    AS
 BEGIN
 -- � poss�vel colocar qual quer coluna antes do CASE
SELECT dataHora, CASE WHEN  DATEDIFF(DAY,dataHora,GETDATE()) >= 0
      THEN 'Essa consulta ja passou do prazo' 
      ELSE 'Consulta no prazo' END  AS 'Prazo Consulta'

-- D�vida com professor Lucas e Saulo 
-- case when nome_coluna  = 'valor' then 'o que mostrar end as nome_coluna
-- ou case nome_coluna when 'valor' then 'o que mostrar ' end  as nome_coluna
  FROM consultas U
 INNER JOIN paciente P
    ON U.idPaciente = P.idPaciente
 WHERE nome = @Nome
   END;
GO

EXEC TempoRestante'Alexandre';
GO

CREATE PROCEDURE Idade
AS 
SELECT nome 'Nome do Paciente', dataNasc 'Data de nascimento', DATEDIFF(year, (dataNasc), getdate()) 'Idade do Paciente', Telefone, RG, CPF FROM Paciente;
GO
--exec para chamar a stored procedure
EXEC Idade;
GO

