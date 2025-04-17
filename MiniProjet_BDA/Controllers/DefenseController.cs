using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Data;
using MiniProjet_BDA.Dto;
using MiniProjet_BDA.Models;

namespace MiniProjet_BDA.Controllers


{
    [ApiController]
    [Route("api/[controller]")]




    public class DefenseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        // Liste statique pour simuler une base de données
        // create constractor and add ApplicationDbContaxt and Imapper  
        public DefenseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // ✅ GET: api/Defense
        [HttpGet]
        public async Task<ActionResult<List<DefenseDto>>> GetAll()
        {
            var defenses = await _context.Defenses.ToListAsync(); // ✅ await ici
            var mappedDefenses = _mapper.Map<List<DefenseDto>>(defenses); // ✅ mapping ici
            return Ok(mappedDefenses);
        }
        // POST: api/Defenses
        [HttpPost]
        public async Task<ActionResult<DefenseDto>> PostDefense(DefenseCreateDto defenseCreateDto)
        {
            if (defenseCreateDto == null)
                return BadRequest("Defense data is null.");

            var defense = _mapper.Map<Defense>(defenseCreateDto); // pas d'Id ici
            _context.Defenses.Add(defense);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<DefenseDto>(defense); // map vers DTO avec Id
            return CreatedAtAction(nameof(PutDefense), new { id = defense.Id }, resultDto);
        }
        // PUT: api/Defenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefense(int id, DefenseDto defenseDto)
        {
            if (defenseDto == null || id != defenseDto.Id)
                return BadRequest("Invalid Defense data.");

            var existingDefense = await _context.Defenses.FindAsync(id);
            if (existingDefense == null)
                return NotFound();

            _mapper.Map(defenseDto, existingDefense);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Defenses.Any(d => d.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }
        // DELETE: api/Defenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefense(int id)
        {
            var defense = await _context.Defenses.FindAsync(id);
            if (defense == null)
                return NotFound();

            _context.Defenses.Remove(defense);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
