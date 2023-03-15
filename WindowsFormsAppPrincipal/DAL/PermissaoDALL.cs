using Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class PermissaoDALL
    {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
        public void Inserir(Permissao _permissao)
        {
           
                try
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "insert into Permissao(Descricao) " +
                                      "values(@Descricao)";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Descricao", _permissao);
  
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Infelizmente ocorreu uma erro", ex);
                }

        }
        public List<Permissao> BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarPorNomeDescricao(string _descricao)
        {
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }
        public void Alterar(Permissao _permissao)
        {
                try
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "update Permissao set Descricao=@Descricao where Id=@Id";
                    cmd.Parameters.AddWithValue("@Descricao", _permissao);
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
        public void Excluir(Permissao _id)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "delete from Permissao where Id=@id";
                                  
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
        }
    }
}
