CREATE DATABASE ONGClubeDosAumigos

USE ONGClubeDosAumigos

CREATE TABLE Adotante(

	CPF varchar(11) NOT NULL,
	Nome varchar(50) NOT NULL,
	Sexo Char(1) NOT NULL,
	DataNasc Date NOT NULL,
	Telefone varchar(11) NOT NULL,
	Logradouro varchar(50) NOT NULL,
	Numero varchar (10) NOT NULL,
	Complemento varchar (10),
	Bairro varchar (50) NOT NULL,
	Cidade varchar (50) NOT NULL,
	Estado varchar (2) NOT NULL

	CONSTRAINT PK_Adotante PRIMARY KEY (CPF)
);

CREATE TABLE Animal(

	Num_Chip int identity,
	Familia varchar (30) NOT NULL,
	Raca varchar (30) NOT NULL,
	Sexo char (1) NOT NULL,
	Nome varchar (50) NOT NULL

	CONSTRAINT PK_Animal PRIMARY KEY (Num_Chip)
);

CREATE TABLE Controle_Adocao(
pr
	Num_Chip int identity NOT NULL,
	CPF varchar(11) NOT NULL,
	Data_Adocao Date NOT NULL

	CONSTRAINT PK_Controle_Adocao PRIMARY KEY (Num_Chip, CPF),
	CONSTRAINT PK_Num_Chip FOREIGN KEY (Num_Chip) REFERENCES Animal (Num_Chip),
	CONSTRAINT PK_CPF FOREIGN KEY (CPF) REFERENCES Adotante (CPF)

);

SELECT * FROM Adotante;
SELECT * FROM Animal;
SELECT * FROM Adota;