using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Data.UnitOfWork
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
