using System;

namespace Exemplares.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
