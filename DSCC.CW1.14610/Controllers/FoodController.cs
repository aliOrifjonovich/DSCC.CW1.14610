using DSCC.CW1._14610.Model;
using DSCC.CW1._14610.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC.CW1._14610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _FoodRepository;
        public FoodController(IFoodRepository FoodRepository)
        {
            _FoodRepository = FoodRepository;
        }


        // GET: api/Food
        [HttpGet]
        public IActionResult Get()
        {
            var Foods = _FoodRepository.GetFoods();
            return new OkObjectResult(Foods);
            //return new string[] { "value1", "value2" };
        }


        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Food = _FoodRepository.GetFoodById(id);
            if (Food != null)
            {
                return new OkObjectResult(Food);
            }
            return new NoContentResult();
            //return "value";
        }

        // POST: api/Food
        [HttpPost]
        public IActionResult Post([FromBody] Food Food)
        {
            using (var scope = new TransactionScope())
            {
                _FoodRepository.InsertFood(Food);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Food.Id }, Food);
            }
        }
        // PUT: api/Food/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Food Food)
        {
            if (Food != null)
            {
                using (var scope = new TransactionScope())
                {
                    _FoodRepository.UpdateFood(Food);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FoodRepository.DeleteFood(id);
            return new OkResult();
        }

    }
}
