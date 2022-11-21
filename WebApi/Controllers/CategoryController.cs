namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }

        [SwaggerOperation(Summary ="Return all categories")]
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [SwaggerOperation(Summary ="Return category by Id")]
        [HttpGet("{id}")]   
        public IActionResult Get(int id) 
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [SwaggerOperation(Summary = "Create new category")]
        [HttpPost]
        public IActionResult Create(CreateCategoryDto category)
        {
            var newCategory = _categoryService.AddNewCategory(category);
            return Created($"api/categories/{newCategory.Id}", newCategory);
        }

        [SwaggerOperation(Summary ="Update a category")]
        [HttpPut("{id}")]

        public IActionResult Update(int id, UpdateCategoryDto category)
        {
            _categoryService.Update(id, category);
            return NoContent();
        }

        [SwaggerOperation(Summary ="Delate a category")]
        [HttpDelete("{id}")]

        public IActionResult Delate(int id)
        {
            _categoryService.Delete(id);
            return NoContent(); 

        }







    }
}
