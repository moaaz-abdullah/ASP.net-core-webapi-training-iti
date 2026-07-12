using WebApplicationDay1.Models;

namespace WebApplicationDay1.Repository
{
    public class StudentsRepository : IStudentRepository
    {
        private readonly ITIContext db;

        public StudentsRepository(ITIContext db)
        {
            this.db = db;
        }

        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }

        public Student GetStudentByName(string name)
        {
            return db.Students.FirstOrDefault(s => s.St_Fname == name);
        }

        public void AddStudent(Student student)
        {
            db.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            db.Students.Update(student);
        }
        
        public void DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
