using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDay1.DTO;
using WebApplicationDay1.Models;

namespace WebApplicationDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ITIContext db;

        public DepartmentController(ITIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<DepartmentDTO>> GetAllDepartments()
        {
            List<Department> departments = db.Departments.ToList();

            if (departments == null || departments.Count == 0)
                return NotFound();

            else
            {
                List<DepartmentDTO> departmentDTOs = departments.Select(d => new DepartmentDTO()
                {
                    DepartmentID = d.Dept_Id,
                    DepartmentName = d.Dept_Name,
                    DepartmentDescription = d.Dept_Desc,
                    DepartmentLocation = d.Dept_Location,
                    StudentNames = d.Students.Select(s => s.FullName).ToList()
                }).ToList();

                return Ok(departmentDTOs);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<DepartmentDTO>> GetDepartmentById(int id)
        {
            Department department = db.Departments.FirstOrDefault(d => d.Dept_Id == id);

            if (department == null)
                return NotFound();

            else
            {
                DepartmentDTO departmentDTO = new DepartmentDTO()
                {
                    DepartmentID = department.Dept_Id,
                    DepartmentName = department.Dept_Name,
                    DepartmentDescription = department.Dept_Desc,
                    DepartmentLocation = department.Dept_Location,
                    StudentNames = department.Students.Select(s => s.FullName).ToList()
                };

                return Ok(departmentDTO);
            }
        }
    }
}