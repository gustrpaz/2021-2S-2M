USE SENAI_HROADS_MANHA;
GO

SELECT * FROM Usuarios;
GO

SELECT * FROM Tipos_Habilidade;
GO

SELECT * FROM Habilidade;
GO

SELECT * FROM TipoUsuario;
GO

SELECT * FROM Classe_Habilidade;
GO

-- TAREFAS DQL

-- Selecionar todas os personagens
SELECT * FROM Personagem;
GO

-- Selecionar todas as Classes
SELECT * FROM Classe;
GO

-- Selecionar somente o nome das Classes
SELECT nomeClasse FROM Classe;
GO

-- Selecionar todas as Habilidades
SELECT * FROM Habilidade;
GO

-- Realizar a contagem de quantas habilidades estão cadastradas
SELECT COUNT (nomeHabilidade) AS [Habilidades Cadastradas]
FROM Habilidade; 
GO

-- Selecionar somente os id's das Habilidades, classificando-os por ordem crescente
SELECT idHabilidade FROM Habilidade
ORDER BY idHabilidade ASC;
GO

-- Selecionar todos os tipos de Habilidades
SELECT * FROM Tipos_Habilidade;
GO

-- Selecionar todas as Habilidades e a quais tipos de habilidades elas fazem parte
SELECT nomeHabilidade AS [Nome Habilidade], nomeTipo AS [Tipo de Habilidade] FROM Habilidade 
INNER JOIN Tipos_Habilidade 
ON Habilidade.idTipos = Tipos_Habilidade.idTipos;
GO

-- Selecionar todos os Personagens e suas respectivas classes
SELECT nomePersonagem AS [Nome Personagem], nomeClasse [Nome Classe] FROM Personagem
INNER JOIN Classe 
ON Personagem.idClasse = Classe.idClasse;
GO

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagem)
SELECT nomeClasse AS [Nome Classe], nomePersonagem AS [Nome Personagem] FROM Classe 
LEFT JOIN Personagem
ON Personagem.idClasse = Classe.idClasse;
GO


-- Selecionar todas as classes e suas respectivas habilidades
SELECT Classe.nomeClasse AS [Nome Classe], Habilidade.nomeHabilidade AS [Nome Habilidade] FROM Classe_Habilidade
LEFT JOIN Classe
ON Classe_Habilidade.idClasse = Classe.idClasse
LEFT JOIN Habilidade
ON Classe_Habilidade.idHabilidade = Habilidade.idHabilidade;
GO

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência)
SELECT Habilidade.nomeHabilidade AS [Nome Habilidade], Classe.nomeClasse AS [Nome Classe] FROM Classe_Habilidade
INNER JOIN Habilidade
ON Classe_Habilidade.idHabilidade = Habilidade.idHabilidade
INNER JOIN Classe
ON Classe_Habilidade.idClasse = Classe.idClasse;
GO

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência)
SELECT Habilidade.nomeHabilidade AS [Nome Habilidade], Classe.nomeClasse AS [Nome Classe] FROM Classe_Habilidade
FULL OUTER JOIN Habilidade
ON Classe_Habilidade.idHabilidade = Habilidade.idHabilidade
FULL OUTER JOIN Classe
ON Classe_Habilidade.idClasse = Classe.idClasse;
GO


















