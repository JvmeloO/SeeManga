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
    public class Manga_GenerosController : ControllerBase
    {
        private readonly DataContext _context;

        public Manga_GenerosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Manga_Generos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manga_GenerosModel>>> GetManga_Generos()
        {
            return await _context.Manga_Generos.ToListAsync();
        }

        // GET: api/Manga_Generos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manga_GenerosModel>> GetManga_GenerosModel(int id)
        {
            var manga_GenerosModel = await _context.Manga_Generos.FindAsync(id);

            if (manga_GenerosModel == null)
            {
                return NotFound();
            }

            return manga_GenerosModel;
        }

        // PUT: api/Manga_Generos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga_GenerosModel(int id, Manga_GenerosModel manga_GenerosModel)
        {
            if (id != manga_GenerosModel.ID_GENERO)
            {
                return BadRequest();
            }

            _context.Entry(manga_GenerosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Manga_GenerosModelExists(id))
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

        // POST: api/Manga_Generos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Manga_GenerosModel>> PostManga_GenerosModel(Manga_GenerosModel manga_GenerosModel)
        {
            _context.Manga_Generos.Add(manga_GenerosModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Manga_GenerosModelExists(manga_GenerosModel.ID_GENERO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetManga_GenerosModel", new { id = manga_GenerosModel.ID_GENERO }, manga_GenerosModel);
        }

        // DELETE: api/Manga_Generos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manga_GenerosModel>> DeleteManga_GenerosModel(int id)
        {
            var manga_GenerosModel = await _context.Manga_Generos.FindAsync(id);
            if (manga_GenerosModel == null)
            {
                return NotFound();
            }

            _context.Manga_Generos.Remove(manga_GenerosModel);
            await _context.SaveChangesAsync();

            return manga_GenerosModel;
        }

        private bool Manga_GenerosModelExists(int id)
        {
            return _context.Manga_Generos.Any(e => e.ID_GENERO == id);
        }
    }
}
