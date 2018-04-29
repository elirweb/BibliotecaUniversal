using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Application.Mapper
{
    public static class VewModelToDomain
    {
        public static Domain.Entidade.Registro Registro(ViewModel.RegistroViewModel reg) {
            if (reg == null)
                throw new Exception();
            else {
                var registro = new Domain.Entidade.Registro(reg.IdRegistro, reg.DtRegistro, 
                    reg.Hora, reg.Descricao,
                    reg.Usuario);
                return registro;
            }
        }
    }
}
