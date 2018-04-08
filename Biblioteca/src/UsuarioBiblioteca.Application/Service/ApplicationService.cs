using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.Service
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            _unitOfWork.Commit();
            return true;
        }
    }
}

