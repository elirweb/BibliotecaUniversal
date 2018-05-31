using System;
using System.Data.Common;
namespace Biblioteca.Core.Domain.Util
{
    public class Dispose : IDisposable
    {
        private DbConnection cn = null;
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);

            if (cn != null) {
                cn.Close();
            }

        }
    }
}