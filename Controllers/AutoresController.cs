using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Entidades;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IServicio servicio;

        public AutoresController(ApplicationDbContext context, IServicio servicio)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            servicio.RealizarTarea();
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Autor>> PrimerAutor()
        { 
            return await context.Autores.FirstOrDefaultAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) 
        {
            var existeAutorConMismoNombre = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);

            if (existeAutorConMismoNombre)
            {
                return BadRequest($"Ya existe autor con el nombre {autor.Nombre}");
            }

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(autor.Id != id) 
            {
                return BadRequest("El id del autpr no coincide con el de la URL");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
