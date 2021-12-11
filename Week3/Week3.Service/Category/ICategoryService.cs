using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Model;
using Week3.Model.Category;

namespace Week3.Service.Category
{
    public interface ICategoryService
    {
        public General<CategoryViewModel> GetCategories();
        public General<CategoryViewModel> InsertCategory(CategoryViewModel category);
        public General<CategoryViewModel> UpdateCategory(int id, CategoryViewModel category);
        public General<CategoryViewModel> DeleteCategory(int id);
    }
}
