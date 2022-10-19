using CopaDoMundo.Domain.Interfaces.Auxiliares;
using Microsoft.EntityFrameworkCore;

namespace CopaDoMundo.Infra.Auxiliares
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _context;
        public UnitOfWork(T context)
            => _context = context;

        public async Task CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
