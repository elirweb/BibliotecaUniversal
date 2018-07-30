using System;

namespace Biblioteca.Core.Domain.Util
{
    public class DisposeElement : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
     
                disposedValue = true;
            }
        }

      
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}