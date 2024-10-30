namespace DSCC.CW1._14610.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }
        public bool IsVegetarian { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}