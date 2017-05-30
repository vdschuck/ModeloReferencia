CREATE TABLE nivel_maturidade (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR (100) NOT NULL,
	descricao VARCHAR (400),	
	PRIMARY KEY (id)	
);
