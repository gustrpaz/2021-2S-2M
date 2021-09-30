-- Tabela de tipo de usuários
CREATE TABLE tipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY,
tipoUsuario VARCHAR (30) UNIQUE NOT NULL
);
GO

-- Tabela de Usuários
CREATE TABLE usuario(
idUsuario INT PRIMARY KEY IDENTITY,
idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
email VARCHAR(200) UNIQUE NOT NULL,
senha VARCHAR(10) NOT NULL
);
GO

-- Tabela de endereços
CREATE TABLE endereco(
idEndereco INT PRIMARY KEY IDENTITY,
logadouro VARCHAR(200) NOT NULL,
numero VARCHAR(10) NOT NULL,
bairro VARCHAR (30) NOT NULL,
municipio VARCHAR (30) NOT NULL,
estado VARCHAR (30) NOT NULL,
CEP CHAR (9) UNIQUE,
);
GO

-- Tabela de Pacientes
CREATE TABLE paciente(
idPaciente INT PRIMARY KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES usuario (idUsuario),
idEndereco INT FOREIGN KEY REFERENCES endereco (idEndereco),
nome VARCHAR(50) NOT NULL,
dataNasc DATETIME NOT NULL,
telefone VARCHAR(15) DEFAULT 'NÃO IDENTIFICADO',
RG VARCHAR(15) UNIQUE NOT NULL,
CPF VARCHAR(15) UNIQUE NOT NULL
);
GO

-- Tabela de situação que se encontra as consultas
CREATE TABLE situacao(
idSituacao INT PRIMARY KEY IDENTITY,
situacao VARCHAR(20) UNIQUE NOT NULL 
);
GO
 
-- Tabela de especialidades
CREATE TABLE especialidades(
idEpecialidade INT PRIMARY KEY IDENTITY,
especialidades VARCHAR(50) NOT NULL
);
GO

-- Tabela de Clinicas
CREATE TABLE clinica(
idClinica INT PRIMARY KEY IDENTITY,
idEndereco INT FOREIGN KEY REFERENCES endereco(idEndereco),
horaInicio TIME,
horaFim TIME,
cnpj VARCHAR(20) UNIQUE NOT NULL,
nomeClinica VARCHAR(100) NOT NULL,
razaoSocial VARCHAR(50) NOT NULL
);
GO

-- Tabela de Médicos
CREATE TABLE medicos(
idMedico INT PRIMARY KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES usuario (idUsuario),
idClinica INT FOREIGN KEY REFERENCES clinica (idClinica),
idEspecialidade INT FOREIGN KEY REFERENCES especialidades (idEpecialidade),
CRM VARCHAR (10) UNIQUE NOT NULL,
nomeMedico VARCHAR(50),
);
GO

-- Tabela de Consultas
CREATE TABLE consultas(
idConsulta INT PRIMARY KEY IDENTITY,
idPaciente INT FOREIGN KEY REFERENCES paciente (idPaciente),
idMedico INT FOREIGN KEY REFERENCES medicos (idMedico),
idSituacao INT FOREIGN KEY REFERENCES situacao (idSituacao),
dataHora SMALLDATETIME NOT NULL,
);
GO 

CREATE TABLE imagemUsuario(
idImagemUsuario INT PRIMARY KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES usuario (idUsuario),
binario varbinary (max) NOT NULL,
mimeType varchar (80) NOT NULL,
nomeArquivo varchar (250) NOT NULL,
data_inclusao datetime default getdate() NOT NULL,
);

ALTER TABLE consultas 
add descricao varchar (250);

-- Alterando DATETIME para DATE
ALTER TABLE paciente
ALTER COLUMN dataNasc DATE NOT NULL; 