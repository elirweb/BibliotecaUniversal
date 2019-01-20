
using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using System.Collections.Generic;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class LivroApp: Service.ApplicationServiceLv,Interfaces.ILivro
    {
        private readonly IRepositorioLivro _repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;
        public LivroApp(IRepositorioLivro lv, IHandler<Domain.Especificacao.LivroDevePossuirUnicoTitulo> titulounico,
            IHandler<Domain.Especificacao.Livro_BibliotecaDeveEstarAtiva> bibliotecaativa, IUnitOfWork _unitOfWork,
            Log.Application.Interfaces.IRegistro log)
            :base(_unitOfWork,titulounico, bibliotecaativa)
        {
            _repositorio = lv;
            reg = log;
        }

        

        public void Adicionar(ViewModel.Livro lv)
        {

            if (PossuiConformidade(new Domain.Validacao.LivroAptoParaCadastro(_repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Livro(lv))))
            {
                if (lv.Id != Guid.Parse(Biblioteca.Core.Domain.Util.UtilObject.guidobject))
                {
                    _repositorio.Adicionar(Mapper.ViewModelToDomain.Livro(lv));
                    Commit();
                    Notificacao = null;
                    
                }
            }

            if (Notificacao != null)
            {
                foreach (var erro in Notificacao)
                    lv.ListaErros.Add(erro);
            
               
            }
           
        }

        public List<Livro> DeleteLivro(Guid id)
        {
            List<Application.ViewModel.Livro> _livro = new List<Livro>();
            _repositorio.DeleteLivro(id).ForEach(item => _livro.Add(new Livro()
            {
                Ativo = item.Ativo,
                Descricao = item.Descricao,
                Editora = item.Editora,
                Titulo = item.Titulo,
                QtdPg = item.QtdPg
            }));

            return _livro;
        }

        public Dictionary<Guid,string> DropBiblioteca()
        {
           Dictionary<Guid, string> _listb = new Dictionary<Guid, string>();
           List<Domain.Entidades.Bibliotecaria> drop  = (List<Domain.Entidades.Bibliotecaria>)_repositorio.DropBiblioteca();
            drop.ForEach(x=> _listb.Add(x.Id,x.RazaoSocial));
          
            return _listb;
        }

        public IEnumerable<Livro> ObterLivro() {
            List<Application.ViewModel.Livro> _livro = new List<Livro>();
            _repositorio.ObterLivro().ForEach(item => _livro.Add(new Livro()
            {
                Ativo = item.Ativo,
                Descricao = item.Descricao,
                Editora = item.Editora,
                Titulo = item.Titulo,
                QtdPg = item.QtdPg
            }));

            return _livro;
        }

        public List<Livro> ObterLivroPorId(Guid id)
        {
            List<Application.ViewModel.Livro> _livro = new List<Livro>();
            _repositorio.ObterLivroPorId(id).ForEach(item => _livro.Add(new Livro()
            {
                Ativo = item.Ativo,
                Descricao = item.Descricao,
                Editora = item.Editora,
                Titulo = item.Titulo,
                QtdPg = item.QtdPg
            }));

            return _livro;
        }

        public void UpdateLivro(Livro lv)
        {
            _repositorio.Atualizar(Mapper.ViewModelToDomain.Livro(lv));
        }
    }
}
