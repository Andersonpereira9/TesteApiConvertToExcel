using Microsoft.AspNetCore.Mvc;

namespace TesteCapgemini.Api.Controllers.Base
{
    public sealed class JsonContentResult : ContentResult
    {        
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
