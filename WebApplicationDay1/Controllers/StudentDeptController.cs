using Microsoft.AspNetCore.Mvc;
using WebApplicationDay1.Repository;
using WebApplicationDay1.Controllers;
using WebApplicationDay1.Models;
using WebApplicationDay1.UnitOfWork;

namespace WebApplicationDay1.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class StudentDeptController : ControllerBase
    {
        UOW unitOfWork;

        public StudentDeptController(UOW unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult add(Student student)    
        {
            unitOfWork.DepartmentRepository.Add(student.Dept);
            unitOfWork.StudentRepository.Add(student);
            unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
