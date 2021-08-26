-- Criar o banco de dados chamado SENAI_HROADS_MANHA
CREATE DATABASE SENAI_HROADS_MANHA;
GO

USE SENAI_HROADS_MANHA;
GO

CREATE TABLE Classe(
idClasse INT PRIMARY KEY IDENTITY (1,1),
nomeClasse VARCHAR(25) UNIQUE NOT NULL
);
GO

CREATE TABLE Habilidade(
idHabilidade INT PRIMARY KEY IDENTITY (1,1),
nomeHabilidade VARCHAR(25) UNIQUE NOT NULL
);
GO

CREATE TABLE Tipos_Habilidade (
idTipos INT PRIMARY KEY IDENTITY(1,1),
idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade),
nomeTipo VARCHAR(12) NOT NULL
);
GO


CREATE TABLE Classe_Habilidade (
id INT PRIMARY KEY IDENTITY (1,1),
idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade),
idClasse INT FOREIGN KEY REFERENCES  Classe(idClasse),
);
GO


CREATE TABLE Personagem (
idPersonagem INT PRIMARY KEY IDENTITY(1,1),
idClasse INT FOREIGN KEY REFERENCES Classe(idClasse),
nomePersonagem VARCHAR(25) NOT NULL,
capacidadeMaxVida SMALLINT NOT NULL,
capacidadeMaxMana SMALLINT NOT NULL,
dataCriacao DATE NOT NULL,
dataAtualizacao DATE NOT NULL
);
GO

