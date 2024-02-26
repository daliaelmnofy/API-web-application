using Day1.Custom_Filter;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }

        // GetAll | Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = departmentRepo.GetAll();
            return Ok(departments);
        }

        // GetById | Get
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var department = departmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound(new { message = $"Department with ID = {id} Not found" });
            }
            return Ok(department);
        }

        // GetByName | Get
        [HttpGet("/api/Departments/Details/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var department = departmentRepo.GetByName(name);
            if (department == null)
            {
                return NotFound(new { message = $"Department with Name = {name} Not found" });
            }
            return Ok(department);
        }

        // Add | Post
        [HttpPost]
        [LocationFilter("USA", "EG")] // Applying LocationFilterAttribute
        public IActionResult Add([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.Add(department);
                string url = Url.Link("GetOne", new { id = department.Id });
                return Created(url, department);
            }
            return BadRequest(ModelState);
        }

        // Edit | Put
        [HttpPut]
        [LocationFilter("USA", "EG")]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.Update(department);
                return NoContent();
            }
            return BadRequest();
        }

        // Delete | Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = departmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            departmentRepo.Delete(id);
            return Ok(department);
        }
    }
}
