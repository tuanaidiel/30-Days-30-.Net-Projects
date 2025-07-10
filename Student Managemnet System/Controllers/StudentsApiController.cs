using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsApiController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();
        private static int _nextId = 1;


        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_students);
        }


        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] StudentManagementSystem student)
        {
            if(string.IsNullOrEmpty(student.Name) || student.Age <= 0)
            {
                return BadRequest("Name must not be empty and age must be positive.");
            }

            student.Id = _nextId++;
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}