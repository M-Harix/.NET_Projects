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
    public class BookCopiesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public BookCopiesController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BookCopies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCopyDto>>> GetBookCopy()
        {
            var result = await _context.BookCopy.ToListAsync();
            return Ok(result.Select(r => _mapper.Map<BookCopyDto>(r)));
        }

        // GET: api/BookCopies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCopyDto>> GetBookCopy(int id)
        {
            var bookCopy = await _context.BookCopy.FindAsync(id);

            if (bookCopy == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookCopyDto>(bookCopy)); ;
        }

        // PUT: api/BookCopies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCopy(int id, BookCopyDto bookCopy)
        {
            if (id != bookCopy.Id)
            {
                return BadRequest();
            }

            var result = _mapper.Map<BookCopy>(bookCopy);
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCopyExists(id))
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

        // POST: api/BookCopies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCopyDto>> PostBookCopy(BookCopyDto bookCopy)
        {
            var result = _mapper.Map<BookCopy>(bookCopy);
            _context.BookCopy.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookCopy", new { id = result.Id }, result);
        }

        // DELETE: api/BookCopies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCopy(int id)
        {
            var bookCopy = await _context.BookCopy.FindAsync(id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            _context.BookCopy.Remove(bookCopy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookCopyExists(int id)
        {
            return _context.BookCopy.Any(e => e.Id == id);
        }
    }
}
