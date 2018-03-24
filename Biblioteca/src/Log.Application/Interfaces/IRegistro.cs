using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Application.Interfaces
{
    public interface IRegistro
    {
        void Adicionar(ViewModel.RegistroViewModel reg);
    }
}
