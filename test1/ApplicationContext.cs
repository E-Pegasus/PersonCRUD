using Microsoft.EntityFrameworkCore;
using System.Reflection;
using test1.Entities;

namespace test1
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>().HasKey(K => K.Id);

            
        }

        public DbSet<Person> people { get; set; }
    }
}
