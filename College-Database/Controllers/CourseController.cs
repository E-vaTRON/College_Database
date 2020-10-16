using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using College_Database.Contracts;
using College_Database.Core.Database;
using College_Database.Core.Entities;
using College_Database.DataObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College_Database.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseRepository.FindByIdAsync(id);

            if (course is null)
                return NotFound();

            return Ok(_courseRepository.FindByIdAsync(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_courseRepository.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDTO dto)
        {
            var course = _mapper.Map<Course>(dto);
            _courseRepository.Create(course);
            await _courseRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseRepository.FindByIdAsync(id);
            if (course is null)
                return NotFound();

            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseDTO dto)
        {
            var course = await _courseRepository.FindByIdAsync(id);
            if (course is null)
                return NotFound();

            _mapper.Map(dto, course);
            await _courseRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
