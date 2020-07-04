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
    public class SituacoesController : ControllerBase
    {
        private readonly DataContext _context;

        public SituacoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Situacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOSituacoes>>> GetSituacoes()
        {
            return await _context.SITUACOES.ToListAsync();
        }

        // GET: api/Situacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOSituacoes>> GetSituacoes(int id)
        {
            var situacoesModel = await _context.SITUACOES.FindAsync(id);

            if (situacoesModel == null)
            {
                return NotFound();
            }

            return situacoesModel;
        }

        // PUT: api/Situacoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituacoes(int id, DTOSituacoes situacoesModel)
        {
            if (id != situacoesModel.ID_SITUACAO)
            {
                return BadRequest();
            }

            _context.Entry(situacoesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacoesExists(id))
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

        // POST: api/Situacoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTOSituacoes>> PostSituacoes(DTOSituacoes situacoesModel)
        {
            _context.SITUACOES.Add(situacoesModel);
            await _context.SaveChangesAsync();

            return situacoesModel;
        }

        // DELETE: api/Situacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOSituacoes>> DeleteSituacoes(int id)
        {
            var situacoesModel = await _context.SITUACOES.FindAsync(id);
            if (situacoesModel == null)
            {
                return NotFound();
            }

            _context.SITUACOES.Remove(situacoesModel);
            await _context.SaveChangesAsync();

            return situacoesModel;
        }

        private bool SituacoesExists(int id)
        {
            return _context.SITUACOES.Any(e => e.ID_SITUACAO == id);
        }
    }
}
