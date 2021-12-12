using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Category tablosu üzerinde işlem yapmak için oluşurulan model
namespace Week3.Model.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int IUser { get; set; }

    }
}
