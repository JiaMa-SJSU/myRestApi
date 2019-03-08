using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myRestApi.Models;

namespace myRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly myRestContext _context;

        public ItemController(myRestContext context)
        {
            _context = context;

            if (_context.SomeItems.Count() == 0)
            {
                _context.SomeItems.Add(new SomeItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SomeItem>>> GetSomeItems()
        {
            return await _context.SomeItems.ToListAsync();
        }

        // GET: api/item/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SomeItem>> GetSomeItem(int id)
        {
            var someItem = await _context.SomeItems.FindAsync(id);

            if (someItem == null)
            {
                return NotFound();
            }

            return someItem;
        }
    }
}