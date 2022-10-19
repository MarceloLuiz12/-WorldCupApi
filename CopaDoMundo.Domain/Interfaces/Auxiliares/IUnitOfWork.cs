using Microsoft.EntityFrameworkCore;

namespace CopaDoMundo.Domain.Interfaces.Auxiliares
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        Task CommitAsync();
    }
}
