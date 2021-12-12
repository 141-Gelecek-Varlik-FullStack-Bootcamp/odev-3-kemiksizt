using Microsoft.AspNetCore.Mvc;
using Week3.Model;
using Week3.Model.Category;
using Week3.Service.Category;

namespace Week3.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpPost("Delete")]
        public General<CategoryViewModel> DeleteCategory(int id, [FromBody] CategoryViewModel category)
        {
            return categoryService.DeleteCategory(id, category);
        }

        [HttpPost("Insert")]
        public General<CategoryViewModel> InsertProduct([FromBody] CategoryViewModel newCategory)
        {
            return categoryService.InsertCategory(newCategory);
        }

        [HttpGet]
        public General<CategoryViewModel> GetCategories()
        {
            return categoryService.GetCategories();
        }

        [HttpPut("{id}")]
        public General<CategoryViewModel> UpdateProduct(int id, [FromBody] CategoryViewModel category)
        {
            return categoryService.UpdateCategory(id, category);
        }

        /*
        [HttpDelete("{id}")]
        public General<CategoryViewModel> DeleteProduct(int id)
        {
            return categoryService.DeleteCategory(id);
        }
        */
    }

}

