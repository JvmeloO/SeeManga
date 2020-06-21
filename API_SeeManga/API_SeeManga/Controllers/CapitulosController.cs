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
    public class CapitulosController : ControllerBase
    {
        private readonly DataContext _context;

        public CapitulosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Capitulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapitulosModel>>> GetCapitulos()
        {
            return await _context.Capitulos.ToListAsync();
        }

        // GET: api/Capitulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapitulosModel>> GetCapitulosModel(int id)
        {
            var capitulosModel = await _context.Capitulos.FindAsync(id);

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
        public async Task<IActionResult> PutCapitulosModel(int id, CapitulosModel capitulosModel)
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
                if (!CapitulosModelExists(id))
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
        public async Task<ActionResult<CapitulosModel>> PostCapitulosModel(CapitulosModel capitulosModel)
        {
            _context.Capitulos.Add(capitulosModel);
            await _context.SaveChangesAsync();

            return capitulosModel;
        }

        // DELETE: api/Capitulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CapitulosModel>> DeleteCapitulosModel(int id)
        {
            var capitulosModel = await _context.Capitulos.FindAsync(id);
            if (capitulosModel == null)
            {
                return NotFound();
            }

            _context.Capitulos.Remove(capitulosModel);
            await _context.SaveChangesAsync();

            return capitulosModel;
        }

        private bool CapitulosModelExists(int id)
        {
            return _context.Capitulos.Any(e => e.ID_CAPITULOS == id);
        }
    }
}
