--DML

USE M_Rental;
GO
-- CLIENTE
-- MARCA
-- MODELO
-- VEICULO
-- ALUGUEL

INSERT INTO CLIENTE (nomeCliente,sobrenome)
VALUES ('Gustavo','Rezende'),('Neymar','Junior'),
       ('Cristiano','Alveiro'),('Kevin','Nascimento');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('VW'),('Fiat'),
       ('Chevrolet'),('Toyota');
GO

INSERT INTO MODELO (nomeModelo, idMarca)
VALUES ('Gol',1), ('Palio',2),
       ('Jett',3),('Onix',4);
GO

INSERT INTO VEICULO (idModelo, PLACA)
VALUES (2,'AAA'), (3,'BBB'),
       (4,'CCC'), (5,'EEE');
GO

INSERT INTO ALUGUEL (idVeiculo, idCliente, DataDevol, DataRetirada)
VALUES (2,2,'02/10/2021','02/09/2021'),(3,1,'03/09/2021','03/10/2021'),
       (4,2,'04/09/2021','04/10/2021'),(5,3,'15/11/2021','15/12/2021');
GO






