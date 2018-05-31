using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Interfaces.IRepositorios
{
    public interface IRepositorioBibliotecaria
    {
        void Adicionar(Entidades.Bibliotecaria bibliotecaria);
        bool CNPJUnico(Entidades.Bibliotecaria bibliotecaria);
        bool EmailUnico(Entidades.Bibliotecaria bibliotecaria);
        bool LoginUnico(Bibliotecaria model);
        
    }
}
