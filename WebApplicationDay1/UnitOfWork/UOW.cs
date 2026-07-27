using System.Runtime.Intrinsics.Arm;
using WebApplicationDay1.Models;
using WebApplicationDay1.Repository;

namespace WebApplicationDay1.UnitOfWork
{
    public class UOW
    {
        private readonly ITIContext db;

        GenericRepository<Student> studentRepos;
        GenericRepository<Department> departmentRepos;

        public UOW(ITIContext db)
        {
            this.db = db;
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepos == null)
                    studentRepos = new GenericRepository<Student>(db);

                return studentRepos;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (departmentRepos == null)
                    departmentRepos = new GenericRepository<Department>(db);

                return departmentRepos;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}
