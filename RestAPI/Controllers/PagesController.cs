using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
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

        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await _context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}