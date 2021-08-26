USE USUARIO;
GO

INSERT INTO USUARIO(nomeUsuario,emailUsuario,senhaUsuario)
VALUES ('Gustavo','gustavo@hotmail.com','pao1234'),
       ('Murillo','murillo@hotmail.com','bolo1234');
GO

SELECT * FROM USUARIO;
GO

INSERT INTO TIPO (tipoUsuario)
VALUES ('Administrador'),('Aluno');
GO

SELECT * FROM TIPO;
GO

INSERT INTO ARTISTA (nomeArtista)
VALUES ('Igu'),('Kevin');
GO

SELECT * FROM ARTISTA;
GO

DELETE ARTISTA
WHERE nomeArtista = 'poze';

INSERT INTO ALBUNS (idArtista,titulo,dtLancamento,localizacao,qtdeMinutos,situacao,artista,estilos)
VALUES (1,'212',15-11-2020,'SP',240,'ativo','Mc Igu','trap'),
       (2,'passado presente',01-03-2020,'SP',180,'ativo','Mc Kevin','funk');
GO

INSERT INTO ESTILOALBUM (idAlbum, idEstilo)
VALUES (1, 1), (2, 2);
GO 

INSERT INTO ESTILO (nomeEstilo)
VALUES ('Rap'), ('FUNK');
GO 