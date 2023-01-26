using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_semana1_modulo03.Context;
using Projeto_semana1_modulo03.Models;

namespace Projeto_semana1_modulo03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemsController : ControllerBase
    {
        private readonly ContextApp _context;

        public PostagemsController(ContextApp context)
        {
            _context = context;
        }

        // GET: api/Postagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postagem>>> GetPostagems()
        {
          if (_context.Postagems == null)
          {
              return NotFound();
          }
            return await _context.Postagems.ToListAsync();
        }

        // GET: api/Postagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postagem>> GetPostagem(int id)
        {
          if (_context.Postagems == null)
          {
              return NotFound();
          }
            var postagem = await _context.Postagems.FindAsync(id);

            if (postagem == null)
            {
                return NotFound();
            }

            return postagem;
        }

        // PUT: api/Postagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostagem(int id, Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostagemExists(id))
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

        // POST: api/Postagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Postagem>> PostPostagem(Postagem postagem)
        {
          if (_context.Postagems == null)
          {
              return Problem("Entity set 'ContextApp.Postagems'  is null.");
          }
            _context.Postagems.Add(postagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostagem", new { id = postagem.Id }, postagem);
        }

        // DELETE: api/Postagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostagem(int id)
        {
            if (_context.Postagems == null)
            {
                return NotFound();
            }
            var postagem = await _context.Postagems.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }

            _context.Postagems.Remove(postagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostagemExists(int id)
        {
            return (_context.Postagems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
