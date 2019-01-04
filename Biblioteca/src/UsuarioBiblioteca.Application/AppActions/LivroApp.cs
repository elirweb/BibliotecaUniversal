
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

        public Dictionary<Guid,string> DropBiblioteca()
        {
           Dictionary<Guid, string> _listb = new Dictionary<Guid, string>();
           List<Domain.Entidades.Bibliotecaria> drop  = (List<Domain.Entidades.Bibliotecaria>)_repositorio.DropBiblioteca();
            drop.ForEach(x=> _listb.Add(x.Id,x.RazaoSocial));
          
            return _listb;
        }

        public IEnumerable<Livro> Obter() {
            List<Application.ViewModel.Livro> _livro = new List<Livro>();
            foreach (var l in _repositorio.ObterLivro())
                _livro.Add(new Livro() { Ativo = l.Ativo, Descricao = l.Descricao, Editora = l.Editora,
                    Titulo = l.Titulo, QtdPg = l.QtdPg });

            return _livro;
        }
        

        public void UpdateLivro(Livro lv)
        {
            throw new NotImplementedException();
        }
    }
}
