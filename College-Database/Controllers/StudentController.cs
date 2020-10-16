 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using College_Database.Contracts;
using College_Database.Core.Entities;
using College_Database.DataObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College_Database.Controllers
{
    [Route("api/[controller]/[action")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.FindByIdAsync(id);

            if (student is null)
                return NotFound();

            return Ok(_studentRepository.FindByIdAsync(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentRepository.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO dto)
        {
            var student = _mapper.Map<Student>(dto);
            _studentRepository.Create(student);
            await _studentRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.FindByIdAsync(id);
            if (student is null)
                return NotFound();

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDTO dto)
        {
            var student = await _studentRepository.FindByIdAsync(id);
            if (student is null)
                return NotFound();

            _mapper.Map(dto, student);
            await _studentRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
