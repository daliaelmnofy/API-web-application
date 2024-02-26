using Day1.Database;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo studentRepo;

        public StudentController(IStudentRepo _studentRepo)
        {
            studentRepo = _studentRepo;
        }



        //GetAll | Get

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = studentRepo.GetAll();
            return Ok(students);
        }

        //Get By Id | Get
        [HttpGet("{id:int}", Name = "GetOne")]
        public IActionResult GetById(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with ID = {id} Not found" });
            }
            return Ok(student);
        }


        //Get By Name | Get
        [HttpGet("/api/Details/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var student = studentRepo.GetByName(name);
            if (student == null)
            {
                return NotFound(new { message = $"Student with Name = {name} Not found" });
            }
            return Ok(student);
        }
        // Add | Post
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Add(student);
                string url = Url.Link("GetOne", new { id = student.Id });
                return Created(url, student);
            }
            return BadRequest(ModelState);
        }
        //Edit | Put
        [HttpPut]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Update(student);
                return NoContent();
            }
            return BadRequest();
        }

        //Delete | Delete

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            studentRepo.Delete(id);
            return Ok(student);
        }
    }

}
