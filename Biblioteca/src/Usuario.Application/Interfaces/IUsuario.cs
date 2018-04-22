using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.Interfaces
{
    public interface IUsuario
    {
        ViewModel.Usuario Adicionar(ViewModel.Usuario usuario);
        bool RecuperarSenha(string email);

        bool Redefirsenha(string email, string senha);
        bool Authenticar(ViewModel.Usuario usuario);
        
    }
}
