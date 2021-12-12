using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Extension
{
    // Enum
    public enum Enum
    {

        [Display(Name = "Dollar")]
        CurrencyTypeDollar = 1,
        [Display(Name = "Euro")]
        CurrencyTypeEuro = 2,
    }
}
