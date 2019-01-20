using System;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entidades.Bibliotecaria Biblioteca(ViewModel.Bibliotecaria bi)
        {
            if (bi == null)
                throw new Exception();

            return new Domain.Entidades.Bibliotecaria(
            bi.RazaoSocial,
            bi.Cnpj,
            bi.Usuario,
            bi.Senha,
            bi.ConfirmaSenha,
            bi.Email,
            bi.Situacao,
            bi.Imagem,
            bi.Id
            );


        }

        public static Domain.Entidades.Administradores Administrador(ViewModel.Administrador adm)
        {
            if (adm == null)
                throw new Exception();


            return new Domain.Entidades.Administradores(
                adm.Id = Guid.NewGuid(),
          adm.Nome,
          adm.Email,
          adm.Login,
          adm.Senha,
          adm.ConfirmaSenha
            );



        }

        public static Domain.Entidades.Endereco Endereco(ViewModel.Endereco endereco)
        {
            if (endereco == null)
                throw new Exception();


            return new Domain.Entidades.Endereco(
         endereco.Bairro,
         endereco.Numero,
         endereco.Complemento,
         endereco.Localidade,
         endereco.Uf,
       Convert.ToInt32(endereco.Telefone),
         endereco.tipo,
         endereco.DDD,
         endereco.Bibliotecaria.Id
             );


        }

        public static Domain.Entidades.Administradores Authenticar(Administrador adm)
        {
            if (adm == null)
                throw new Exception();

            return
          new Administradores(adm.Login, adm.Senha);

        }

    
          
      

        public static Domain.Entidades.Livro Livro(ViewModel.Livro lv)
        {
            if (lv == null)
                throw new ArgumentException("livro não passado");
         
               return new Domain.Entidades.Livro(
                lv.Id,
             lv.Titulo,
             lv.QtdPg,
             lv.Editora,
             lv.Ativo,
             lv.Descricao,
             lv.IdBiblioteca,
             4
           
                );

               
          
        }

    }
}
