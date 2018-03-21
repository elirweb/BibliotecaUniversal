
using System;

namespace Log.Domain.Entidade
{
    public class Registro
    {
        public Guid IdRegistro { get; set; }
        public DateTime DtRegistro { get; private set; }
        public TimeSpan Hora { get; private set; }
        public string Descricao { get; private set; }
        public string Usuario { get; private set; }

        public Registro(Registro reg)
        {
            IdRegistro = new Guid();
            DtRegistro = reg.DtRegistro;
            Hora = reg.Hora;
            Descricao = reg.Descricao;
            Usuario = reg.Usuario;
        }
         
    }
}
