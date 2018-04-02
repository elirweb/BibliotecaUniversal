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
        bool RecuperarSenha(ViewModel.Usuario usuario);

        void Redefirsenha(ViewModel.Usuario usuario);
    }
}
