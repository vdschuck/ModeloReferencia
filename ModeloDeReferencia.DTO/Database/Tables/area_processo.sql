CREATE TABLE area_processo (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	nivelMaturidadeId INT,
	categoriaId INT, 
	PRIMARY KEY (id),
	FOREIGN KEY (nivelMaturidadeId) REFERENCES nivel_maturidade(id),
	FOREIGN KEY (categoriaId) REFERENCES categoria(id)
);