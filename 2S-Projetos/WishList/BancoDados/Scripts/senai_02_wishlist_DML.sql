-- DML

USE WishList
GO

INSERT INTO Usuario(nomeUsuario,email,senha)
VALUES ('Gustavo Borges','gborges@email.com','gborges123'),
       ('Gustavo Rezende','grezende@email.com','grezende123'),
	   ('L�via Negrini','livia@email.com','livia123'),
	   ('Felipe Lino','linobiro@email.com','lino123');
GO


INSERT INTO Desejo(IdUsuario,titulo,descricao)
VALUES 
       (1,'iPhone 12','A14 Bionic, o chip mais r�pido em um smartphone. Tela OLED de ponta a ponta. Ceramic Shield quatro vezes mais resistente a quedas. E modo Noite em todas as c�meras. O iPhone 12 vem com tudo.'),
       (3, 'Iphone 13', 'O mais novo celular da Apple. Possui modo cinema, onde nenhum outro se compara.')
GO




