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
    public class CapitulosController : ControllerBase
    {
        private readonly DataContext _context;

        public CapitulosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Capitulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCapitulos>>> GetCapitulos()
        {
            return await _context.CAPITULOS.ToListAsync();
        }

        // GET: api/Capitulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOCapitulos>> GetCapitulos(int id)
        {
            var capitulosModel = await _context.CAPITULOS.FindAsync(id);

            if (capitulosModel == null)
            {
                return NotFound();
            }

            return capitulosModel;
        }

        // PUT: api/Capitulos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]        
        public async Task<IActionResult> PutCapitulos(int id, DTOCapitulos capitulosModel)
        {
            if (id != capitulosModel.ID_CAPITULOS)
            {
                return BadRequest();
            }

            _context.Entry(capitulosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapitulosExists(id))
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

        // POST: api/Capitulos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTOCapitulos>> PostCapitulos(DTOCapitulos capitulosModel)
        {
            _context.CAPITULOS.Add(capitulosModel);
            await _context.SaveChangesAsync();

            return capitulosModel;
        }

        // DELETE: api/Capitulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOCapitulos>> DeleteCapitulos(int id)
        {
            var capitulosModel = await _context.CAPITULOS.FindAsync(id);
            if (capitulosModel == null)
            {
                return NotFound();
            }

            _context.CAPITULOS.Remove(capitulosModel);
            await _context.SaveChangesAsync();

            return capitulosModel;
        }

        private bool CapitulosExists(int id)
        {
            return _context.CAPITULOS.Any(e => e.ID_CAPITULOS == id);
        }
    }
}
