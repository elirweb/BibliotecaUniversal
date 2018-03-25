using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Interfaces.IRepositorios
{
    public interface IRepositorioBibliotecaria
    {
        void Adicionar(Entidades.Bibliotecaria bibliotecaria);
        bool CNPJUnico(Entidades.Bibliotecaria bibliotecaria);
        bool EmailUnico(Entidades.Bibliotecaria bibliotecaria);
    }
}
