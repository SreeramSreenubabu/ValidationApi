//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System.IO;
//using System.Threading.Tasks;

//public class DuplicateKeyValidationMiddleware
//{
//    private readonly RequestDelegate _next;

//    public DuplicateKeyValidationMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        if (context.Request.ContentType == "application/json")
//        {
//            context.Request.EnableBuffering(); // Allow reading the request body multiple times
//            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
//            context.Request.Body.Position = 0; // Reset the position of the stream

//            try
//            {
//                using (var stringReader = new StringReader(requestBody))
//                using (var jsonReader = new JsonTextReader(stringReader))
//                {
//                    var jsonLoadSettings = new JsonLoadSettings
//                    {
//                        DuplicatePropertyNameHandling = DuplicatePropertyNameHandling.Error // Validate duplicate keys
//                    };

//                    JObject.Load(jsonReader, jsonLoadSettings); // Parse JSON with duplicate key validation
//                }
//            }
//            catch (JsonReaderException ex)
//            {
//                context.Response.StatusCode = StatusCodes.Status400BadRequest;
//                await context.Response.WriteAsync($"Invalid JSON: {ex.Message}");
//                return;
//            }
//        }

//        await _next(context);
//    }
//}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

public class DuplicateKeyValidationMiddleware
{
    private readonly RequestDelegate _next;

    public DuplicateKeyValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentType == "application/json")
        {
            context.Request.EnableBuffering(); // Allow reading the request body multiple times
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0; // Reset the position of the stream

            using (var stringReader = new StringReader(requestBody))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                var jsonLoadSettings = new JsonLoadSettings
                {
                    DuplicatePropertyNameHandling = DuplicatePropertyNameHandling.Error // Validate duplicate keys
                };

                JObject.Load(jsonReader, jsonLoadSettings); // Let this throw if there are duplicate keys
            }
        }

        await _next(context);
    }
}
