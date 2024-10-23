using BaseProjectTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectTest.Models.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
            
        }

        public DbSet<Livros> Livros { get; set;}

    }
}
