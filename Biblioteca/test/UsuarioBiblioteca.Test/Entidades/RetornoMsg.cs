using System;

namespace UsuarioBiblioteca.Test.Entidades
{
    public class RetornoMsg
    {
        public Guid TransacaoId { get; private set; }
        public string Mensagem { get; private set; }

        public RetornoMsg(string mensagem)
        {
            TransacaoId = Guid.NewGuid();
            Mensagem = mensagem;
        }

        // Fazendo um polimorfismo 
        public RetornoMsg(string mensagem, Guid id)
        {
            TransacaoId = id;
            Mensagem = mensagem;
        }
    }
}
