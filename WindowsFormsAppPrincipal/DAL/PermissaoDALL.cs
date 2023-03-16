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
            finally
            {
                cn.Close();
            }

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
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(Permissao _Id)
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "delete from Permissao where Id=@id";
                                  
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _Id);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Infelizmente ocorreu uma erro", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao>  BuscarTodos()
        {
           List<Permissao> lista = new List<Permissao>();
            Permissao permissao = new Permissao();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select Id, Descricao from Permissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using(SqlDataReader rd = cmd.ExecuteReader())
                {
                    permissao = new Permissao();
                    permissao.Id = Convert.ToInt32(rd["ID"]);
                    permissao.Descricao = rd["Descricao"].ToString();
                }
                return lista;
            }
            catch
            {
                throw new Exception("Ocorreu um erro!!");
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarPorNomeDescricao(string _descricao)
        {
           List<Permissao> permissao = new List<Permissao>();
            Permissao permissao = new Permissao();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "select from Id, Descricao from Permissao";
                cmd.Parameters.AddWithValue("@")
            }
        }
        public List<Permissao> BuscarPorId(int _id)
        {
           throw new NotImplementedException();
        }
    }
}
