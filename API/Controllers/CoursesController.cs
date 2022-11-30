using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {

        private DataContext _database;
        public CoursesController(DataContext database)
        {
            _database = database;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            try
            {
                await _database.Courses.AddAsync(course);
                await _database.SaveChangesAsync();
                return Ok();

            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet] //Get All Courses
        public async Task<IActionResult> GetPersonAsync()
        {
            try
            {
                return Ok(_database.Courses);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")] //Get Single Full Course
        public async Task<IActionResult> GetPersonAsync(string id)
        {
            try
            {
                var course = await _database.Courses.FindAsync(new Guid(id));
                if (course == null)
                    return NotFound();
                else
                    return Ok(course);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetPersonAsync(string id)
        // {
        //     try
        //     {
        //         var course = await _database.Courses.FindAsync(new Guid(id));
        //         if (course == null)
        //             return NotFound();

        //         var response = new Response<PersonDto>
        //         {
        //             Data = new PersonDto
        //             {
        //                 Id = course.Id,
        //                 title = course.Title,
        //                 credits = course.NumberOfCredits,
                        
        //             },
        //         };
                
        //         return Ok(response);
        //     }
        //     catch (System.Exception)
        //     {
        //         return BadRequest();
        //     }
        // }


    }
}