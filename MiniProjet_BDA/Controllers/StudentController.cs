using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Models;
using MiniProjet_BDA.Dto;
using AutoMapper;
using MiniProjet_BDA.Data;

namespace MiniProjet_BDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return _mapper.Map<StudentDto>(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Password = "default123"; // par défaut (ou tu fais un système de register à part)
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, _mapper.Map<StudentDto>(student));
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
                return BadRequest();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _mapper.Map(studentDto, student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
