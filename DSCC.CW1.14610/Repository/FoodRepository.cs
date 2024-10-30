using DSCC.CW1._14610.DBContexts;
using DSCC.CW1._14610.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14610.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _dbContext;
        public FoodRepository(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteFood(int FoodId)
        {
            var Food = _dbContext.Foods.Find(FoodId);
            _dbContext.Foods.Remove(Food);
            Save();
        }
        public Food GetFoodById(int FoodId)
        {
            var prod = _dbContext.Foods.Find(FoodId);
            _dbContext.Entry(prod).Reference(s => s.Category).Load();
            return prod;
        }
        public IEnumerable<Food> GetFoods()
        {
            return _dbContext.Foods.Include(s => s.Category).ToList();
        }
        public void InsertFood(Food Food)
        {
            _dbContext.Add(Food);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateFood(Food Food)
        {
            _dbContext.Entry(Food).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
