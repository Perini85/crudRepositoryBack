using crudComentario.Domain.IRepositories;
using crudComentario.Domain.IServices;
using crudComentario.Models;

namespace crudComentario.Services
{
    public class ComentarioService: IComentarioService
    {
        private readonly IComentarioRepository _ComentarioRepository;

        public ComentarioService(IComentarioRepository ComentarioRepository)
        {
            _ComentarioRepository = ComentarioRepository;
        }

        public async Task CreateComentario(Comentario Comentario)
        {
            await _ComentarioRepository.CreateComentario(Comentario);
        }

        public async Task<List<Comentario>> GetListComentarioByUser(int idComentario)
        {
            return await _ComentarioRepository.GetListComentarioByUser(idComentario);
        }

        public async Task<Comentario> GetComentario(int idComentario)
        {
            return await _ComentarioRepository.GetComentario(idComentario);
        }

        public async Task<Comentario> BuscarComentario( int idComentario)
        {
            return await _ComentarioRepository.BuscarComentario( idComentario);
        }

        public async Task EliminarComentario(int idComentario)
        {
            await _ComentarioRepository.EliminarComentario(idComentario);
        }

        public async Task<List<Comentario>> GetListComentarios()
        {
            return await _ComentarioRepository.GetListComentarios();
        }
    }
}
