using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDay1.DTO;
using WebApplicationDay1.Models;

namespace WebApplicationDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ITIContext db;

        public StudentsController(ITIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetAllStudents()
        {
            var students = db.Students
                .Include(s => s.Dept)
                .ToList();

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

        [HttpGet("{id:int}")]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            var student = db.Students
                .Include(s => s.Dept)
                .FirstOrDefault(s => s.St_Id == id);

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
            var student = db.Students
                .Include(s => s.Dept)
                .FirstOrDefault(s => s.St_Fname == name);

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

            db.Students.Add(student);
            db.SaveChanges();

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

            var existingStudent = db.Students.Find(id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.St_Fname = student.St_Fname;
            existingStudent.St_Lname = student.St_Lname;
            existingStudent.St_Address = student.St_Address;
            existingStudent.St_Age = student.St_Age;
            existingStudent.Dept_Id = student.Dept_Id;
            existingStudent.St_super = student.St_super;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
                return NotFound();

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }
    }
}