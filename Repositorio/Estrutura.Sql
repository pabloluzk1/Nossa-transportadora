CREATE TABLE categorias(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100)
);

CREATE TABLE ususarios(
id INT PRIMARY KEY IDENTITY(1,1),
FOREIGN KEY(id_categoria) REFERENCES categorias(id),
 nome VARCHAR(100),
 login VARCHAR(100),
 senha VARCHAR(100),

);
CREATE TABLE tarefas(
id INT PRIMARY KEY IDENTITY(1,1),
FOREIGN KEY(id_usuario_responsavel) REFERENCES Ususarios (id),
FOREIGN KEY(id_projeto) REFERENCES projetos(id),
FOREIGN KEY(id_cayegoria) REFERENCES categorias(id),
titulo VARCHAR(200),
descricao TEXT ,
duracao DATETIME2(7)


);
SELECT 
usuario.id AS 'UsusarioId',
usuario.tarefa AS 'UsuarioTarefa',
usuario.id_categoria AS 'UsuarioIdCategoria',
categorias.nome As 'CategoriaNome'
FROM tarefas
INNER JOIN categorias ON (Tarefas.id_categoria = categorias.id)