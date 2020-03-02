CREATE DATABASE InLock_Games_Manha;
GO

USE InLock_Games_Manha;
GO


CREATE TABLE Studio
(
	IdStudio INT IDENTITY PRIMARY KEY
	,NomeStudio VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE TiposUsuario
(
	IdTipoUsuario INT IDENTITY PRIMARY KEY
	,TituloTipoUsuario VARCHAR(255) NOT NULL UNIQUE
);
GO


CREATE TABLE Usuarios
(
IdUsuario INT IDENTITY PRIMARY KEY
,Email VARCHAR(255) NOT NULL UNIQUE
,Senha VARCHAR(255) NOT NULL
,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario (IdTipoUsuario)
);
GO

CREATE TABLE Jogos
(
	IdJogo INT IDENTITY PRIMARY KEY
	,NomeJogo VARCHAR(200) NOT NULL UNIQUE
	,Descricao VARCHAR(200) NOT NULL
	,DataLancamento DATETIME2
	,Valor VARCHAR(8) NOT NULL
	,IdStudio INT FOREIGN KEY REFERENCES Studio (IdStudio)
);
GO