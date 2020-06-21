using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SeeManga.Data;
using API_SeeManga.Models.Model;

namespace API_SeeManga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly DataContext _context;

        public GenerosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Generos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenerosModel>>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenerosModel>> GetGenerosModel(int id)
        {
            var generosModel = await _context.Generos.FindAsync(id);

            if (generosModel == null)
            {
                return NotFound();
            }

            return generosModel;
        }

        // PUT: api/Generos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenerosModel(int id, GenerosModel generosModel)
        {
            if (id != generosModel.ID_GENERO)
            {
                return BadRequest();
            }

            _context.Entry(generosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenerosModelExists(id))
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

        // POST: api/Generos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GenerosModel>> PostGenerosModel(GenerosModel generosModel)
        {
            _context.Generos.Add(generosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenerosModel", new { id = generosModel.ID_GENERO }, generosModel);
        }

        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenerosModel>> DeleteGenerosModel(int id)
        {
            var generosModel = await _context.Generos.FindAsync(id);
            if (generosModel == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(generosModel);
            await _context.SaveChangesAsync();

            return generosModel;
        }

        private bool GenerosModelExists(int id)
        {
            return _context.Generos.Any(e => e.ID_GENERO == id);
        }
    }
}
