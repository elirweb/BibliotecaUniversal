using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador;

namespace UsuarioBiblioteca.Domain.Validacao
{
    public class LivroAptoParaCadastro : Validacao<LivroAptoParaCadastro>
    {
        Especificacao.LivroDevePossuirUnicoTitulo titulounico;
        Especificacao.Livro_BibliotecaDeveEstarAtiva bibliotecaativa;
        public LivroAptoParaCadastro(Interfaces.IRepositorios.IRepositorioLivro repositorio,  
            Log.Application.Interfaces.IRegistro reporegister)
             : base(reporegister)
        {
            titulounico = new Especificacao.LivroDevePossuirUnicoTitulo(repositorio);
            bibliotecaativa = new Especificacao.Livro_BibliotecaDeveEstarAtiva(repositorio);

        }

        public Entidades.Livro Validar(Entidades.Livro lv)
        {
            lv.ValidacaoResultado = new ValidacaoResultado();


            if (titulounico.InSatisfeito(lv))
            {
                Falhou(titulounico.InSatisfeito(lv), new ErroDescricao("Ops! Titulo do Livro se encontra cadastrado em nosso sistema", new Critico(), "{}"), lv.Titulo);
                lv.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Titulo do Livro se encontra cadastrado em nosso sistema", "Livro"));

            }

            if (!bibliotecaativa.InSatisfeito(lv))
            {

                Falhou(bibliotecaativa.InSatisfeito(lv), new ErroDescricao("Ops! Biblioteca não está ativa em nosso sistema", new Critico(), "{}"), lv.Biblioteca.RazaoSocial);
                lv.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Biblioteca não está ativa em nosso sistema", "Livro"));

            }

            return lv;
        }
    }
}
