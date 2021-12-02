CREATE DATABASE ROMAN;
GO

USE ROMAN;
GO 
 
CREATE TABLE TipoUsuario(
idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
tituloUsuario VARCHAR (14) NOT NULL
);
GO

CREATE TABLE Usuario(
idUsuario TINYINT PRIMARY KEY IDENTITY,
idTipoUsuario TINYINT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
nomeUsuario VARCHAR (50) NOT NULL,
emailUsuario VARCHAR (256) NOT NULL UNIQUE,
senhaUsuario VARCHAR (13) NOT NULL 
);
GO 

CREATE TABLE Tema(
idTema TINYINT PRIMARY KEY IDENTITY,
nomeTema VARCHAR (20) NOT NULL
);
GO 

CREATE TABLE Projeto(
idProjeto TINYINT PRIMARY KEY IDENTITY,
idTema TINYINT FOREIGN KEY REFERENCES Tema(idTema),
nomeProjeto VARCHAR (50) NOT NULL,
descricaoProjeto VARCHAR (256)
);
GO