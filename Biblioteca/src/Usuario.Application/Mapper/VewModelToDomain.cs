
using System;

namespace Usuario.Application.Mapper
{
    public class VewModelToDomain
    {
        public static Domain.Entidade.Usuario Usuario(ViewModel.Usuario usu)
        {
            if (usu == null)
                throw new Exception();
            else
            {
                var usuario =
                    new Domain.Entidade.Usuario(usu.Id, usu.Nome, usu.Login, usu.Senha,
                    usu.ConfirmaSenha, usu.Email, usu.Cpf);
                return usuario;
            }
        }
            public static Domain.Entidade.EnderecoUsuario Endereco(ViewModel.EnderecoUsuario end) {
            if (end == null)
                throw new Exception();
            else {

                var endereco = new Domain.Entidade.EnderecoUsuario(end.Bairro,end.Numero, end.Localidade,end.Uf,end.IdUsuario.Id,end.Cidade);
                return endereco; 
            }
        }
        
    }
}
