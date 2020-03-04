USE InLock_Games_Manha;


INSERT INTO TiposUsuario (Titulo)
VALUES		('Administrador')
			,('Cliente')


INSERT INTO Usuarios (Email,Senha,IdTipoUsuario)
VALUES ('admin@admin.com','admin',1)
,('cliente@cliente.com','cliente',2)



INSERT INTO Estudio (NomeEstudio)
VALUES	('Blizzard')
,('Rockstar Studios')
,('Square Enix')


INSERT INTO Jogos (NomeJogo,DataLancamento,Descricao,IdEstudio,Valor)
VALUES	('Diablo 3'
		,'15-05-2012'
		,'é um jogo que contém bastante ação e é viciante, seja um novato ou um fã'
		,1
		,'99')

		,('Red Dead Redemption II'
		, '26-10-2018'
		,'jogo eletrônico de ação-aventura western'
		,2
		,'120')