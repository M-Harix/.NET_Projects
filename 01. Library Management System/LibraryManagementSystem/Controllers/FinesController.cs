using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Model;
using AutoMapper;
using LibraryManagementSystem.Dto;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public FinesController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Fines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FineDto>>> GetFine()
        {
            var result = await _context.Fine.ToListAsync();
            return Ok(result.Select(r => _mapper.Map<FineDto>(r)));
        }

        // GET: api/Fines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FineDto>> GetFine(int id)
        {
            var fine = await _context.Fine.FindAsync(id);

            if (fine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FineDto>(fine));
        }

        // PUT: api/Fines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFine(int id, FineDto fine)
        {
            if (id != fine.FineID)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Fine>(fine);
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FineExists(id))
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

        // POST: api/Fines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FineDto>> PostFine(FineDto fine)
        {
            var result = _mapper.Map<Fine>(fine);
            _context.Fine.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFine", new { id = result.FineID }, result);
        }

        // DELETE: api/Fines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFine(int id)
        {
            var fine = await _context.Fine.FindAsync(id);
            if (fine == null)
            {
                return NotFound();
            }

            _context.Fine.Remove(fine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FineExists(int id)
        {
            return _context.Fine.Any(e => e.FineID == id);
        }
    }
}
