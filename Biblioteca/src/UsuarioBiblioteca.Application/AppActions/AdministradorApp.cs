
using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class AdministradorApp: Service.ApplicationServiceAdm, Interfaces.IAdministrador
    {
        private readonly Domain.Interfaces.IRepositorios.IRepositorioAdministrador repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;
        public AdministradorApp(Domain.Interfaces.IRepositorios.IRepositorioAdministrador adm,
              IUnitOfWork unitOfWork, Log.Application.Interfaces.IRegistro regis, IHandler<Domain.Especificacao.AdministradorDevePossuirUnicoLogin> loginunico)
            :base (unitOfWork, loginunico)
        {
            repositorio = adm;

            reg = regis;
        }

        public ViewModel.Administrador Adicionar(ViewModel.Administrador adm)
        {

            if (PossuiConformidade(new Domain.Validacao.AdministradorAptoParaCadastro(repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Administrador(adm))))
            {
                if (adm.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    repositorio.Adicionar(Mapper.ViewModelToDomain.Administrador(adm));
                    Commit();
                    Notificacao = null;
                }
            }

            if (Notificacao != null)
            {
                foreach (var erro in Notificacao)
                {
                    adm.ListaErros.Add(erro);
                }
            }
            return adm;
        }

        public bool Authenticar(Administrador adm)
        {
            return repositorio.Authenticar(Mapper.ViewModelToDomain.Authenticar(adm));
        }

       
    }
}
