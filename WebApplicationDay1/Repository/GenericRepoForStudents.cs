using Microsoft.EntityFrameworkCore;
using WebApplicationDay1.Models;

namespace WebApplicationDay1.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly ITIContext db;

        public GenericRepository(ITIContext db)
        {
            this.db = db;
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity? GetById(object id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public TEntity? GetByName(string name)
        {
            return db.Set<TEntity>().FirstOrDefault(e => EF.Property<string>(e, "Name") == name);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entity = db.Set<TEntity>().Find(id);

            if (entity != null)
            {
                db.Set<TEntity>().Remove(entity);
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
