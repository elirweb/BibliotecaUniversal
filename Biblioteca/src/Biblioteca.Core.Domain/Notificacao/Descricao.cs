using Biblioteca.Core.Domain.Interfaces.Notificacao;

namespace Biblioteca.Core.Domain.Notificacao
{
    public class Descricao : IDescricao
    {
        public string Menssage { get; }

        public Descricao(string message, params string[] args)
        {
            Menssage = message;

            for (var i = 0; i < args.Length; i++)
            {
                Menssage = Menssage.Replace("{" + i + "}", args[i]);
            }
        }

        public override string ToString()
        {
            return Menssage;
        }
    }
}
