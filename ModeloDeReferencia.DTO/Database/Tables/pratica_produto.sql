CREATE TABLE pratica_produto (
	praticaEspecificaId INT NOT NULL,
	produtoTrabalhoId INT NOT NULL,
	PRIMARY KEY (praticaEspecificaId, produtoTrabalhoId),
	FOREIGN KEY (praticaEspecificaId) REFERENCES pratica_especifica(id),
	FOREIGN KEY (produtoTrabalhoId) REFERENCES produto_trabalho(id)
);