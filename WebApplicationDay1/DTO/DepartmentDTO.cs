using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationDay1.Models;

namespace WebApplicationDay1.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }

        public string DepartmentLocation { get; set; }

        public List<string> StudentNames { get; set; } = new List<string>();
    }
}
