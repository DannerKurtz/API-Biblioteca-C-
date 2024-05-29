using Biblioteca.Data;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly DataContext _contextLivro;

        public LivrosController(DataContext context)
        {
            _contextLivro = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Livro>>> PegarTodosLivros()
        {
            var livro = await _contextLivro.Livros.ToListAsync();
            return Ok(livro);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Livro>> BuscarIdUsuario(int id)
        {
            var livro = await _contextLivro.Livros.FindAsync(id);
            if (livro == null)
            {
                return BadRequest("Livro não encontrado");
            }

            return Ok(livro);
        }
        [HttpPost]
        public async Task<ActionResult<List<Livro>>> AdicionarUsuario(Livro livro)
        {
            _contextLivro.Livros.Add(livro);
            await _contextLivro.SaveChangesAsync();

            return Ok(await _contextLivro.Livros.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Livro>>> AtualizarUsuario(Livro livro)
        {
            var dbLivro = await _contextLivro.Livros.FindAsync(livro.Id);
            if (dbLivro == null)
            {
                return BadRequest("Usuario não encontrado");
            }

            dbLivro.NomeLivro = livro.NomeLivro;
            dbLivro.Genero = livro.Genero;
            dbLivro.StatusLivro = livro.StatusLivro;

            await _contextLivro.SaveChangesAsync();

            return Ok(await _contextLivro.Livros.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> DeletarUsuario(int id)
        {
            var livro = await _contextLivro.Livros.FindAsync(id);
            if (livro == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            _contextLivro.Livros.Remove(livro);
            await _contextLivro.SaveChangesAsync();

            return Ok(livro);

        }
    }
}
