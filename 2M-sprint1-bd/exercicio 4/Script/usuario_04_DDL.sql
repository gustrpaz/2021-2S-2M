CREATE DATABASE USUARIO;
GO

USE USUARIO;
GO

CREATE TABLE USUARIO(
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
	nomeUsuario VARCHAR(20) NOT NULL,
	emailUsuario VARCHAR(35) NOT NULL UNIQUE,
	senhaUsuario VARCHAR (35) NOT NULL,
);
GO

CREATE TABLE TIPO(
tipoUsuario VARCHAR(35) PRIMARY KEY NOT NULL
);
GO

CREATE TABLE ARTISTA(
idArtista SMALLINT PRIMARY KEY IDENTITY(1,1),
nomeArtista VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE ALBUNS(
idAlbum SMALLINT PRIMARY KEY IDENTITY (1,1),
idArtista SMALLINT FOREIGN KEY REFERENCES ARTISTA (idArtista),
idEstilo SMALLINT FOREIGN KEY REFERENCES ESTILO(idEstilo),
titulo VARCHAR (35) NOT NULL,
dtLancamento DATE NOT NULL,
localizacao VARCHAR(40) NOT NULL,
qtdeMinutos TINYINT NOT NULL,
situacao VARCHAR(35) NOT NULL,
artista VARCHAR (35) NOT NULL,
estilos VARCHAR (35) NOT NULL
);
GO

CREATE TABLE ESTILOALBUM (
	idEstiloAlbum SMALLINT PRIMARY KEY IDENTITY(1,1),
	idAlbum SMALLINT FOREIGN KEY REFERENCES ALBUNS(idAlbum),
	idEstilo SMALLINT FOREIGN KEY REFERENCES ESTILO(idEstilo)
);
GO

CREATE TABLE ESTILO (
	idEstilo SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeEstilo VARCHAR(30) NOT NULL
);
GO

