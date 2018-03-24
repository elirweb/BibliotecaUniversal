using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Data.Config
{
    public class Banco
    {
        public Banco(string conexao)
        {
            Conexao = conexao;
        }

        public string Conexao { get; set; }
    }
}