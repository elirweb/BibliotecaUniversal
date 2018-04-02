using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Application.ViewModel;
using Usuario.Domain.Interfaces.Repositorios;

namespace Usuario.Application.AppActions
{
    public class UsuarioApp : Interfaces.IUsuario
    {
        private readonly IRepositorioUsuario repousuario;

        public UsuarioApp(IRepositorioUsuario repo)
        {
            repousuario = repo;
        }

        public ViewModel.Usuario Adicionar(ViewModel.Usuario usuario)
        {
           repousuario.Adicionar(Mapper.VewModelToDomain.Usuario(usuario));
           return usuario;
        }

        public bool RecuperarSenha(ViewModel.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Redefirsenha(ViewModel.Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
