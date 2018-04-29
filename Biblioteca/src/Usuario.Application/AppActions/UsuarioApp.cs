using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using Usuario.Data.UnitOfWork;
using Usuario.Domain.Interfaces.Repositorios;
using Usuario.Domain.Entidade;
using System.Collections.Generic;
using Usuario.Application.Handler;
using Usuario.Application.ViewModel;

namespace Usuario.Application.AppActions
{
    public class UsuarioApp : Service.ApplicationService ,Interfaces.IUsuario
    {
        private readonly IRepositorioUsuario repousuario;
        private readonly Log.Application.Interfaces.IRegistro reg; 
        public UsuarioApp(IRepositorioUsuario repo, 
            IUnitOfWork unitOfWork, 
            IHandler<Domain.Especificacao.UsuarioDevePossuirUnicoCPF> especificaousuario, UsuarioCadastroHandler usuhandler,
            Log.Application.Interfaces.IRegistro regis) 
            :base(unitOfWork, especificaousuario, usuhandler)
        {
            repousuario = repo;
            reg = regis;
        }
        
        public ViewModel.Usuario Adicionar(ViewModel.Usuario usuario)
        {
            
            if (PossuiConformidade(new Domain.Validacao.UsuarioAptoParaCadastro(repousuario, reg)
                .Validar(Mapper.VewModelToDomain.Usuario(usuario)))) {
                if (usuario.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    repousuario.Adicionar(Mapper.VewModelToDomain.Usuario(usuario));
                    Commit();
                }
            }

            if (Notificacao != null) {
                foreach (var erro in Notificacao)
                {
                    usuario.ListaErros.Add(erro);
                }
            }
            return usuario;
        }

        public bool Authenticar(ViewModel.Usuario usuario)
        {
            return repousuario.Authenticar(Mapper.VewModelToDomain.Authentica(usuario));
        }

        public bool RecuperarSenha(string email)
        {
            if (repousuario.RecuperarSenha(email))
            {
                usuariohandler.RecuperSenha("elirweb@gmail.com", "elir", "Recuperação de Senha -Portal Biblioteca Universal", "<html><head><title></title></head><body>Olá acesse <a href=\"http://localhost:4372/Login/RedefinirSenha\">aqui</a> para redefir sua senha de acesso.</body></html>");
                return true;
            }
            else
                return false;

        }

        public bool Redefirsenha(string email, string senha)
        {
            var retorno = false;
            if (repousuario.AlteracaoSenha(email, senha))
                retorno = true;
            
            return retorno;

        }
    }
}
