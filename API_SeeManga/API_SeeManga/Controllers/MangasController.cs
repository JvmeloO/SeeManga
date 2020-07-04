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
    public class MangasController : ControllerBase
    {
        private readonly DataContext _context;

        public MangasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOMangas>>> GetManga()
        {
            return await _context.MANGAS.ToListAsync();
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOMangas>> GetManga(int id)
        {
            var mangaModel = await _context.MANGAS.FindAsync(id);

            if (mangaModel == null)
            {
                return NotFound();
            }

            return mangaModel;
        }

        // PUT: api/Mangas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, DTOMangas mangaModel)
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
        public async Task<ActionResult<Manga_Generos>> PostManga(Manga_Generos manga_generos)
        {
            _context.MANGAS.Add(manga_generos.DtoManga);
            await _context.SaveChangesAsync();
            foreach (var item in manga_generos.GenerosSelected)
            {
                var dtoManga_Generos = new DTOManga_Generos
                {
                    ID_MANGA = manga_generos.DtoManga.ID_MANGA,
                    ID_GENERO = item
                };

                _context.MANGA_GENEROS.Add(dtoManga_Generos);
            }
            await _context.SaveChangesAsync();

            return manga_generos;
        }

        // DELETE: api/Mangas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOMangas>> DeleteManga(int id)
        {
            var mangaModel = await _context.MANGAS.FindAsync(id);
            if (mangaModel == null)
            {
                return NotFound();
            }

            _context.MANGAS.Remove(mangaModel);
            await _context.SaveChangesAsync();

            return mangaModel;
        }

        private bool MangaExists(int id)
        {
            return _context.MANGAS.Any(e => e.ID_MANGA == id);
        }
    }
}
