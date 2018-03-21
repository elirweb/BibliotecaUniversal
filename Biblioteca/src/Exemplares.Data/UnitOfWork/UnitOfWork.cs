using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplares.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public Contexto.Contexto _context;
        public UnitOfWork(Contexto.Contexto context_)
        {
            _context = context_;
        }
        public void Commit()
        {
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            _context.Database.BeginTransaction().Rollback();

            throw new NotImplementedException();
        }
    }
}
