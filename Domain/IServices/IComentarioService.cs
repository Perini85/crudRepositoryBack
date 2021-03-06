using crudComentario.Models;

namespace crudComentario.Domain.IServices
{
    public interface IComentarioService
    {

        Task CreateComentario(Comentario comentario);
        Task<List<Comentario>> GetListComentarioByUser(int idComentario);
        Task<Comentario> GetComentario(int idComentario);
        Task<Comentario> BuscarComentario(int idComentario);
        Task EliminarComentario(int idComentario);
        Task<List<Comentario>> GetListComentarios();

    }
}
