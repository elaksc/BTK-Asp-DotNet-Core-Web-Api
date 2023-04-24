using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class ValidateMediaTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var acceptHeaderPresent = context.HttpContext
                .Request
                .Headers
                .ContainsKey("Accept"); // Accept var mı kontrol

            if (!acceptHeaderPresent) 
            {
                context.Result = new BadRequestObjectResult($"Accept Header is missing");
                //Eğer istemci tarafından Accept Header değeri belirtilmemişse, bu durumda API, "Accept Header is missing" (Kabul Başlığı eksik) mesajıyla birlikte HTTP 400 Bad Request (Kötü İstek) yanıtı döndürür.
                return;
            }  // yoksa badrequest


            var mediaType = context.HttpContext
                .Response
                .Headers["Accept"]
                .FirstOrDefault(); // Accept var. 


            if (MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? outMediaType))  //desteklediğimiz bir type mı
            {
                context.Result = new BadRequestObjectResult($"Media Type not present. " + $"Please add Accept header with required media type");
                return;
            }
            ///TryParse() metodu, mediaType parametresindeki string değerini, geçerli bir medya türü değeri olarak dönüştürmeye çalışır. 
            ///Eğer dönüştürme işlemi başarılı olursa, dönüştürülmüş medya türü değeri outMediaType parametresine atanır ve if bloğu içindeki kod çalıştırılır.
            ///Eğer dönüştürme işlemi başarısız olursa, outMediaType parametresi null değeri alır ve if bloğu içindeki kodlar çalıştırılmaz.


            context.HttpContext.Items.Add("AcceptHeaderMediaType", outMediaType);  // Desteklediğimiz de değilse bu kod blogu üretilir. "+



        }
    }
}
