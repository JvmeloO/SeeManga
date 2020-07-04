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
        public async Task<ActionResult<IEnumerable<DTOPaginas>>> GetPaginas()
        {
            return await _context.PAGINAS.ToListAsync();
        }

        // GET: api/Paginas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOPaginas>> GetPaginas(int id)
        {
            var paginasModel = await _context.PAGINAS.FindAsync(id);

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
        public async Task<IActionResult> PutPaginas(int id, DTOPaginas paginasModel)
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
                if (!PaginasExists(id))
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
        public async Task<ActionResult<DTOPaginas>> PostPaginas(DTOPaginas paginasModel)
        {
            _context.PAGINAS.Add(paginasModel);
            await _context.SaveChangesAsync();

            return paginasModel;
        }

        // DELETE: api/Paginas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOPaginas>> DeletePaginas(int id)
        {
            var paginasModel = await _context.PAGINAS.FindAsync(id);
            if (paginasModel == null)
            {
                return NotFound();
            }

            _context.PAGINAS.Remove(paginasModel);
            await _context.SaveChangesAsync();

            return paginasModel;
        }

        private bool PaginasExists(int id)
        {
            return _context.PAGINAS.Any(e => e.ID_PAGINAS == id);
        }
    }
}
