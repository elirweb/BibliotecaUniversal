
using System;

namespace Usuario.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public Contexto.Contexto _contexto;
        public UnitOfWork(Contexto.Contexto contexto_)
        {
            _contexto = contexto_;
        }
        public void Rollback()
        {
            _contexto.Database.BeginTransaction().Rollback();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
