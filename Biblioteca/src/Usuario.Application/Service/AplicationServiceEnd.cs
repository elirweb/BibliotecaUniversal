using Usuario.Application.Handler;
using Usuario.Data.UnitOfWork;

namespace Usuario.Application.Service
{
    public class AplicationServiceEnd
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioCadastroHandler usuariohandler;

        public AplicationServiceEnd(IUnitOfWork _unit, UsuarioCadastroHandler email)
        {
            _unitOfWork = _unit;
            usuariohandler = email;
        }

        public bool Commit()
        {
            _unitOfWork.Commit();
            return true;
        }

    }
}
