using Microsoft.AspNetCore.Mvc;

namespace TesteTemplate.Api.Controllers.Base
{
    public sealed class JsonContentResult : ContentResult
    {        
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
