using Microsoft.AspNetCore.Mvc;
using MiniProjet_BDA.Models;
using Microsoft.EntityFrameworkCore;
using MiniProjet_BDA.Dto;
using AutoMapper;
using MiniProjet_BDA.Data;

namespace MiniProjet_BDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]




    public class ProjectController : ControllerBase


    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        // GET: api/Project


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<List<ProjectDto>>(projects);
        }



        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            return _mapper.Map<ProjectDto>(project);
        }








        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, _mapper.Map<ProjectDto>(project));
        }




        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectDto projectDto)
        {
            if (id != projectDto.ProjectId)
                return BadRequest();

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            _mapper.Map(projectDto, project);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Project/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
