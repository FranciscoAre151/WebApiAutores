using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Entidades;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) 
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }
    }
}
