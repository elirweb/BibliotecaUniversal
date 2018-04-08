﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Interfaces.IRepositorios
{
    public interface IRepositorioLivro
    {
        void Adicionar(Entidades.Livro lv);

        bool EhLivroCadastrado(Entidades.Livro lv);
    }
}