using Domain.Interfaces;
using Infra.Infra;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        public readonly Contexto _contexto;

        public RepositoryGeneric(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Add(T objeto)
        {
            await _contexto.Set<T>().AddAsync(objeto);
            await _contexto.SaveChangesAsync();
        }

        public async Task Delete(T objeto)
        {
            _contexto.Set<T>().Remove(objeto);
            await _contexto.SaveChangesAsync();
        }

        public async Task Update(T objeto)
        {
            _contexto.Set<T>().Update(objeto);
            await _contexto.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            return await _contexto.Set<T>().AsNoTracking().ToListAsync();
        }

        #region IDisposable Support

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                    _contexto.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
