using crudComentario.Domain.IRepositories;
using crudComentario.Models;
using Microsoft.EntityFrameworkCore;

namespace crudComentario.Persistence
{
    public class ComentarioRepository: IComentarioRepository
    {

        private readonly AplicationDbContext _context;
        public ComentarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateComentario(Comentario comentario)
        {
            comentario.FechaCreacion = DateTime.Now;
            _context.Add(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comentario>> GetListComentarioByUser(int idComentario)
        {
            var listComentario = await _context.Comentario.Where(x =>  x.Id == idComentario).ToListAsync();
            return listComentario;
        }

        public async Task<Comentario> GetComentario(int idComentario)
        {
            var Comentario = await _context.Comentario.Where(x => x.Id == idComentario
                                                                ).FirstOrDefaultAsync();


            return Comentario;
        }

        public async Task<Comentario> BuscarComentario(int idComentario)
        {
            var Comentario = await _context.Comentario.Where(x => x.Id == idComentario).FirstOrDefaultAsync();
            return Comentario;
        }

        public async Task EliminarComentario(int idComentario)
        {
            var comentario = await _context.Comentario.FindAsync(idComentario);



            _context.Comentario.Remove(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comentario>> GetListComentarios()
        {
            var listComentarios = await _context.Comentario.ToListAsync();


            return listComentarios;
        }
    }
}



    

