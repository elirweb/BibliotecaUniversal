using Biblioteca.Core.Domain.Validador.Interfaces;
using Usuario.Application.Handler;
using Usuario.Application.ViewModel;
using Usuario.Data.UnitOfWork;
using Usuario.Domain.Interfaces.Repositorios;

namespace Usuario.Application.AppActions
{
    public class EnderecoApp : Service.ApplicationService, Interfaces.IEndereco
    {
        private readonly IRepositorioEndereco repositorio;

        public EnderecoApp(IRepositorioEndereco end, IUnitOfWork unitOfWork,
            IHandler<Usuario.Domain.Especificacao.UsuarioDevePossuirUnicoCPF> especificaousuario, UsuarioCadastroHandler usuhandler) 
            : base(unitOfWork, especificaousuario, usuhandler)
        {
            repositorio = end;
        }


        public void Adicionar(EnderecoUsuario endereco)
        {
            repositorio.Adicionar(Mapper.VewModelToDomain.Endereco(endereco));
            Commit();
        }
    }
}
