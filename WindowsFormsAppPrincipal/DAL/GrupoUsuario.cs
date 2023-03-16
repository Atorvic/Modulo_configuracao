using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class GrupoUsuario
    {
        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "insert into GrupoUsuario(NomeGrupo) "+
                                  "values(@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "update GrupoUsuario set NomeGrupo=@NomeGrupo where Id=@Id";                                  
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }
        public void Excluir(GrupoUsuario _grupoUsuario)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "delete from GrupoUsuario where Id=@Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }

        public List<Permissao> BuscarTodos(string _grupoUsuario)
        {
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarPorNome()
        {
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarId()
        {
            throw new NotImplementedException();
        }
    }
}
