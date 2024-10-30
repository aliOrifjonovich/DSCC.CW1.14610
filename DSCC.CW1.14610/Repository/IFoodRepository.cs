using DSCC.CW1._14610.Model;

namespace DSCC.CW1._14610.Repository
{
    public interface IFoodRepository
    {
        void InsertFood(Food Food);
        void UpdateFood(Food Food);
        void DeleteFood(int FoodId);
        Food GetFoodById(int Id);
        IEnumerable<Food> GetFoods();
    }
}
