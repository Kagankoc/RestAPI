using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly EShopContext _context;

        public PagesController(EShopContext context)
        {
            _context = context;
        }

        //GET  /api/pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await _context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }

        //GET  /api/pages/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(Guid id)
        {
            return await _context.Pages.FindAsync(id) ?? (ActionResult<Page>)NotFound();
        }

        //PUT  /api/pages/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Page>> PutPage(Guid id, Page page)
        {
            if (page.Id != id)
            {
                return BadRequest();
            }

            _context.Entry(page).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Post  /api/pages
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage(Page page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostPage), page);
        }

        //Delete  /api/pages/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Page>> DeletePage(Guid id)
        {
            var page = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
}