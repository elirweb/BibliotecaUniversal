﻿
using System;

namespace Log.Domain.Entidade
{
    public class Registro
    {
        public DateTime DtRegistro { get; private set; }
        public TimeSpan Hora { get; private set; }
        public string Descricao { get; private set; }
        public string Usuario { get; set; }

        public Registro(Registro reg)
        {
            DtRegistro = reg.DtRegistro;
            Hora = reg.Hora;
            Descricao = reg.Descricao;
            Usuario = reg.Usuario;
        }
         
    }
}
