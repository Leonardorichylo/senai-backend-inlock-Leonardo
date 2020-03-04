USE InLock_Games_Manha;

-- Listar todos os usu�rios
SELECT * FROM Usuarios;

-- Listar todos os Estudios
SELECT * FROM Estudio ;

--Listar todos os Jogos
SELECT * FROM Jogos;

-- Listar todos os jogos e seus respectivos estudios
SELECT NomeJogo, Descricao, DataLancamento, Valor, NomeEstudio FROM Jogos
INNER JOIN Estudio on Estudio.IdEstudio = Jogos.IdEstudio;


-- Buscar um us�ario por email e senha
SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin'

-- Buscar e trazer na lista todos os est�dios (mesmo que eles n�o contenham nenhum jogo de refer�ncia)
 SELECT * FROM Estudio

 -- Buscar um jogo por IdJogo
SELECT NomeJogo, Descricao, DataLancamento, Valor, Estudio.NomeEstudio as Estudio FROM Jogos
INNER JOIN Estudio ON Estudio.idEstudio = Jogos.idEstudio
Where idJogo = 2;

-- Buscar um est�dio por IdEstudio
SELECT NomeEstudio FROM Estudio
WHERE idEstudio = 3;
