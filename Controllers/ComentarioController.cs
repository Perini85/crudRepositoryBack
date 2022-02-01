using crudComentario.Domain.IServices;
using crudComentario.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudComentario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {

        private readonly IComentarioService _comentarioService;

        private readonly AplicationDbContext _context;


        public ComentarioController(IComentarioService ComentarioService, AplicationDbContext context)
        {
            _comentarioService = ComentarioService;
            _context = context;
        }

       

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {

            try
            {


                await _comentarioService.CreateComentario(comentario);

                return Ok(new { message = "Se agrego el Comentario exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListComentarioByUser")]
        [HttpGet]

        public async Task<IActionResult> GetListComentarioByUser(int idComentario)
        {
            try
            {


                var listComentario = await _comentarioService.GetListComentarioByUser(idComentario);
                return Ok(listComentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idComentario}")]
        public async Task<IActionResult> Get(int idComentario)
        {
            try
            {
                var Comentario = await _comentarioService.GetComentario(idComentario);
                return Ok(Comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idComentario}")]

        public async Task<IActionResult> Delete(int idComentario)
        {
            try
            {


                var Comentario = await _comentarioService.BuscarComentario(idComentario);
                if (Comentario == null)
                {
                    return BadRequest(new { message = "No se encontro ningun Comentario" });
                }
                await _comentarioService.EliminarComentario(idComentario);
                return Ok(new { message = "El Comentario fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetListComentarios")]
        [HttpGet]
        public async Task<IActionResult> GetListComentarios()
        {
            try
            {
                var listComentarios = await _comentarioService.GetListComentarios();
                return Ok(listComentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Comentario comentario)
        {
            try
            {
                if(id != comentario.Id)
                {
                    return BadRequest();
                }
                _context.Update(comentario);
              await  _context.SaveChangesAsync();
                return Ok(new { message = "Comentario actualizado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    

    }
}
