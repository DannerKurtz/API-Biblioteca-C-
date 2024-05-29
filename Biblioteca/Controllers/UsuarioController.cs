using Biblioteca.Data;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Class;


namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _contextUsuario;
        public UsuarioController(DataContext context)
        {
            _contextUsuario = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> PegarTodosUsuarios()
        {
            var usuario = await _contextUsuario.Usuarios.ToListAsync();
            return Ok(usuario);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Usuario>> BuscarIdUsuario(int id)
        {
            var usuario = await _contextUsuario.Usuarios.FindAsync(id);
            if(usuario == null)
            {
                return BadRequest("Usuário não encontrado");
            }

            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AdicionarUsuario(Usuario usuario)
        {
            _contextUsuario.Usuarios.Add(usuario);
            await _contextUsuario.SaveChangesAsync();

            return Ok(await _contextUsuario.Usuarios.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> AtualizarUsuario(Usuario usuario)
        {
            var dbUsuario = await _contextUsuario.Usuarios.FindAsync(usuario.Id);
            if(dbUsuario == null)
            {
                return BadRequest("Usuario não encontrado");
            }

            dbUsuario.NomeUsuario = usuario.NomeUsuario;
            dbUsuario.CpfUsuario = usuario.CpfUsuario;
            dbUsuario.Email = usuario.Email;
            dbUsuario.StatusUsuario = usuario.StatusUsuario;

            await _contextUsuario.SaveChangesAsync();

            return Ok(await _contextUsuario.Usuarios.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeletarUsuario(int id)
        {
            var usuario = await _contextUsuario.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            _contextUsuario.Usuarios.Remove(usuario);
            await _contextUsuario.SaveChangesAsync();

            return Ok(usuario);
            
        }
    }
}
