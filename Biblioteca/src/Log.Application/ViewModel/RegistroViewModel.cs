
using System;

namespace Log.Application.ViewModel
{
    public class RegistroViewModel
    {
        public Guid IdRegistro { get; set; }
        public DateTime DtRegistro { get; private set; }
        public TimeSpan Hora { get; private set; }
        public string Descricao { get; private set; }
        public string Usuario { get; private set; }

    }
}
