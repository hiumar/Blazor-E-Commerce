using Microsoft.EntityFrameworkCore;
using YumStore.Data;
using YumStore.Repository.IRepository;

namespace YumStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;   
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> Create(Category category)
        {
            
             _db.Categories.Add(category);
           await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id) { 
            var obj =  await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges(true) > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var obj =  await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null) {
                return new Category();
            }
            return obj;

        }

        public async Task<Category> Update(Category category)
        {
            var objCategory=await _db.Categories.FirstOrDefaultAsync(u=>u.Id == category.Id);
            if (objCategory is not null) { 
                objCategory.Name = category.Name;
                _db.Categories.Update(objCategory);
                _db.SaveChanges();
                return objCategory;
            }
            return category;
        }

        
    }
}
