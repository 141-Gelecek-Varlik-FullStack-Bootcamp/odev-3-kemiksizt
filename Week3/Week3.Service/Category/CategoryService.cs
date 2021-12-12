using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.DB.Entities.DataContext;
using Week3.Model;
using Week3.Model.Category;

namespace Week3.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        // İçerisinde bulunan tüm verileri sildiği için aşağıda başka türevi tanınlanmıştır. Deneme amaçlıdır !!
        /*
        public General<CategoryViewModel> DeleteCategory(int id)
        {
            var result = new General<CategoryViewModel>();

            using (var context = new GrootContext())
            {
                var category = context.Category.SingleOrDefault(i => i.Id == id);

                if (category is not null)
                {
                    context.Category.Remove(category);
                    context.SaveChanges();

                    result.Entity = mapper.Map<CategoryViewModel>(category);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Kategori bulunamadı. Bilgileri kontrol ediniz";
                    result.IsSuccess = false;
                }
            }

            return result;
        }
        */

        // Bütün kategorileri listeler(Get)
        public General<CategoryViewModel> GetCategories()
        {
            var categories = new General<CategoryViewModel>();

            using (var context = new GrootContext())
            {
                var data = context.Category
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    categories.List = mapper.Map<List<CategoryViewModel>>(data);
                    categories.IsSuccess = true;
                    categories.Message = "İşlem başarılı !";
                }
                else
                {
                    categories.ExceptionMessage = "Sistemde hiçbir kategori yok";
                }
            }

            return categories;
        }

        // Kategorilere yeni ekleme işlemleri yapılan kısım.(Insert)

        public General<CategoryViewModel> InsertCategory(CategoryViewModel category)
        {
            var result = new General<CategoryViewModel>();
            var InsCategory = mapper.Map<Week3.DB.Entities.Category>(category);

            using (var context = new GrootContext())
            {
                InsCategory.Idate = DateTime.Now;
                InsCategory.IsActive = true;
                context.Category.Add(InsCategory);
                context.SaveChanges();

                result.Entity = mapper.Map<CategoryViewModel>(InsCategory);
                result.IsSuccess = true;
                result.Message = "İşlem başarılı !";
            }

            return result;
        }

        // Belirtilen id ye sahip kategoride güncelleme işlemleri yapılır.(Update)
        public General<CategoryViewModel> UpdateCategory(int id, CategoryViewModel category)
        {
            var data = new General<CategoryViewModel>();

            using (var context = new GrootContext())
            {
                var updatedCategory = context.Category.SingleOrDefault(i => i.Id == id);

                if (updatedCategory is not null)
                {
                    updatedCategory.Name = category.Name;
                    updatedCategory.DisplayName = category.DisplayName;
                    

                    context.SaveChanges();

                    data.Entity = mapper.Map<CategoryViewModel>(updatedCategory);
                    data.IsSuccess = true;
                    data.Message = "Güncelleme işlemi başarılı!";
                }
                else
                {
                    data.ExceptionMessage = "Aranan kategori bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return data;
        }

        // Belirtilen id ye sahip kategorinin aktifliği değiştirilir. İçerisindeki bilgiler aynen kalır(Delete)
        public General<CategoryViewModel> DeleteCategory(int id, CategoryViewModel category)
        {
            var result = new General<CategoryViewModel>();

            using (var context = new GrootContext())
            {
                var categoryActivity = context.Category.SingleOrDefault(i => i.Id == id);

                if (categoryActivity is not null)
                {
                    categoryActivity.IsActive = false;
                    categoryActivity.IsDeleted = true;

                    context.SaveChanges();

                    result.Entity = mapper.Map<CategoryViewModel>(categoryActivity);
                    result.IsSuccess = true;
                    result.Message = "Silme işlemi başarılı!";
                }
                else
                {
                    result.ExceptionMessage = "Aranan kategori bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return result;
        }


    }
}
