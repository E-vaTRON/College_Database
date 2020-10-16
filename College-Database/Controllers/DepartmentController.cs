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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentRepository.FindByIdAsync(id);

            if (department is null)
                return NotFound();

            return Ok(_departmentRepository.FindByIdAsync(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_departmentRepository.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO dto)
        {
            var department = _mapper.Map<Department>(dto);
            _departmentRepository.Create(department);
            await _departmentRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.FindByIdAsync(id);
            if (department is null)
                return NotFound();

            _departmentRepository.Delete(department);
            await _departmentRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDTO dto)
        {
            var department = await _departmentRepository.FindByIdAsync(id);
            if (department is null)
                return NotFound();

            _mapper.Map(dto, department);
            await _departmentRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
