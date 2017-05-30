CREATE TABLE meta_especifica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome	VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	areaProcessoId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (areaProcessoId) REFERENCES area_processo(id)
);
