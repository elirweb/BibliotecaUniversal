
namespace UsuarioBiblioteca.Validacao
{
    public class BibliotecaAptoParaCadastro: Biblioteca.Core.Domain.Validador.Validacao<BibliotecaAptoParaCadastro>
    {
        
        public BibliotecaAptoParaCadastro(Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio)
        {
            var cnpj = new Especificacao.BibliotecaDevePossuiCNPJUnico(repositorio);
            var emailunico = new Especificacao.BibliotecaDevePossuirUnicoEmail(repositorio);


        }

        
    }
}
