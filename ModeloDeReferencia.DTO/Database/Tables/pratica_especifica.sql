CREATE TABLE pratica_especifica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome	VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	metaEspecificaId INT,
	produtoTrabalhoId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (metaEspecificaId) REFERENCES meta_especifica(id),
	FOREIGN KEY (produtoTrabalhoId) REFERENCES produto_trabalho(id)
);