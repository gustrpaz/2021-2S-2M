USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('BBBB'), ('CCCC'),
       ('DDDD'), ('EEEE');
GO

Select * FROM EMPRESA;
GO


INSERT INTO VEICULO (idModelo, PLACA)
VALUES (1,'AAA'), (2,'BBB'),
       (3,'CCC'), (4,'EEE');
GO

Select * FROM VEICULO;
GO

DELETE FROM VEICULO



INSERT INTO MODELO (nomeModelo, idMarca)
VALUES ('Gol',1), ('Palio',2),
       ('Jett',3),('Onix',4);
GO

Select * FROM MODELO;
GO


INSERT INTO MARCA (nomeMarca)
VALUES ('VW'),('Fiat'),
       ('Chevrolet'),('Toyota');
GO

Select * FROM MARCA;
GO


INSERT INTO CLIENTE (nomeCliente)
VALUES ('Lucas'),('Gustavo'),
       ('Odirlei'),('Saulo');
GO

Select * FROM CLIENTE;
GO

INSERT INTO ALUGUEL (idVeiculo, idCliente, DataDevol)
VALUES (1,2,02-08),(2,1,03-08),
       (1,2,04-08),(3,3,05-08);
GO

SELECT * FROM ALUGUEL
GO
