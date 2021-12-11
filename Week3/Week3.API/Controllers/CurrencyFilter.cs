
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using Week3.Extension;

namespace Week3.API.Controllers
{
    public class CurrencyFilter : Attribute, IActionFilter
    {

        string currencyType = Extension.Extension.GetCurrencies(Extension.Enum.CurrencyTypeDollar);

        // Kontrol sonrasında eğer para birimi Dolar ise bu kısma ulaşacak ve SucceessPage sayfasına yönlendirilecek
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "SuccessPage" }));
        }

        // Gelen para birimi eğer dolar değil ise Executing kısmından kendi oluşturduğumuz "Error" sayfasına yönlendirilir
        // Yani Executed içine girmeden yönlendirme tamamlanır. Error sayfasınının kodlarına Views/Shared/Error.cshtml kısmından ulaşabilirsiniz. 
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(currencyType != "Dollar")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Error" }));
            }

            
        }
    }
}
