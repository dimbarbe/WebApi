using System.Data.Entity;

namespace InterfaceIHttpResult.Models
{
    public class PersonDBContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}