using ASM_Bai2.DBContext;
using ASM_Bai2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASM_Bai2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList(); 
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id); 
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            // Tìm entity theo id trước
            T entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        // Hàm xóa nội bộ (Overload để hỗ trợ hàm Delete(object id) ở trên)
        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges(); // Dùng SaveChanges thường
        }
    }
}