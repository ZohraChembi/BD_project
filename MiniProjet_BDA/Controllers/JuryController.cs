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
    public class JuryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JuryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Jury
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JuryDto>>> GetJuries()
        {
            var juries = await _context.Juries.ToListAsync();
            return _mapper.Map<List<JuryDto>>(juries);
        }

        // GET: api/Jury/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JuryDto>> GetJury(int id)
        {
            var jury = await _context.Juries.FindAsync(id);
            if (jury == null)
                return NotFound();

            return _mapper.Map<JuryDto>(jury);
        }

        // POST: api/Jury
        [HttpPost]
        public async Task<ActionResult<JuryDto>> PostJury(JuryDto juryDto)
        {
            var jury = _mapper.Map<Jury>(juryDto);
            _context.Juries.Add(jury);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJury), new { id = jury.Id }, _mapper.Map<JuryDto>(jury));
        }

        // PUT: api/Jury/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJury(int id, JuryDto juryDto)
        {
            if (id != juryDto.Id)
                return BadRequest();

            var jury = await _context.Juries.FindAsync(id);
            if (jury == null)
                return NotFound();

            _mapper.Map(juryDto, jury);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Jury/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJury(int id)
        {
            var jury = await _context.Juries.FindAsync(id);
            if (jury == null)
                return NotFound();

            _context.Juries.Remove(jury);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}