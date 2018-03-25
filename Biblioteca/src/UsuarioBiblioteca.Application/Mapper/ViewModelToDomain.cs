using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Entidades.Bibliotecaria Biblioteca(ViewModel.Bibliotecaria bi) {
            if (bi == null)
                throw new Exception();
            else {

                var b = new Entidades.Bibliotecaria(
                bi.RazaoSocial,
                bi.Cnpj,
                bi.Usuario,
                bi.Senha,
                bi.ConfirmaSenha,
                bi.Email, 
                bi.Situacao,
                bi.Imagem    
                );
               
                return b;
            }
        }
    }
}
