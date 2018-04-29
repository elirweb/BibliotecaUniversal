using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Core.Domain.Erros;

namespace Biblioteca.Core.Domain.Validador
{
    public class Validacao<T> : IHandler<T>
    {
        private readonly Log.Application.Interfaces.IRegistro repositorio;

        public Validacao(Log.Application.Interfaces.IRegistro repo)
        {
            repositorio = repo;
        }

        public Erros.Erros erro { get; } = new Erros.Erros();
        public  void Validar() {  }
        public bool EhValido()
        {
            return !erro.TemErro; 
        }

        public void Falhou(bool condicao, ErroDescricao descerro,string _usuario)
        {
            if (condicao) 
                erro.Incluir(descerro);

            //Gravando o log de Erro 
            var _log = new Log.Application.ViewModel.RegistroViewModel() {
                Descricao = descerro.Menssage,
                DtRegistro = DateTime.Now,
                Usuario = _usuario,
                Hora = TimeSpan.Parse(DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes),
                IdRegistro = new Guid()
            };

            repositorio.Adicionar(_log);
        }

        public virtual void  Validar(T model) { }

       
    }
}
