using Biblioteca.Data;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    public class ControleController : ControllerBase
    {
        private readonly DataContext _contextControle;
        public ControleController(DataContext context)
        {
            _contextControle = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Controle>>> PegarTodosControles()
        {
            var controle = await _contextControle.Livros.ToListAsync();
            return Ok(controle);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Controle>> BuscarIdControle(int id)
        {
            var controle = await _contextControle.Controles.FindAsync(id);
            if (controle == null)
            {
                return BadRequest("Controle não encontrado");
            }

            return Ok(controle);
        }
        [HttpPost]
        public async Task<ActionResult<List<Controle>>> AdicionarControle(Controle controle)
        {
            _contextControle.Controles.Add(controle);
            await _contextControle.SaveChangesAsync();

            return Ok(await _contextControle.Controles.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Controle>>> AtualizarControle(Controle controle)
        {
            var dbControle = await _contextControle.Controles.FindAsync(controle.Id);
            if (dbControle == null)
            {
                return BadRequest("Usuario não encontrado");
            }

            dbControle.IdUsuario = controle.IdUsuario;
            dbControle.IdLivro = controle.IdLivro;


            await _contextControle.SaveChangesAsync();

            return Ok(await _contextControle.Controles.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Controle>> DeletarControle(int id)
        {
            var controle = await _contextControle.Controles.FindAsync(id);
            if (controle == null)
            {
                return BadRequest("Controle não encontrado");
            }
            _contextControle.Controles.Remove(controle);
            await _contextControle.SaveChangesAsync();

            return Ok(controle);

        }
    }
}
