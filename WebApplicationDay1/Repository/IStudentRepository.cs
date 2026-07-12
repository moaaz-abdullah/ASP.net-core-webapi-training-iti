using WebApplicationDay1.Models;

namespace WebApplicationDay1.Repository
{
    public interface IStudentRepository
    {   
        public List<Student> GetAllStudents();

        public Student GetStudentById(int id);

        public Student GetStudentByName(string name);

        public void AddStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);

        public void SaveChanges();
    }
}
