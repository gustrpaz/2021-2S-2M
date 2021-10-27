-- DDL
CREATE DATABASE WishList
GO

USE WishList
GO

-- Tabela de Usuario
CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY (1,1),
nomeUsuario varchar(50) NOT NULL,
email VARCHAR(256) NOT NULL UNIQUE,
senha VARCHAR(20) NOT NULL
);
GO



-- Tabela de Desejo
CREATE TABLE Desejo(
IdDesejo INT PRIMARY KEY IDENTITY (1,1),
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
titulo VARCHAR(50) NOT NULL,
descricao VARCHAR (350) NOT NULL
);
GO



