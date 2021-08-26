USE SENAI_HROADS_MANHA;
GO
-- Inserir os registros conforme a descrição do texto

INSERT INTO Classe(nomeClasse)
VALUES ('Bárbaro'), ('Cruzado'), ('Caçadora de Demônios'), ('Monge'), ('Necromante'), ('Feiticeiro'), ('Arcanista');
GO

-- Atualizar o nome da Classe Necromante para Necromancer
UPDATE Classe
SET nomeClasse = 'Necromancer'
WHERE nomeClasse = 'Necromante';
GO

INSERT INTO Habilidade(nomeHabilidade)
VALUES ('Lança Mortal'), ('Escudo Supremo'), ('Recuperar Vida');
GO

INSERT INTO Tipos_Habilidade(idHabilidade, nomeTipo)
VALUES (1, 'Ataque'), (2, 'Defesa'), (3, 'Cura');
GO

INSERT INTO Tipos_Habilidade(nomeTipo)
VALUES ('Magia');
GO

INSERT INTO Classe_Habilidade (idHabilidade, idClasse)
VALUES (1, 1), (2, 1), (2, 2), (1, 3), (3, 4), (2, 4), (3, 6);
GO



INSERT INTO Classe_Habilidade (idClasse)
VALUES (5),(7);
GO


INSERT INTO Personagem (idClasse, nomePersonagem, capacidadeMaxVida, capacidadeMaxMana, DataCriacao, DataAtualizacao)
VALUES (1, 'DeuBug', 100, 80, '2019-01-18', '2021-08-10'),(4, 'BitBug', 70, 100, '2016-03-17', '2021-08-10'), (7, 'Fer8', 75, 60, '2018-03-18', '2021-08-10');
GO

DELETE FROM Personagem WHERE idPersonagem IN (4,5,6);
GO


-- Atualizar o nome do personagem Fer8 para Fer7
UPDATE Personagem
SET nomePersonagem = 'Fer7'
WHERE nomePersonagem = 'Fer8';
GO

