using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador;

namespace UsuarioBiblioteca.Domain.Validacao
{
    public class AdministradorAptoParaCadastro : Validacao<AdministradorAptoParaCadastro>
    {
        Especificacao.AdministradorDevePossuirUnicoLogin loginunico;
        public AdministradorAptoParaCadastro(Interfaces.IRepositorios.IRepositorioAdministrador repositorio, Log.Application.Interfaces.IRegistro reporegister)
            :base(reporegister)
        {
            loginunico = new Especificacao.AdministradorDevePossuirUnicoLogin(repositorio);
        }

        public Entidades.Administradores Validar(Entidades.Administradores ad) {
            ad.ValidacaoResultado = new ValidacaoResultado();

            if (loginunico.InSatisfeito(ad))
            {

                Falhou(loginunico.InSatisfeito(ad), new ErroDescricao("Ops! Login se encontra cadastrado em nosso sistema", new Critico(), "{}"), ad.Nome);
                ad.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Login se encontra cadastrado em nosso sistema", "Administrador"));
            }
            return ad;
        }
    }
}
