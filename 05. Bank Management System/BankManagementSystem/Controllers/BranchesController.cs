﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Data;
using BankManagementSystem.Model;
using AutoMapper;
using BankManagementSystem.Dto;

namespace BankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public BranchesController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranch()
        {
            var result = await _context.Branch.ToListAsync();
            return Ok(result.Select(r => _mapper.Map<BranchDto>(r)));
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDto>> GetBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BranchDto>(branch));
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, BranchDto branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Branch>(branch);
            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BranchDto>> PostBranch(BranchDto branch)
        {
            var result = _mapper.Map<Branch>(branch);
            _context.Branch.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = result.Id }, result);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }
    }
}
