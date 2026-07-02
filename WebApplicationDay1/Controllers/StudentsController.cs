using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult GetStudents(int id)
        {
            Student student = db.Students.Find(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpGet("{name}")]
        //  [HttpGet("/api/students/s/{name}")]
        public ActionResult GetStudentsName(string name)
        {
            Student student = db.Students.FirstOrDefault(s => s.St_Fname == name);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            db.Students.Add(student);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetStudents), new { id = student.St_Id }, student);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            db.Students.Update(student);
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null) return NotFound();
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }
    }
}
