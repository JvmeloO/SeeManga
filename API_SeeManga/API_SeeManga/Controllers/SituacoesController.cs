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
    public class SituacoesController : ControllerBase
    {
        private readonly DataContext _context;

        public SituacoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Situacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SituacoesModel>>> GetSituacoes()
        {
            return await _context.Situacoes.ToListAsync();
        }

        // GET: api/Situacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SituacoesModel>> GetSituacoesModel(int id)
        {
            var situacoesModel = await _context.Situacoes.FindAsync(id);

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
        public async Task<IActionResult> PutSituacoesModel(int id, SituacoesModel situacoesModel)
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
                if (!SituacoesModelExists(id))
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
        public async Task<ActionResult<SituacoesModel>> PostSituacoesModel(SituacoesModel situacoesModel)
        {
            _context.Situacoes.Add(situacoesModel);
            await _context.SaveChangesAsync();

            return situacoesModel;
        }

        // DELETE: api/Situacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SituacoesModel>> DeleteSituacoesModel(int id)
        {
            var situacoesModel = await _context.Situacoes.FindAsync(id);
            if (situacoesModel == null)
            {
                return NotFound();
            }

            _context.Situacoes.Remove(situacoesModel);
            await _context.SaveChangesAsync();

            return situacoesModel;
        }

        private bool SituacoesModelExists(int id)
        {
            return _context.Situacoes.Any(e => e.ID_SITUACAO == id);
        }
    }
}
