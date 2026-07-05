using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using WebApplicationDay1.DTO;
using WebApplicationDay1.Models;
using WebApplicationDay1.Repository;

namespace WebApplicationDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // private readonly ITIContext db;
        private readonly StudentsRepository repository;
        public StudentsController(StudentsRepository repository)
        {
            this.repository = repository;
        }

        [SwaggerOperation(
            Summary = "Get all students",
            Description = "Retrieve a list of all students with their department information."
        )]
        [SwaggerResponse(200, "List of students", typeof(List<StudentDTO>))]
        [HttpGet]
        public ActionResult<List<StudentDTO>> GetAllStudents()
        {
            var students = repository.GetAllStudents();

            var studentsDTO = students.Select(student => new StudentDTO
            {
                ID = student.St_Id,
                Age = student.St_Age ?? 0,
                Fullname = student.FullName,
                Address = student.St_Address,
                Department = student.Dept?.Dept_Name ?? "No Department",
                SupervisorId = student.St_super ?? 0
            }).ToList();

            return Ok(studentsDTO);
        }

        /// <summary>
        /// Get a student by ID 
        /// </summary>
        /// <param name="id">The ID of the student to retrieve</param>
        /// <remarks>
        /// Retrieves a student by their unique ID.
        /// </remarks>
        /// <returns>The student with the specified ID</returns>
        [HttpGet("{id:int}")]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            var student = repository.GetStudentById(id);

            if (student == null)
                return NotFound();

            var studentDTO = new StudentDTO
            {
                ID = student.St_Id,
                Age = student.St_Age ?? 0,
                Fullname = student.FullName,
                Address = student.St_Address ?? "No Address",
                Department = student.Dept?.Dept_Name ?? "No Department",
                SupervisorId = student.St_super ?? 0
            };

            return Ok(studentDTO);
        }

        [HttpGet("by-name/{name}")]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            var student = repository.GetStudentByName(name);

            if (student == null)
                return NotFound();

            var studentDTO = new StudentDTO
            {
                ID = student.St_Id,
                Age = student.St_Age ?? 0,
                Fullname = student.FullName,
                Address = student.St_Address ?? "No Address",
                Department = student.Dept?.Dept_Name ?? "No Department",
                SupervisorId = student.St_super ?? 0
            };

            return Ok(studentDTO);
        }

        [HttpPost]
        public ActionResult AddNewStudent(Student student)
        {
            if (student == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.AddStudent(student);

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = student.St_Id },
                student);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateStudent(int id, Student student)
        {
            if (student == null)
                return BadRequest();

            if (id != student.St_Id)
                return BadRequest("ID mismatch.");

            var existingStudent = repository.GetStudentById(id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.St_Fname = student.St_Fname;
            existingStudent.St_Lname = student.St_Lname;
            existingStudent.St_Address = student.St_Address;
            existingStudent.St_Age = student.St_Age;
            existingStudent.Dept_Id = student.Dept_Id;
            existingStudent.St_super = student.St_super;

            repository.UpdateStudent(existingStudent);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = repository.GetStudentById(id);

            if (student == null)
                return NotFound();

            repository.DeleteStudent(id);

            return Ok(student);
        }
    }
}