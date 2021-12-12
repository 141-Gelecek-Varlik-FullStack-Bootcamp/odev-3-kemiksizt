using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Model.Product
{

    // Product tablosu üzerinde işlem yapmak için oluşurulan model
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int IUser { get; set; }

    }
}
