using DSCC.CW1._14610.DBContexts;
using DSCC.CW1._14610.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14610.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodContext _dbContext;

        public CategoryRepository(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(int CategoryId)
        {
            var category = _dbContext.Categories.Find(CategoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                Save();
            }
        }

        public Category GetCategoryById(int CategoryId)
        {
            return _dbContext.Categories.Find(CategoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public void InsertCategory(Category Category)
        {
            _dbContext.Add(Category);
            Save();
        }

        public void UpdateCategory(Category Category)
        {
            _dbContext.Entry(Category).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
