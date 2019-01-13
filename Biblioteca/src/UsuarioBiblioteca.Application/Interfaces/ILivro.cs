
using System;
using System.Collections.Generic;
using System.Linq;

namespace UsuarioBiblioteca.Application.Interfaces
{
    public interface ILivro
    {
        void Adicionar(ViewModel.Livro lv);
        void UpdateLivro(ViewModel.Livro lv);

        Dictionary<Guid,string> DropBiblioteca();
        IEnumerable<ViewModel.Livro>ObterLivro();


    }
}
