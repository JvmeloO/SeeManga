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
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaginasController : ControllerBase
    {
        private readonly DataContext _context;

        public PaginasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Paginas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaginasModel>>> GetPaginas()
        {
            return await _context.Paginas.ToListAsync();
        }

        // GET: api/Paginas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaginasModel>> GetPaginasModel(int id)
        {
            var paginasModel = await _context.Paginas.FindAsync(id);

            if (paginasModel == null)
            {
                return NotFound();
            }

            return paginasModel;
        }

        // PUT: api/Paginas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaginasModel(int id, PaginasModel paginasModel)
        {
            if (id != paginasModel.ID_PAGINAS)
            {
                return BadRequest();
            }

            _context.Entry(paginasModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginasModelExists(id))
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

        // POST: api/Paginas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PaginasModel>> PostPaginasModel(PaginasModel paginasModel)
        {
            _context.Paginas.Add(paginasModel);
            await _context.SaveChangesAsync();

            return paginasModel;
        }

        // DELETE: api/Paginas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaginasModel>> DeletePaginasModel(int id)
        {
            var paginasModel = await _context.Paginas.FindAsync(id);
            if (paginasModel == null)
            {
                return NotFound();
            }

            _context.Paginas.Remove(paginasModel);
            await _context.SaveChangesAsync();

            return paginasModel;
        }

        private bool PaginasModelExists(int id)
        {
            return _context.Paginas.Any(e => e.ID_PAGINAS == id);
        }
    }
}
