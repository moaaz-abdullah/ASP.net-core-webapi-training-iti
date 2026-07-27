using System.Runtime.Intrinsics.Arm;
using WebApplicationDay1.Models;
using WebApplicationDay1.Repository;

namespace WebApplicationDay1.UnitOfWork
{
    public class UOW
    {
        private readonly ITIContext db;

        public GenericRepository<Student> studentRepos;
        public GenericRepository<Department> departmentRepos;

        public UOW(ITIContext db)
        {
            this.db = db;
            studentRepos = new GenericRepository<Student>(db);
            departmentRepos = new GenericRepository<Department>(db);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}
