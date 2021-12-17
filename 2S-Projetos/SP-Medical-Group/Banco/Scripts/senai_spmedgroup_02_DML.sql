--DML

USE SPMEDGROUP
GO


-- Inserindo dados nas tabelas

INSERT INTO tipoUsuario (tipoUsuario)
VALUES ('Administrador'),('M�dico'),('Paciente');
GO

SELECT * FROM tipoUsuario;

INSERT INTO usuario (idTipoUsuario,email,senha)
VALUES (1,' ','123'),(1,'adm2@gmail.com','132'),(2,'ricardo.lemos@spmedicalgroup.com.br','167'),
       (2,'roberto.possarle@spmedicalgroup.com.br','321'),(2,'helena.souza@spmedicalgroup.com.br','111'),
	   (3,'ligia@gmail.com','222'),(3,'alexandre@gmail.com','333'),(3,'fernando@gmail.com','444'),
	   (3,'henrique@gmail.com','555'),(3,'joao@hotmail.com','666'),(3,'bruno@gmail.com','777'),(3,'mariana@outlook.com','888');
GO

SELECT * FROM usuario;

INSERT INTO endereco(logadouro,numero,bairro,municipio,estado,CEP)
VALUES ('Av.Bar�o Limeira','532','Campo Eliseos','S�o Paulo','S�o Paulo','12020-000'),
       ('Rua Estado de Israel','240','Vila Clementino','S�o Paulo','S�o Paulo','04022-000'),
	   ('Av. Paulista','1578','Bela Vista','S�o Paulo','S�o Paulo','01310-200'),
	   ('Av. Ibirapuera','2927',' Indian�polis','S�o Paulo','S�o Paulo','04029-200'),
	   ('Rua Vit�ria','120','Vila Sao Jorge','Barueri','S�o Paulo','06402-030'),
	   ('Rua Ver. Geraldo de Camargo','66','Santa Luzia','Ribeir�o Pires','S�o Paulo','09405-380'),
	   ('Alameda dos Arapan�s','945',' Indian�polis','S�o Paulo','S�o Paulo','04524-001'),
	   ('Rua Sao Antonio','232','Vila Universal','Barueri','S�o Paulo','06407-140');
GO

INSERT INTO paciente(idUsuario,idEndereco,nome,dataNasc,telefone,RG,CPF)
VALUES (6,2,'Ligia','1983-10-13','11 3456-7654','432124576','94839859000'),
       (7,3,'Alexandre','2001-07-23','11 98765-6543','32654345-7','73556944057'),
	   (8,4,'Fernando','1978-10-10','11 97208-4453','54636525-3','16839338002'),
	   (9,5,'Henrique','1985-10-13','11 3456-6543','54366362-5','14332654765'),
	   (10,6,'Jo�o','1975-08-27','11 7656-6377','53254444-1','91305348010'),
	   (11,7,'Bruno','1972-03-21','11 95436-8769','54566266-7','79799299004'),
	   (12,8,'Mariana','2018-03-05','','54566266-8','13771913039');
GO

INSERT INTO situacao (situacao)
VALUES ('Realizada'),('Agendada'),('Cancelada');
GO

-- Adicionado depois
insert into situacao (situacao)
values ('Aguardando');
GO


INSERT INTO especialidades (especialidades)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),
       ('Cirurgia da M�o'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pedi�trica'),
	   ('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),
	   ('Urologia'),('Pediatria'),('Psiquiatria');
GO

INSERT INTO clinica (idEndereco,horaInicio,horaFim,cnpj,nomeClinica,razaoSocial)
VALUES (1,'07:00','22:00','86.400.902/0001-30','Clinica Possarle','SP Medical Group');
GO


INSERT INTO medicos (idUsuario,idClinica,idEspecialidade,CRM,nomeMedico)
VALUES (3,1,2,'54356-SP','Ricardo Lemos'),(4,1,17,'53452-SP','Roberto Possarle'),
       (5,1,16,'65463-SP','Helena Strada');
GO


INSERT INTO consultas (idPaciente,idMedico,idSituacao,dataHora,descricao)
VALUES (7,3,1,'20/01/2020 15:00','An�lise dos problemas apresentados pelo paciente'),(2,2,3,'06/01/2020 10:00','An�lise dos problemas apresentados pelo paciente'),
(3,2,1,'07/02/2020 11:00','An�lise dos problemas apresentados pelo paciente'),
       (2,2,1,'06/02/2018 10:00','An�lise dos problemas apresentados pelo paciente'),(4,1,3,'07/02/2019 11:00','An�lise dos problemas apresentados pelo paciente'),
	   (7,3,2,'08/03/2020 15:00','An�lise dos problemas apresentados pelo paciente'),(4,1,2,'09/03/2020 11:00','An�lise dos problemas apresentados pelo paciente');
GO



-- Insere uma consulta dentro do prazo para a stored procedure
INSERT INTO consultas (idPaciente,idMedico,idSituacao,dataHora,descricao)
VALUES (6,3,2,'15/11/2021 08:00','An�lise dos problemas apresentados pelo paciente');



SELECT * FROM medicos;
SELECT * FROM paciente;
SELECT * FROM usuario;
SELECT * FROM tipoUsuario;
SELECT * FROM consultas;
SELECT * FROM clinica;
SELECT * FROM especialidades;
SELECT * FROM situacao;
SELECT * FROM endereco;




