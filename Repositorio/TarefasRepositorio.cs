using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class TarefasRepositorio
    {public class Tarefa
        {
            public int Inserir(Tarefa tarefas)
            {
                SqlCommand comando = Conexao.Conectar();
                comando.CommandText = @"INSERT INTO tarefas(titulo,id_categoria,descricao,duracao,id_projeto,id_usuario_responsavel)
OUTPUT INSERTED.ID VALUES
(@TITULO,@ID_CATEGORIA,@DESCRICAO.@DURACAO.@ID_PROJETO,@ID_USUARIO_RESPONSAVEL)";
                comando.Parameters.AddWithValue("@TITULO", tarefas.Titulo);
                comando.Parameters.AddWithValue("@ID_CATEGORIA", tarefas.IdCategoria);
                comando.Parameters.AddWithValue("@DESCRICAO", tarefas.Descricao);
                comando.Parameters.AddWithValue("@DURACAO", tarefas.Duracao);
                comando.Parameters.AddWithValue("@ID_PROJETO", tarefas.Projeto;
                comando.Parameters.AddWithValue("@ID_USUARIO_RESPONSAVEL", tarefas.IdUsuarioResponsavel);

                int id = Convert.ToInt32(comando.ExecuteScalar());
                comando.Connection.Close();
                return id;
            }


            public List<Tarefa> ObterTodos()
            {
                SqlCommand comando = Conexao.Conectar();
                comando.CommandText = @"SELECT 
usuario.id AS 'UsusarioId',
usuario.tarefa AS 'UsuarioTarefa',
usuario.id_categoria AS 'UsuarioIdCategoria',
categorias.nome As 'CategoriaNome'
FROM tarefas
INNER JOIN categorias ON (Tarefas.id_categoria = categorias.id)";

                DataTable tabela = new DataTable();
                tabela.Load(comando.ExecuteReader());
                List<Tarefa> veiculos = new List<Tarefa>();
                foreach (DataRow linha in tabela.Rows)
                {
                    Tarefa tarefas = new Tarefa();
                    tarefas.Id = Convert.ToInt32(linha["tarefasId"]);
                    tarefas.Id_categorias = Convert.ToInt32(linha["tarefasIdCategorias"]);
                    tarefas.Id_projetos = Convert.ToInt32(linha["tarefasIdProjetos"]);
                    tarefas.Id_Usuario_responsavel = Convert.ToInt32(linha["tarefasIdUsuarioResponsavel"]);
                    tarefas.titulo = linha["Tarefastitulo"].ToString();
                    tarefas.Categoria = new Categoria();
                    tarefas.Categoria.Nome = linha["CategoriaNome"].ToString();
                    tarefas.Add(Tarefa);
                }
                return tarefas;

            }
        }
    }
}
