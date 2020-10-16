using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using College_Database.Contracts;
using College_Database.Core.Entities;
using College_Database.DataObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace College_Database.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorController(IInstructorRepository instructorRepository, Mapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instuctor = await _instructorRepository.FindByIdAsync(id);

            if (instuctor is null)
                return NotFound();

            return Ok(_instructorRepository.FindByIdAsync(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_instructorRepository.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstuctor(InstructorDTO dto)
        {
            var instuctor = _mapper.Map<Instuctor>(dto);
            _instructorRepository.Create(instuctor);
            await _instructorRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, InstructorDTO dto)
        {
            var instuctor = await _instructorRepository.FindByIdAsync(id);
            if (instuctor is null)
                return NotFound();

            _mapper.Map(dto, instuctor);
            await _instructorRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id, InstructorDTO dto)
        {
            var instructor = await _instructorRepository.FindByIdAsync(id);
            if (instructor is null)
                return NotFound();

            _mapper.Map(dto, instructor);
            await _instructorRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
