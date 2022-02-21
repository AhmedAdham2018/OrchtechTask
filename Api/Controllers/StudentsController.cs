using Api.DTOs;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var studentClasses = _context.StudentClasses.Include(x => x.Class);
            return Ok(await _context.Students.Select(x => StudentToDTO(x, studentClasses.Where(c => c.StudentId == x.Id))).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(StudentToDTO(student, _context.StudentClasses.Include(x => x.Class).Where(x => x.StudentId == student.Id)));
        }
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllStudents), new { id = student.Id },student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(long id, Student studentDTO)
        {
            if (id != studentDTO.Id)
                return BadRequest();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.Gender = studentDTO.Gender;
            student.Mobile = studentDTO.Mobile;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StudentExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();
            
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool StudentExists(long id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        private static StudentDTO StudentToDTO(Student student, IEnumerable<StudentClass> studentClasses) =>
            new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                Mobile = student.Mobile,
                StudentClasses = studentClasses.Select(x => x.Class)!
            };
    }
}
