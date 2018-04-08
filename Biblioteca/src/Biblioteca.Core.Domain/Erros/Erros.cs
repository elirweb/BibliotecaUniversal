using Biblioteca.Core.Domain.Erros;
using Biblioteca.Core.Domain.Notificacao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Core.Domain.Erros
{
    public class Erros: ListaNotificacao
    {
        public IList<ErroDescricao> Errors => Lista.Cast<ErroDescricao>().Where(x => x.Nivel is Critico).ToList();
        public bool TemErro => Lista.Cast<ErroDescricao>().Any(x => x.Nivel is Critico);

    }
}
