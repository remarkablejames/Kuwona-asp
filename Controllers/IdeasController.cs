using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kuwona.Data;
using Kuwona.Models;

namespace Kuwona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IdeasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ideas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idea>>> GetIdea()
        {
          if (_context.Idea == null)
          {
              return NotFound();
          }
            return await _context.Idea.ToListAsync();
        }

        // GET: api/Ideas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idea>> GetIdea(int id)
        {
          if (_context.Idea == null)
          {
              return NotFound();
          }
            var idea = await _context.Idea.FindAsync(id);

            if (idea == null)
            {
                return NotFound();
            }

            return idea;
        }

        // PUT: api/Ideas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdea(int id, Idea idea)
        {
            if (id != idea.IdeaId)
            {
                return BadRequest();
            }

            _context.Entry(idea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaExists(id))
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

        // POST: api/Ideas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Idea>> PostIdea(Idea idea)
        {
          if (_context.Idea == null)
          {
              return Problem("Entity set 'AppDbContext.Idea'  is null.");
          }
            _context.Idea.Add(idea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdea", new { id = idea.IdeaId }, idea);
        }

        // DELETE: api/Ideas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdea(int id)
        {
            if (_context.Idea == null)
            {
                return NotFound();
            }
            var idea = await _context.Idea.FindAsync(id);
            if (idea == null)
            {
                return NotFound();
            }

            _context.Idea.Remove(idea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaExists(int id)
        {
            return (_context.Idea?.Any(e => e.IdeaId == id)).GetValueOrDefault();
        }
    }
}
