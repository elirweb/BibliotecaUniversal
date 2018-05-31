
using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador;

namespace UsuarioBiblioteca.Domain.Validacao
{
    public class BibliotecaAptoParaCadastro: Validacao<BibliotecaAptoParaCadastro>
    {
        Especificacao.BibliotecaDevePossuiCNPJUnico cnpj;
        Especificacao.BibliotecaDevePossuirUnicoEmail emailunico;
        Especificacao.BibliotecaDevePossuirUnicoLogin loginunico;
        public BibliotecaAptoParaCadastro(Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio, Log.Application.Interfaces.IRegistro reporegister)
            :base(reporegister)
        {
             cnpj = new Especificacao.BibliotecaDevePossuiCNPJUnico(repositorio);
             emailunico = new Especificacao.BibliotecaDevePossuirUnicoEmail(repositorio);
            loginunico = new Especificacao.BibliotecaDevePossuirUnicoLogin(repositorio);

        }

        public Entidades.Bibliotecaria Validar(Entidades.Bibliotecaria biblioteca) {
            biblioteca.ValidacaoResultado = new ValidacaoResultado();

            if (cnpj.InSatisfeito(biblioteca)) {

                Falhou(cnpj.InSatisfeito(biblioteca), new ErroDescricao("Ops! Cnpj se encontra cadastrado em nosso sistema", new Critico(), "{}"), biblioteca.RazaoSocial);
                biblioteca.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Cnpj se encontra cadastrado em nosso sistema", "Biblioteca"));

            }

            if (biblioteca.Cnpj.Numero.Equals(null)) {
                Falhou(biblioteca.Cnpj.Numero.Equals(null), new ErroDescricao("Ops! Cnpj inválido", new Critico(), "{}"), biblioteca.RazaoSocial);
                biblioteca.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Cnpj inválido", "Biblioteca"));

            }

            if (emailunico.InSatisfeito(biblioteca)) {
                Falhou(biblioteca.Email.Endereco.Equals(null), new ErroDescricao("Ops! Cnpj inválido", new Critico(), "{}"), biblioteca.RazaoSocial);
                biblioteca.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Cnpj inválido", "Biblioteca"));

            }


            if (loginunico.InSatisfeito(biblioteca)) {
                Falhou(cnpj.InSatisfeito(biblioteca), new ErroDescricao("Ops! Login se encontra cadastrado em nosso sistema", new Critico(), "{}"), biblioteca.RazaoSocial);
                biblioteca.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Login se encontra cadastrado em nosso sistema", "Biblioteca"));

            }


            return biblioteca;
        }








            

        
    }
}
