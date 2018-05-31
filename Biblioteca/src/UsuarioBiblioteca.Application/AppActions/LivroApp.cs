
using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class LivroApp: Service.ApplicationServiceLv,Interfaces.ILivro
    {
        private readonly IRepositorioLivro repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;

        public LivroApp(IRepositorioLivro lv, IHandler<Domain.Especificacao.LivroDevePossuirUnicoTitulo> titulounico,
            IHandler<Domain.Especificacao.Livro_BibliotecaDeveEstarAtiva> bibliotecaativa, IUnitOfWork _unitOfWork,
            Log.Application.Interfaces.IRegistro log)
            :base(_unitOfWork,titulounico, bibliotecaativa)
        {
            repositorio = lv;
            reg = log;
        }

        public ViewModel.Livro Adicionar(ViewModel.Livro lv)
        {

            if (PossuiConformidade(new Domain.Validacao.LivroAptoParaCadastro(repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Livro(lv))))
            {
                if (lv.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    repositorio.Adicionar(Mapper.ViewModelToDomain.Livro(lv));
                    Commit();
                }
            }

            if (Notificacao != null)
            {
                foreach (var erro in Notificacao)
                {
                    lv.ListaErros.Add(erro);
                }
            }
            return lv;
        }
    }
}
