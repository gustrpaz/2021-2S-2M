--DQL

USE M_Rental;
GO

SELECT * FROM CLIENTE;

SELECT * FROM MARCA;

SELECT * FROM MODELO;

SELECT * FROM VEICULO;

SELECT * FROM ALUGUEL;

-- Alguns comandos que vão para o visual studio
SELECT idAluguel, DataDevol, DataRetirada, A.idVeiculo
FROM VEICULO V
INNER JOIN ALUGUEL A
ON V.idVeiculo = A.idVeiculo 
WHERE A.idVeiculo = 2;

SELECT idAluguel, nomeCliente, sobrenome, DataDevol, DataRetirada, nomeModelo, PLACA 
FROM ALUGUEL A 
INNER JOIN VEICULO V 
ON A.idVeiculo = V.idVeiculo 
INNER JOIN MODELO M 
ON M.idModelo = V.idModelo 
INNER JOIN CLIENTE C 
ON C.idCliente = A.idCliente;


SELECT idCliente, nomeCliente, sobrenome FROM CLIENTE;

SELECT idCliente, nomeCliente, sobrenome FROM CLIENTE WHERE idCliente = 3;

SELECT idVeiculo, PLACA, nomeModelo FROM VEICULO V INNER JOIN MODELO M ON M.idModelo = V.idModelo;