﻿using SimpleInjector;

namespace Biblioteca.Core.Infra.IoC
{
    public class Bootstrap
    {
        public static Container container { get; set; }

        public static void Register(Container container)
        {
            
            //app
            container.Register<UsuarioBiblioteca.Application.Interfaces.IBibliotecaria, UsuarioBiblioteca.Application.AppActions.BibliotecariaApp>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Application.Interfaces.IEndereco, UsuarioBiblioteca.Application.AppActions.EnderecoApp>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Application.Interfaces.IAdministrador, UsuarioBiblioteca.Application.AppActions.AdministradorApp>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Application.Interfaces.ILivro, UsuarioBiblioteca.Application.AppActions.LivroApp>(Lifestyle.Singleton);
            container.Register<Usuario.Application.Interfaces.IUsuario, Usuario.Application.AppActions.UsuarioApp>(Lifestyle.Singleton);
            container.Register<Usuario.Application.Interfaces.IEndereco, Usuario.Application.AppActions.EnderecoApp>(Lifestyle.Singleton);
            container.Register <Emprestimo.Application.Interfaces.IPedido, Emprestimo.Application.AppAction.Pedido>(Lifestyle.Singleton);
            //container.Register<Log.Application.Interfaces.IRegistro, Log.Application.AppAction.RegistroApp>(Lifestyle.Singleton);

            //data
            container.Register<UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioBibliotecaria, UsuarioBiblioteca.Data.Repositorios.RepositorioBibliotecaria>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioEndereco, UsuarioBiblioteca.Data.Repositorios.RepositorioEndereco>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioAdministrador, UsuarioBiblioteca.Data.Repositorios.RepositorioAdministrador>(Lifestyle.Singleton);
            container.Register<UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioLivro, UsuarioBiblioteca.Data.Repositorios.RepositorioLivro>(Lifestyle.Singleton);
            container.Register<Usuario.Domain.Interfaces.Repositorios.IRepositorioUsuario, Usuario.Data.Repositorio.RepositorioUsuario>(Lifestyle.Singleton);
            container.Register<Usuario.Domain.Interfaces.Repositorios.IRepositorioEndereco, Usuario.Data.Repositorio.RepositorioEndereco>(Lifestyle.Singleton);
            container.Register<Emprestimo.Domain.Interfaces.Repositorio.IRepositorioPedido, Emprestimo.Data.Repositorio.RepositorioPedido>(Lifestyle.Singleton);
            //container.Register<Log.Domain.Interfaces.Repositorio.IRegistro<Log.Domain.Entidade.Registro>, Log.Data.Repositorio.RepositorioRegistro>(Lifestyle.Singleton);
            

            //contexto
            container.Register<UsuarioBiblioteca.Data.Contexto.Contexto>(Lifestyle.Singleton);
           container.Register<Usuario.Data.Contexto.Contexto>(Lifestyle.Singleton);
            container.Register<Emprestimo.Data.Contexto.Contexto>(Lifestyle.Singleton);

            //Unit Of Work
            container.Register<UsuarioBiblioteca.Data.UnitOfWork.IUnitOfWork, UsuarioBiblioteca.Data.UnitOfWork.UnitOfWork>(Lifestyle.Singleton);
            container.Register<Usuario.Data.UnitOfWork.IUnitOfWork, Usuario.Data.UnitOfWork.UnitOfWork>(Lifestyle.Singleton);
            container.Register<Emprestimo.Data.UnitOfWork.IUnitOfWork, Emprestimo.Data.UnitOfWork.UnitOfWork>(Lifestyle.Singleton);

            //handler
            container.Register<Domain.Validador.Interfaces.IHandler<Usuario.Domain.Especificacao.UsuarioDevePossuirUnicoCPF>, Biblioteca.Core.Domain.Validador.Validacao<Usuario.Domain.Especificacao.UsuarioDevePossuirUnicoCPF>>(Lifestyle.Singleton);
            container.Register<Email.Interfaces.IEnvioEmail, Email.EnvioEmail>(Lifestyle.Singleton);
        }
    }
}