using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Entidades;

namespace WebApplication1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Autor> Autores { get; set; }   
    }
}
