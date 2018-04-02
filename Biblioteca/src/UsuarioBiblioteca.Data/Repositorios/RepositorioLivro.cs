using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioLivro : Interfaces.IRepositorios.IRepositorioLivro
    {
        private Contexto.Contexto contexto;
        public RepositorioLivro(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Livro lv)
        {
            throw new NotImplementedException();
        }

        public bool EhLivroCadastrado(Livro lv)
        {
            throw new NotImplementedException();
        }
    }
}
