using crudComentario.Models;
using Microsoft.EntityFrameworkCore;

namespace crudComentario
{
    public class AplicationDbContext: DbContext
    {

       public DbSet<Comentario> Comentario { get; set; }

        public  AplicationDbContext(DbContextOptions<AplicationDbContext>options): base(options)
        {

        }

    }
}
