CREATE DATABASE IF NOT EXISTS ModeloDeReferencia;

USE ModeloDeReferencia;

CREATE TABLE categoria (
	id INT IDENTITY(1,1) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE nivel_maturidade (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR (100) NOT NULL,
	descricao VARCHAR (400),	
	PRIMARY KEY (id)	
);

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

CREATE TABLE meta_especifica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome	VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	areaProcessoId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (areaProcessoId) REFERENCES area_processo(id)
);

CREATE TABLE pratica_especifica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome	VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	metaEspecificaId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (metaEspecificaId) REFERENCES meta_especifica(id)
);

CREATE TABLE produto_trabalho (
	id INT IDENTITY(1,1) NOT NULL,
	nome VARCHAR (100) NOT NULL,
	template VARCHAR(100),
	PRIMARY KEY (id)
);

CREATE TABLE nivel_capacidade ( 
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	PRIMARY KEY (id)	
);

CREATE TABLE modelo (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	areaProcessoId INT,	
	PRIMARY KEY (id),
	FOREIGN KEY (areaProcessoId) REFERENCES area_processo(id)	
);

CREATE TABLE meta_generica (
	id INT IDENTITY(1,1) NOT NULL,
	sigla VARCHAR(10) NOT NULL,
	nome VARCHAR(100) NOT NULL,
	descricao VARCHAR(400),
	nivelCapacidadeId INT,
	modeloId INT,
	PRIMARY KEY (id),
	FOREIGN KEY (nivelCapacidadeId) REFERENCES nivel_capacidade(id),
	FOREIGN KEY (nivelCapacidadeId) REFERENCES modelo(id)
);

