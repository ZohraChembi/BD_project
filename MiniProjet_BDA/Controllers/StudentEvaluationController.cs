using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Dto;
using MiniProjet_BDA.Models;
using AutoMapper;
using MiniProjet_BDA.Data;

namespace MiniProjet_BDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEvaluationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentEvaluationController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StudentEvaluation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEvaluationDto>>> GetAll()
        {
            var evaluations = await _context.StudentEvaluations
                .Include(e => e.Jury)
                .Include(e => e.Student)
                .ToListAsync();

            return Ok(_mapper.Map<List<StudentEvaluationDto>>(evaluations));
        }



        // GET: api/StudentEvaluation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEvaluationDto>> GetById(int id)
        {
            var evaluation = await _context.StudentEvaluations
                .Include(e => e.Jury)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.StudentId == id);

            if (evaluation == null)
                return NotFound();

            return Ok(_mapper.Map<StudentEvaluationDto>(evaluation));
        }

        // POST: api/StudentEvaluation
        [HttpPost]
        public async Task<ActionResult<StudentEvaluationDto>> Create(StudentEvaluationDto dto)
        {
            var evaluation = _mapper.Map<StudentEvaluation>(dto);
            evaluation.Jury = await _context.Juries.FindAsync(dto.JuryId);
            evaluation.Student = await _context.Students.FindAsync(dto.StudentId);

            _context.StudentEvaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = dto.StudentId }, dto);
        }

        // PUT: api/StudentEvaluation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentEvaluationDto dto)
        {
            var evaluation = await _context.StudentEvaluations
                .Include(e => e.Jury)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.StudentId == id);

            if (evaluation == null)
                return NotFound();

            evaluation.Note = dto.Note;
            evaluation.Remark = dto.Remark;
            evaluation.Jury = await _context.Juries.FindAsync(dto.JuryId);
            evaluation.Student = await _context.Students.FindAsync(dto.StudentId);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/StudentEvaluation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evaluation = await _context.StudentEvaluations.FindAsync(id);
            if (evaluation == null)
                return NotFound();

            _context.StudentEvaluations.Remove(evaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
