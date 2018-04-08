using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using Usuario.Data.UnitOfWork;
using Usuario.Domain.Interfaces.Repositorios;
using Usuario.Domain.Entidade;
using System.Collections.Generic;
using Usuario.Application.Handler;

namespace Usuario.Application.AppActions
{
    public class UsuarioApp : Service.ApplicationService ,Interfaces.IUsuario
    {
        private readonly IRepositorioUsuario repousuario;

        public UsuarioApp(IRepositorioUsuario repo, 
            IUnitOfWork unitOfWork, 
            IHandler<Domain.Especificacao.UsuarioDevePossuirUnicoCPF> especificaousuario, UsuarioCadastroHandler usuhandler) 
            :base(unitOfWork, especificaousuario, usuhandler)
        {
            repousuario = repo;
        }

        public ViewModel.Usuario Adicionar(ViewModel.Usuario usuario)
        {
            if (PossuiConformidade(new Domain.Validacao.UsuarioAptoParaCadastro(repousuario)
                .Validar(Mapper.VewModelToDomain.Usuario(usuario)))) {
                    repousuario.Adicionar(Mapper.VewModelToDomain.Usuario(usuario));
                    Commit();
            }

            if (Notificacao != null) {
                foreach (var erro in Notificacao)
                {
                    usuario.ListaErros.Add(erro);
                }
            }
            return usuario;
        }

       

        public bool RecuperarSenha(ViewModel.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Redefirsenha(ViewModel.Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
