-- Define o banco de dados que será utilizado
USE Filmes;
GO

-- Insere dois gêneros na tabela Generos
INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama')
					,('Romance');
GO

-- Insere dois filmes na tabela Filmes
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1)
					,('Sei lá', 3);
GO

-- Insere dois novos usuários
INSERT INTO Usuarios (Nome,Email, Senha, Permissao)
VALUES				 ('Saulo','saulo@email.com', '123', 'Comum')
					,('Administrador','adm@adm.com', '123', 'Administrador');
GO