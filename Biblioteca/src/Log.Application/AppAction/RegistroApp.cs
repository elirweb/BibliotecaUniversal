using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Application.ViewModel;
using Log.Domain.Interfaces.Repositorio;

namespace Log.Application.AppAction
{
    public class RegistroApp : Interfaces.IRegistro
    {
        private readonly IRegistro<Domain.Entidade.Registro> repositorio;

        public RegistroApp(IRegistro<Domain.Entidade.Registro> repo)
        {
            repositorio = repo;
        }
        public void Adicionar(RegistroViewModel reg)
        {
            repositorio.Adicionar(Mapper.VewModelToDomain.Registro(reg));
        }
    }
}
