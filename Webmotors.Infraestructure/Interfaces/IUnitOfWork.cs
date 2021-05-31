using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;


namespace Webmotors.Infraestructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        IDbContextTransaction BeginTransaction();

        Task RollbackAsync();
    }
}
