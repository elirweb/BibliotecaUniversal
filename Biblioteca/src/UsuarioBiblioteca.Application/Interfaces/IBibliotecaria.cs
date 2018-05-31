using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Application.ViewModel;

namespace UsuarioBiblioteca.Application.Interfaces
{
    public interface IBibliotecaria
    {
        ViewModel.Bibliotecaria Adicionar(ViewModel.Bibliotecaria biblio);
       
    }
}
