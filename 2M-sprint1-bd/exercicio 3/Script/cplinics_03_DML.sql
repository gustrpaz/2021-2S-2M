USE PCLINICS;
GO

INSERT INTO CLINICA (nomeClinica,enderecoClinica)
VALUES ('Senai Clinicas','av joao'),('Sesi Clinicas','av paulo'),
       ('Sp Clinicas','av sousa'),('Osasco Clinicas','av pedro');
GO

SELECT * FROM CLINICA;
GO

INSERT INTO PET (idDono, nomePet, DataNasc)
VALUES (1,'Rezende',15-11-2004),(2,'Murillo',02-06-2004);
GO

SELECT * FROM PET;
GO

INSERT INTO RACA(nomeRaca)
VALUES ('shih tzu');


INSERT INTO TIPO(nomeTipo, idRaca)
VALUES ('Cachorro', 2);

INSERT INTO VETERINARIO (idClinica,nomeVET)
VALUES (1,'Odilei'),(1,'Thiago');
GO

SELECT * FROM VETERINARIO;
GO

INSERT INTO CONSULTA (idClinica,idPet,DataCONS)
VALUES (1,1,04/08),(1,2,05/08);
GO

SELECT * FROM CONSULTA;
GO

INSERT INTO DONO (nomeDono)
VALUES ('Lucas'),('Saulo');
GO


SELECT * FROM DONO;
GO

DELETE FROM DONO
WHERE nomeDono = 'Pedro';