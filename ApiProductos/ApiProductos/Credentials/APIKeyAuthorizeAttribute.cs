using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiProductos.Credentials
{
    public class APIKeyAuthorizeAttribute /*: Attribute, IAuthorizationFilter*/
    {
        //private const string APIKEYNAME = "ApiKey";
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        //    var apiKey = configuration["APIKey"]; 


        //    if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey)
        //        || apiKey != extractedApiKey)
        //    {
        //        context.Result = new ContentResult()
        //        {
        //            StatusCode = 401,
        //            Content = "Unauthorized",
        //            ContentType = "text/plain",
        //        };
        //    }
        //}
    }
}
