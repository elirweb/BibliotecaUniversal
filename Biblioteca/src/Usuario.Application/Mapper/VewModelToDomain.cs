
using System;

namespace Usuario.Application.Mapper
{
    public class VewModelToDomain
    {
        public static Domain.Entidade.Usuario Usuario(ViewModel.Usuario usu) {
            if (usu == null)
                throw new Exception();
            else {
                var usuario = 
                    new Domain.Entidade.Usuario(usu.Id,usu.Nome,usu.Login,usu.Senha,
                    usu.ConfirmaSenha,usu.Email,usu.Cpf);
                return usuario;
            }
        }
    }
}
