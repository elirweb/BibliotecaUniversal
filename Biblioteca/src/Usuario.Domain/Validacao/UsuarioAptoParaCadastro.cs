using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Validador;

namespace Usuario.Domain.Validacao
{
    public class UsuarioAptoParaCadastro: Validacao<Entidade.Usuario>
    {
        Especificacao.UsuarioDevePossuirUnicoCPF cpfunico;
        Especificacao.UsuarioDevePossuirUnicoLogin loginunico;
        public UsuarioAptoParaCadastro(Interfaces.Repositorios.IRepositorioUsuario repositorio,
             Log.Application.Interfaces.IRegistro reg)
            :base(reg)
        {
            cpfunico = new Especificacao.UsuarioDevePossuirUnicoCPF(repositorio);
            loginunico = new Especificacao.UsuarioDevePossuirUnicoLogin(repositorio);
           
        }

        public Entidade.Usuario Validar(Entidade.Usuario usuario)
        {
            usuario.ValidacaoResultado =
              new ValidacaoResultado();

         
            if (cpfunico.InSatisfeito(usuario))
            {
                Falhou(cpfunico.InSatisfeito(usuario), new ErroDescricao("Ops! Usuário se encontra cadastrado em nosso sistema", new Critico(), "{}"),usuario.Nome);
                usuario.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Usuário se encontra cadastrado em nosso sistema", "Usuário"));
            }

            if(usuario.Cpf.Codigo == null) // cpf inválido
            {
                Falhou(usuario.Cpf.Codigo == null, new ErroDescricao("Ops! CPF inválido", new Critico(), "{}"),usuario.Nome);
                usuario.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! CPF inválido", "Usuário"));
            }

            if (loginunico.InSatisfeito(usuario)) {

                Falhou(loginunico.InSatisfeito(usuario), new ErroDescricao("Ops! Login de Usuário se encontra cadastrado em nosso sistema", new Critico(), "{}"),usuario.Nome);
                usuario.ValidacaoResultado.Erros.Add(new ErroValidacao("Ops! Login de Usuário se encontra cadastrado em nosso sistema", "Usuário"));
            }

            return usuario;
        }
    }
}
