
using System;

namespace Log.Application.ViewModel
{
    public class RegistroViewModel
    {
        public Guid IdRegistro { get; set; }
        public DateTime DtRegistro { get;  set; }
        public TimeSpan Hora { get;  set; }
        public string Descricao { get;  set; }
        public string Usuario { get;  set; }

    }
}
