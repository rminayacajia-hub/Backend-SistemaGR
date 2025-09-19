using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menu : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public Menu(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menus>> GetMenus(int id)
        {
            var menus = await _context.Menus.FindAsync(id);

            if (menus == null)
            {
                return NotFound();
            }

            return menus;
        }

        // PUT: api/Menu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenus(int id, Menus menus)
        {
            if (id != menus.Id)
            {
                return BadRequest();
            }

            _context.Entry(menus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenusExists(id))
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

        // POST: api/Menu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menus>> PostMenus(Menus menus)
        {
            _context.Menus.Add(menus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenus", new { id = menus.Id }, menus);
        }

        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenus(int id)
        {
            var menus = await _context.Menus.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenusExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
