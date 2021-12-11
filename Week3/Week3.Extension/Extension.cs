using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Extension
{
    public static class Extension
    {
        // Enum sınıfında oluşturulan değişkenlerin tipinin alındığı yer(CurrencyTypeDollar)
        public static string GetCurrencies(this Enum currencyType)
        {
            var result = currencyType.GetType().GetMember(currencyType.ToString()).First().GetCustomAttributes<DisplayAttribute>().First().Name;
            return result.ToString();
        }

        // Extension : Türk Lirası --> Dolar 
        public static string toUSD(this double variable)
        {
            return variable / 14.5 + "$";
        }

        // Extension : Türk Lirası --> Euro
        public static string toEuro(this double variable)
        {
            return variable / 16.0 + "€";
        }
    }
}
