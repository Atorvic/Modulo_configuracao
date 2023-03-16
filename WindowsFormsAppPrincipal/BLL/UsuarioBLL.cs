using DAL;
using Models;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        /*BLL é a camada de negocios*/
        public void Inserir(Usuario _usuario)
        {
            // Chamando o metodo validarDados
            // validarDAdos(_usuario);

            if(_usuario.Senha.Length <= 3)
            {
                throw new Exception("A senha precisa ter mais de 3 caracteres");
            }

            UsuarioDALL usuarioDALL = new UsuarioDALL();
            usuarioDALL.Inserir(_usuario);

            // outra forma de usar o objeto
            // new UsuarioDALL().Inserir(_usuario);
        }
        public void Alterar(Usuario _usuario)
        {
            ValidarDados(_usuario);

            UsuarioDALL usuarioDALL = new UsuarioDALL();
            usuarioDALL.Alterar(_usuario);
        }
        private void ValidarDados(Usuario _usuario)
        {
            /*por meio desse metodo, não precisa ficar repedindo os codigos*/
            if (_usuario.Senha.Length <= 3)
            {
                throw new Exception("A senha precisa ter mais de 3 caracteres");
            }
        }
      
    }
}
