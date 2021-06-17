using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    } 
}