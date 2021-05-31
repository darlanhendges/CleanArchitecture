using Webmotors.Domain.Entities;
using Webmotors.Domain.Interfaces.Repository;
using Webmotors.Repository.Common;

namespace Webmotors.Repository.Repositories
{
    public class AnuncioWebmotorsRepository : Repository<AnuncioWebmotors>,  IAnuncioWebmotorsRepository
    {
        private readonly Common.DbWebmotorsContext _dbContext;

        public AnuncioWebmotorsRepository(DbWebmotorsContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
