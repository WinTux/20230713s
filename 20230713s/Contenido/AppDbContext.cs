using _20230713s.Models;
using Microsoft.EntityFrameworkCore;

namespace _20230713s.Contenido
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos => Set<Plato>();//Plato será en nombrede la tabla tras la migración
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
        {
            
        }
    }
}
