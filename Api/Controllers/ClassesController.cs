using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllClasses()
        {
            return Ok(await _context.Classes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClass(int id)
        {
            var myClass = await _context.Classes.FindAsync(id);
            if (myClass == null)
                return NotFound();

            return Ok(myClass);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> CreateClass(Class myClass)
        {
            _context.Classes.Add(myClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllClasses), new { id = myClass.Id }, myClass);
        }


    }
}
