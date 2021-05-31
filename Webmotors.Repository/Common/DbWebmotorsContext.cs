using Microsoft.EntityFrameworkCore;
using Webmotors.Domain.Entities;

namespace Webmotors.Repository.Common
{
    public class DbWebmotorsContext : DbContext
    {
        public DbWebmotorsContext(DbContextOptions<DbWebmotorsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuncioWebmotors>().ToTable("tb_AnuncioWebmotors");
        }

        public DbSet<AnuncioWebmotors> AnuncioWebmotors { get; set; }


    }
}
