using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SeeManga.Data;
using API_SeeManga.DTO;
using Microsoft.AspNetCore.Authorization;

namespace API_SeeManga.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly DataContext _context;

        public ComentariosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOComentarios>>> GetComentarios()
        {
            return await _context.COMENTARIOS.ToListAsync();
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOComentarios>> GetComentarios(int id)
        {
            var comentariosModel = await _context.COMENTARIOS.FindAsync(id);

            if (comentariosModel == null)
            {
                return NotFound();
            }

            return comentariosModel;
        }

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentarios(int id, DTOComentarios comentariosModel)
        {
            if (id != comentariosModel.ID_COMENTARIOS)
            {
                return BadRequest();
            }

            _context.Entry(comentariosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comentarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTOComentarios>> PostComentarios(DTOComentarios comentariosModel)
        {
            _context.COMENTARIOS.Add(comentariosModel);
            await _context.SaveChangesAsync();

            return comentariosModel;
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOComentarios>> DeleteComentarios(int id)
        {
            var comentariosModel = await _context.COMENTARIOS.FindAsync(id);
            if (comentariosModel == null)
            {
                return NotFound();
            }

            _context.COMENTARIOS.Remove(comentariosModel);
            await _context.SaveChangesAsync();

            return comentariosModel;
        }

        private bool ComentariosExists(int id)
        {
            return _context.COMENTARIOS.Any(e => e.ID_COMENTARIOS == id);
        }
    }
}
