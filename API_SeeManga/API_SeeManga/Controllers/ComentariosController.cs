using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SeeManga.Data;
using API_SeeManga.Models.Model;
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
        public async Task<ActionResult<IEnumerable<ComentariosModel>>> GetComentarios()
        {
            return await _context.Comentarios.ToListAsync();
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentariosModel>> GetComentariosModel(int id)
        {
            var comentariosModel = await _context.Comentarios.FindAsync(id);

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
        public async Task<IActionResult> PutComentariosModel(int id, ComentariosModel comentariosModel)
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
                if (!ComentariosModelExists(id))
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
        public async Task<ActionResult<ComentariosModel>> PostComentariosModel(ComentariosModel comentariosModel)
        {
            _context.Comentarios.Add(comentariosModel);
            await _context.SaveChangesAsync();

            return comentariosModel;
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComentariosModel>> DeleteComentariosModel(int id)
        {
            var comentariosModel = await _context.Comentarios.FindAsync(id);
            if (comentariosModel == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentariosModel);
            await _context.SaveChangesAsync();

            return comentariosModel;
        }

        private bool ComentariosModelExists(int id)
        {
            return _context.Comentarios.Any(e => e.ID_COMENTARIOS == id);
        }
    }
}
