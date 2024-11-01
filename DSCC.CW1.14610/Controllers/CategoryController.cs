using DSCC.CW1._14610.Model;
using DSCC.CW1._14610.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1._14610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _CategoryRepository.GetCategories();
            return new OkObjectResult(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var category = _CategoryRepository.GetCategoryById(id);
            if (category != null)
            {
                return new OkObjectResult(category);
            }
            return new NoContentResult();
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category Category)
        {
            using (var scope = new TransactionScope())
            {
                _CategoryRepository.InsertCategory(Category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Category.Id }, Category);
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (category != null && id == category.Id)
            {
                using (var scope = new TransactionScope())
                {
                    _CategoryRepository.UpdateCategory(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _CategoryRepository.DeleteCategory(id);
            return new OkResult();
        }
    }
}
