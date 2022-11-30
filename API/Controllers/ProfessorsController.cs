using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTOs;
using API.Models.Entities;
using API.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorsController(DataContext context)
        {
            _context = context;
        }

        // POST /api/professors/ : create a new professor
        [HttpPost]
        public async Task<IActionResult> CreateProfessorAsync(Professor professor)
        {
            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        // GET /api/professors/{id} : return a professor object (without including the courses)
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetProfessorAsync(string id)
        {
            try
            {
                var professor = await _context.Professors
                                        .SingleOrDefaultAsync(x => x.Id == new Guid(id));

                if (professor == null)
                    return NotFound();
                
                var professorDto = new ProfessorDTO
                {
                    Id = professor.Id,
                    Name = professor.Name,
                    EmploymentType = professor.EmploymentType
                };

                return Ok(professorDto);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }   
        }

        // GET api/professors/full/{id}
        [HttpGet("full/{id}")]
        public async Task<IActionResult> GetProfessorWithCoursesAsync(string id)
        {
            try
            {
                var professor = await _context.Professors
                                        .Include(x => x.Courses)
                                        .SingleOrDefaultAsync(x => x.Id == new Guid(id));

                if (professor == null)
                    return NotFound();

                return Ok(professor);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }   
        }

        //GET api/professors
        [HttpGet]
        public  IActionResult GetProfessors()
        {
            return Ok(_context.Professors.Include(x => x.Courses));
        }

        // GET /api/professors/byname?name={name}
        [HttpGet("byname")]
        public async Task<IActionResult> GetProfessorByNameAsync([FromQuery] string name)
        {
            try
            {
                var professor = await _context.Professors
                                                    .Include(x => x.Courses)
                                                    .SingleOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
                
                if (professor == null)
                    return NotFound();

                return Ok(professor);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}