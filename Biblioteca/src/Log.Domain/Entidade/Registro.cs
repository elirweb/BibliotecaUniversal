
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

        public Registro(Guid idregistro, DateTime dtregistro,TimeSpan hora,string descricao,string usuario)
        {
            IdRegistro = idregistro;
            DtRegistro = dtregistro;
            Hora = hora;
            Descricao = descricao;
            Usuario = usuario;
        }
         
    }
}
