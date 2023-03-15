namespace DAL
{
    public class Conexao
    {
        public static string StringDeConexao /*Criando string de conexão com o banco de dados*/
        {
            get { return @"user ID=SA; initial Catalog=Configuacao; Data Source=.\SQLEXPRESS2019; Password=senailab02"; }
        }
    }
}
