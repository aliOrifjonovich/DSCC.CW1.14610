using DSCC.CW1._14610.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14610.DBContexts
{
    public class FoodContext: DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
