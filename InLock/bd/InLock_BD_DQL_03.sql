USE InLock_Games_Manha;

-- Listar todos os usuários
SELECT * FROM Usuarios;

-- Listar todos os Estudios
SELECT * FROM Estudio ;

--Listar todos os Jogos
SELECT * FROM Jogos;

-- Listar todos os jogos e seus respectivos estudios
SELECT NomeJogo, Descricao, DataLancamento, Valor, NomeEstudio FROM Jogos
INNER JOIN Estudio on Estudio.IdEstudio = Jogos.IdEstudio;


-- Buscar um usúario por email e senha
SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin'

-- Buscar e trazer na lista todos os estúdios (mesmo que eles não contenham nenhum jogo de referência)
 SELECT * FROM Estudio

 -- Buscar um jogo por IdJogo
SELECT NomeJogo, Descricao, DataLancamento, Valor, Estudio.NomeEstudio as Estudio FROM Jogos
INNER JOIN Estudio ON Estudio.idEstudio = Jogos.idEstudio
Where idJogo = 2;

-- Buscar um estúdio por IdEstudio
SELECT NomeEstudio FROM Estudio
WHERE idEstudio = 3;
