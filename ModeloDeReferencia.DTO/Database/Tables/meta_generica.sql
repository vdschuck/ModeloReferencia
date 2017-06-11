CREATE TABLE meta_generica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	nivelCapacidadeId INT,
	modeloId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (nivelCapacidadeId) REFERENCES nivel_capacidade(id),
	FOREIGN KEY (modeloId) REFERENCES modelo(id)
);