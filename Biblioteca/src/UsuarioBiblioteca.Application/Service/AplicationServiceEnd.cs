using UsuarioBiblioteca.Application.Handler;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.Service
{
    public class AplicationServiceEnd
    {
        private readonly IUnitOfWork _unitOfWork;
        public BibliotecaCadastroHandler emailuser;

        public AplicationServiceEnd(IUnitOfWork _unit, BibliotecaCadastroHandler email)
        {
            _unitOfWork = _unit;
            emailuser = email;
        }

        public bool Commit()
        {
            _unitOfWork.Commit();
            return true;
        }

    }
}
