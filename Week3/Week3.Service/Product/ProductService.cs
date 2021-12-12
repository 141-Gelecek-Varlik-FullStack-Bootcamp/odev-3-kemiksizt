using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.DB.Entities.DataContext;
using Week3.Model;
using Week3.Model.Product;

namespace Week3.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;

        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        // Sistemdeki belirtilen id grubuna ait bütün ürünleri getiren Request(GetById)
        public General<ProductViewModel> GetProductListById(int id, ProductViewModel product)
        {
            var result = new General<ProductViewModel>();

            using (var context = new GrootContext())
            {
                var data = context.User
                    .Where(x => x.IsActive && !x.IsDeleted && x.Iuser == id)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<ProductViewModel>>(data);
                    result.IsSuccess = true;
                    result.Message = "İşlem başarılı!";
                }
                else
                {
                    result.ExceptionMessage = "Sistemde hiçbir ürün yok";
                }
            }

            return result;
        }
        // Sistemdeki ürüne ait tüm özellikleri silen Request. Deneme amaçlı yapılmıştır!!
        /*
        public General<ProductViewModel> DeleteProduct(int id)
        {
           var result = new General<ProductViewModel>();

           using (var context = new GrootContext())
           {
               var product = context.Product.SingleOrDefault(i => i.Id == id);

               if (product is not null)
               {
                   context.Product.Remove(product);
                   context.SaveChanges();

                   result.Entity = mapper.Map<ProductViewModel>(product);
                   result.IsSuccess = true;
               }
               else
               {
                   result.ExceptionMessage = "Ürün bulunamadı. Bilgileri kontrol ediniz";
                   result.IsSuccess = false;
               }
           }

           return result;
        }
        */

        // Sistemdeki bütün ürünleri getiren Request(Get)
        public General<ProductViewModel> GetProducts()
        {
            var products = new General<ProductViewModel>();

            using (var context = new GrootContext())
            {
                var data = context.Product
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    products.List = mapper.Map<List<ProductViewModel>>(data);
                    products.IsSuccess = true;
                }
                else
                {
                    products.ExceptionMessage = "Sistemde hiçbir ürün yok";
                }
            }

            return products;
        }

        // Sisteme yeni ürün eklemek için kullanılan Request(Insert) 
        public General<ProductViewModel> InsertProduct(ProductViewModel product)
        {
            var data = new General<ProductViewModel>();
            var InsProduct = mapper.Map<Week3.DB.Entities.Product>(product);

            using (var context = new GrootContext())
            {
                InsProduct.Idate = DateTime.Now;
                InsProduct.IsActive = true;
                context.Product.Add(InsProduct);
                context.SaveChanges();

                data.Entity = mapper.Map<ProductViewModel>(InsProduct);
                data.IsSuccess = true;
            }

            return data;
        }


        // Var olan ürünün özelliklerini değiştirmek için kullanılan Request.(Update)
        public General<ProductViewModel> UpdateProduct(int id, ProductViewModel product)
        {
            var data = new General<ProductViewModel>();

            using (var context = new GrootContext())
            {
                var updatedProduct = context.Product.SingleOrDefault(i => i.Id == id);

                if (updatedProduct is not null)
                {
                    updatedProduct.Name = product.Name;
                    updatedProduct.DisplayName = product.DisplayName;
                    updatedProduct.Description = product.Description;
                    updatedProduct.Price = product.Price;
                    updatedProduct.Stock = product.Stock;

                    context.SaveChanges();

                    data.Entity = mapper.Map<ProductViewModel>(updatedProduct);
                    data.IsSuccess = true;
                    data.Message = "İşlem başarılı!!";
                }
                else
                {
                    data.ExceptionMessage = "Aranan ürün bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return data;
        }

        // Silme işlemi. Verilen tamamen silinmiyor yalnızca IsActive ve IsDelete kısımları değişiyor.
        public General<ProductViewModel> DeleteProduct(int id, ProductViewModel product)
        {
            var result = new General<ProductViewModel>();

            using (var context = new GrootContext())
            {
                var productActivity = context.Product.SingleOrDefault(i => i.Id == id);

                if (productActivity is not null)
                {
                    productActivity.IsActive = false;
                    productActivity.IsDeleted = true;

                    context.SaveChanges();

                    result.Entity = mapper.Map<ProductViewModel>(productActivity);
                    result.IsSuccess = true;
                    result.Message = "Silme işlemi başarılı!";
                }
                else
                {
                    result.ExceptionMessage = "Aranan ürün bulunamadı. Bilgileri kontrol ediniz.";
                }
            }

            return result;
        }


    }
}
