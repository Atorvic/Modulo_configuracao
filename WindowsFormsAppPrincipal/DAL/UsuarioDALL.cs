using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class UsuarioDALL
    {
        /* Codigo para fazer funcionar os codigos sql no C# */
        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

        /* Fazendo os comandos de inserir sql no C# */
        public void Inserir(Usuario _usuario)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "insert into Usuario1(Nome, NomeUsuario,Email,CPF,Ativo,Senha) " +
                    "values(@Nome,@NomeUsuario,@Email,@CPF,@Ativo,@Senha)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Emal", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }

        }
        /*Fazendo as alterações*/
        public void Alterar(Usuario _usuario)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "update Usuario1 set Nome=@Nome, NomeUsuario=@NomeUsuario, Email=@Email, CPF=@CPF, Ativo=@Ativo, Senha=@senha where Id=@id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Emal", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }
        /*Fazendo as exclusão*/
        public void Excluir(Usuario _id)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "delete from Usuario where _Id=@id" +
                    "values(@Nome,@NomeUsuario,@Email,@CPF,@Ativo,@Senha)";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }
        public List<Usuario> BuscarTodos(Usuario _usuario)
        {
            //SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select nome, NomeUsuario,Email,CPF,Ativo,Senha from Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.CPF = Convert.ToInt32(rd["CPF"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuarios.Add(usuario);


                    }
                    return usuarios;
                }
            }
            catch
            {
                throw new Exception("Ocorreu um erro");
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Usuario> BuscarPorNomeUsuario(Usuario _nomeUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select nome, NomeUsuario,Email,CPF,Ativo,Senha from Usuario where NomeUsuario= @NomeUsuario";
                cmd.Parameters.AddWithValue("@NomeUsuario", "%" + _nomeUsuario + "%");
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();


                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.CPF = Convert.ToInt32(rd["CPF"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuarios.Add(usuario);


                    }
                    return usuarios;
                }
            }
            catch
            {
                throw new Exception("Ocorreu um erro");
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorId(Usuario _id)
        {

            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select nome, NomeUsuario,Email,CPF,Ativo,Senha from Usuario where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", _id);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();


                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {

                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.CPF = Convert.ToInt32(rd["CPF"]);
                        usuario.Senha = rd["Senha"].ToString();



                    }
                }
                return usuario;
            }
            catch
            {
                throw new Exception("Ocorreu um erro");
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorCPF(Usuario _CPF)
        {
            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select nome, NomeUsuario,Email,CPF,Ativo,Senha from Usuario where CPF=@CPF";
                cmd.Parameters.AddWithValue("@CPF", _CPF);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();


                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {

                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.CPF = Convert.ToInt32(rd["CPF"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuario;
            }
            catch
            {
                throw new Exception("Ocorreu um erro");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
