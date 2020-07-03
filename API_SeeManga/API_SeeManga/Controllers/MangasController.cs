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
    public class MangasController : ControllerBase
    {
        private readonly DataContext _context;

        public MangasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MangasModel>>> GetManga()
        {
            return await _context.Mangas.ToListAsync();
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MangasModel>> GetManga(int id)
        {
            var mangaModel = await _context.Mangas.FindAsync(id);

            if (mangaModel == null)
            {
                return NotFound();
            }

            return mangaModel;
        }

        // PUT: api/Mangas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, MangasModel mangaModel)
        {
            if (id != mangaModel.ID_MANGA)
            {
                return BadRequest();
            }

            _context.Entry(mangaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangaExists(id))
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

        // POST: api/Mangas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MangasModel>> PostManga(MangasModel mangaModel)
        {
            _context.Mangas.Add(mangaModel);
            await _context.SaveChangesAsync();

            return mangaModel;
        }

        // DELETE: api/Mangas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MangasModel>> DeleteManga(int id)
        {
            var mangaModel = await _context.Mangas.FindAsync(id);
            if (mangaModel == null)
            {
                return NotFound();
            }

            _context.Mangas.Remove(mangaModel);
            await _context.SaveChangesAsync();

            return mangaModel;
        }

        private bool MangaExists(int id)
        {
            return _context.Mangas.Any(e => e.ID_MANGA == id);
        }
    }
}
