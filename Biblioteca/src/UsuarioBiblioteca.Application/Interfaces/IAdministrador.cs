﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.Interfaces
{
    public interface IAdministrador
    {
        ViewModel.Administrador Adicionar(ViewModel.Administrador adm);
    }
}
