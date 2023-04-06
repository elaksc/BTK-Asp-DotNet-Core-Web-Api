using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) //Metot çalışmadan hemen önceye odaklanmak için geçersiz kılmak
        {
            //Controller, action ve Dto bilgisini elde etmek için kodlar: 
            var controller = context.RouteData.Values["controller"];  //Hangi controllerda olduğunu anlamak için 
                                                                      //Values bir dictionary ifadesidir. Eğer bir şey Dictionary ise keyler yardımı ile değerlere ulaşabiliriz.
            var action = context.RouteData.Values["action"];          // Hangi metodun çalıştını öğrenmek için action.

            var param = context.ActionArguments
                                .SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value; // Dto var ise değerini alıyoruz 

            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null " + $"Controller : {controller}" + $"Action : {action}");
                return; //400
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState); // 422 Doğrulama gerçekleşmedi
        }
    }
}
