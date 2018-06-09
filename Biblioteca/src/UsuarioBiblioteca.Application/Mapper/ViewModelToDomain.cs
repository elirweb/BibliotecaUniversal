using System;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entidades.Bibliotecaria Biblioteca(ViewModel.Bibliotecaria bi) {
            if (bi == null)
                throw new Exception();
            else {

                var b = new Domain.Entidades.Bibliotecaria(
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

        public static Domain.Entidades.Administradores Administrador(ViewModel.Administrador adm)
        {
            if (adm == null)
                throw new Exception();
            else
            {

                var a = new Domain.Entidades.Administradores(
              adm.Nome,
              adm.Email,
              adm.Login,
              adm.Senha,
              adm.ConfirmaSenha
                );

                return a;
            }
        }

        public static Domain.Entidades.Endereco Endereco(ViewModel.Endereco endereco)
        {
            if (endereco == null)
                throw new Exception();
            else
            {

                var e = new Domain.Entidades.Endereco(
            endereco.Bairro,
            endereco.Numero,
            endereco.Complemento,
            endereco.Localidade,
            endereco.Uf,
          Convert.ToInt32(endereco.Telefone),
            endereco.tipo,
            endereco.DDD,
            endereco.Id
                );

                return e;
            }
        }

        public static Domain.Entidades.Administradores Authenticar(Administrador adm)
        {
            if (adm == null)
                throw new Exception();
            else
            {
                var a =
                    new Domain.Entidades.Administradores(adm.Login, adm.Senha);
                return a;
            }


          
        }

        public static Domain.Entidades.Livro Livro(ViewModel.Livro lv)
        {
            if (lv == null)
                throw new Exception();
            else
            {

                var l = new Domain.Entidades.Livro(
             lv.Titulo,
             lv.QtdPg,
             lv.Editora,
             lv.Ativo,
             lv.Descricao,
             lv.Id,
             lv.Categoria
                );

                return l;
            }
        }

    }
}
