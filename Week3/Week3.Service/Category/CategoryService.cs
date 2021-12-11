﻿using AutoMapper;
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
                }
                else
                {
                    categories.ExceptionMessage = "Sistemde hiçbir kategori yok";
                }
            }

            return categories;
        }

        public General<CategoryViewModel> InsertCategory(CategoryViewModel category)
        {
            var data = new General<CategoryViewModel>();
            var InsCategory = mapper.Map<Week3.DB.Entities.Category>(category);

            using (var context = new GrootContext())
            {
                InsCategory.Idate = DateTime.Now;
                InsCategory.IsActive = true;
                context.Category.Add(InsCategory);
                context.SaveChanges();

                data.Entity = mapper.Map<CategoryViewModel>(InsCategory);
                data.IsSuccess = true;
            }

            return data;
        }


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
                }
                else
                {
                    data.ExceptionMessage = "Aranan kategori bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return data;
        }


    }
}
