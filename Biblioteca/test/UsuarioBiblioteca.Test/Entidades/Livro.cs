using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Test.Entidades
{
    public class Livro
    {
        public Guid Id { get; private set; }
        public string Titulo { get;  set; }
        public int QtdPg { get;  set; }
        public string Editora { get;  set; }
        public bool Ativo { get;  set; }
        public string Descricao { get;  set; }
        public Guid IdBiblioteca { get; set; }

    }
}
