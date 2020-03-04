using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=-NINJASLAYER-PC\\SQLEXPRESS; initial catalog= InLock_Games_Manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Retorna todos os usuarios cadastrados</returns>
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdUsuario, Email, Senha, Usuarios.IdTipoUsuario FROM Usuarios " +
                                "INNER JOIN TiposUsuario ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr[1].ToString(),

                            Senha = rdr[2].ToString(),

                            IdTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[0]),

                                Titulo = rdr[1].ToString()
                            }
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        /// <summary>
        /// Cadastrar um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Novo Usuario que será cadastrado</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Usuarios (Email, Senha, IdTipoUsuario) VALUES (@Email, @Senha, @ID)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("ID", novoUsuario.IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdUsuario, Email, Senha, Usuarios.IdTipoUsuario FROM Usuarios " +
                                     "INNER JOIN TiposUsuario ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario " +
                                     "WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr[1].ToString(),

                            Senha = rdr[2].ToString(),

                            IdTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[0]),
                                Titulo = rdr[1].ToString()
                            }
                        };
                        return usuario;
                    }
                }
                return null;
            }
        }
    }
}
