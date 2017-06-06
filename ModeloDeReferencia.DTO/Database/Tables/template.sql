CREATE TABLE template (
	id INT IDENTITY(1,1) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	diretorio VARCHAR(100),
	descricao VARCHAR(400),
	arquivo INT,	
	PRIMARY KEY (id)	
);