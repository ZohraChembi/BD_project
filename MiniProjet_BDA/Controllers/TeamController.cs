using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Dto;
using MiniProjet_BDA.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjet_BDA.Controllers


{


    [ApiController]
    [Route("api/[controller]")]





   
        public class TeamController : ControllerBase
        {
            private readonly Data.ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public TeamController(Data.ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }






            // GET: api/Team
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
            {
            var teams = await _context.Teams.ToListAsync();
                return _mapper.Map<List<TeamDto>>(teams);
            }







            // GET: api/Team/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TeamDto>> GetTeam(int id)
            {
                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                    return NotFound();

                return _mapper.Map<TeamDto>(team);
            }






            // POST: api/Team
            [HttpPost]
            public async Task<ActionResult<TeamDto>> PostTeam(TeamDto teamDto)
            {
                var team = _mapper.Map<Team>(teamDto);
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, _mapper.Map<TeamDto>(team));
            }







            // PUT: api/Team/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTeam(int id, TeamDto teamDto)
            {
                if (id != teamDto.TeamId)
                    return BadRequest();

                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                    return NotFound();

                _mapper.Map(teamDto, team);
                await _context.SaveChangesAsync();

                return NoContent();
            }






            // DELETE: api/Team/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTeam(int id)
            {
                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                    return NotFound();

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
