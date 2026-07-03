using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDay1.DTO;
using WebApplicationDay1.Models;

namespace WebApplicationDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        ITIContext db;
        public StudentsController(ITIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetAllStudents()
        {
            List<Student> students = db.Students.ToList();
            List<StudentDTO> studentsDTO = students.Select(student => new StudentDTO()
            {
                ID = student.St_Id,
                Age = student.St_Age ?? 0,
                Fullname = student.St_Fname.Trim() + " " + student.St_Lname.Trim(),
                Address = student.St_Address,
                Department = student.Dept?.Dept_Name ?? "No Department",
                SupervisorId = student.St_super ?? 0
            }).ToList();

            return Ok(studentsDTO);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetStudentsById(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null) return NotFound();
            else
            {
                StudentDTO studentDTO = new StudentDTO()
                {
                    ID = student.St_Id,
                    Age = student.St_Age ?? 0,
                    Fullname = student.St_Fname.Trim() + " " + student.St_Lname.Trim(),
                    Address = student.St_Address,
                    Department = student.Dept?.Dept_Name ?? "No Department",
                    SupervisorId = student.St_super ?? 0
                };

                return Ok(studentDTO);
            }
        }

        [HttpGet("{name}")]
        // Another way to get a student by name could be using a query parameter instead of a route parameter. For example, you could use the following code:
        //  [HttpGet("/api/students/s/{name}")]
        public ActionResult GetStudentsByName(string name)
        {
            Student student = db.Students.FirstOrDefault(s => s.St_Fname == name);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public ActionResult AddNewStudent(Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            db.Students.Add(student);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetStudentsById), new { id = student.St_Id }, student);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateStudent(int id, Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            db.Students.Update(student);
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null) return NotFound();
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }
    }
}
