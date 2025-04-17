using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Data;
using MiniProjet_BDA.Dto;
using MiniProjet_BDA.Models;


namespace MiniProjet_BDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProfessorController : ControllerBase

    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfessorController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/professor

        [HttpGet]
        public ActionResult<List<Professor>> GetAll()
        {
            return Ok(_mapper.Map<List<DefenseDto>>(_context.Defenses.ToListAsync()));
        }




        // GET: api/professor/5


        [HttpGet("{id}")]

        public async Task<ActionResult<Professor>> Get(int id)

        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
                return NotFound();

            return professor;
        }



        // POST: api/professor


        [HttpPost]

        public async Task<ActionResult<Professor>> Create(Professor professor)

        {
            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = professor.Id }, professor);
        }



        // PUT: api/professor/5

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Professor professor)

        {
            var existing = await _context.Professors.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = professor.Name;
            existing.Email = professor.Email;

            // Ajoute d'autres propriétés si besoin

            await _context.SaveChangesAsync();
            return Ok(existing);
        }





        // DELETE: api/professor/5


        [HttpDelete("{id}")]


        public async Task<IActionResult> Delete(int id)


        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
                return NotFound();

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
