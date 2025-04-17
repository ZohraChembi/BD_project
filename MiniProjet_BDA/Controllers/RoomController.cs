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
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }
        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            return _mapper.Map<RoomDto>(room);
        }
        // POST: api/Room
        [HttpPost]
        public async Task<ActionResult<RoomDto>> PostRoom(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, _mapper.Map<RoomDto>(room));
        }
        // PUT: api/Room/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDto roomDto)
        {
            if (id != roomDto.RoomId)
                return BadRequest();

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            _mapper.Map(roomDto, room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
