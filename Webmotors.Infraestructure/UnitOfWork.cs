using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Webmotors.Infraestructure.Interfaces;
using Webmotors.Repository.Common;

namespace Webmotors.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private bool _disposed = false;

        private DbWebmotorsContext _context;
        public IDbContextTransaction Transaction { get; private set; }


        public UnitOfWork(DbWebmotorsContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = _context.Database.BeginTransaction();
            }

            return Transaction;
        }


        public async Task CommitAsync()
        {
            if (_disposed || Transaction == null)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            await Transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_disposed || Transaction == null)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            await Transaction.RollbackAsync();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _context != null)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
