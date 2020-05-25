using System.Collections.Generic;
using System.Linq;
using System.Net;
using TesteCapgemini.Domain.Arguments.Base;

namespace TesteCapgemini.Api.Controllers.Base
{
    public class Presenter :
        IOutputPort<ResponseMessage>,
        IOutputPort<IEnumerable<ResponseMessage>>
    {
        /// <summary/>
        public JsonContentResult ContentResult { get; }

        /// <summary/>
        public Presenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary/>
        public void Handler(ResponseMessage response)
        {
            var isValid = response
                .IsValid();

            ContentResult.StatusCode = RetornarStatusCode(isValid);

            if (isValid)
            {
                var isInformation = response.Information != null;
                ContentResult.Content = isInformation ?
                    SerializarInformation(response.Information) :
                    Serializar(response);
            }
            else
                ContentResult.Content = SerializarErrors(response.Errors);
        }

        /// <summary/>
        public void Handler(IEnumerable<ResponseMessage> response)
        {
            var isValid = !response
                .Any(a => !a.IsValid());

            ContentResult.StatusCode = RetornarStatusCode(isValid);

            if (isValid)
            {
                var isInformation = response.Any(a => a.Information != null);
                ContentResult.Content = isInformation ?
                    SerializarInformation(response.Select(s => s.Information)) :
                    Serializar(response);
            }
            else
                ContentResult.Content = SerializarErrors(response.Select(s => s.Errors));
        }

       
        private string SerializarInformation(object context)
        {
            return Serializar(new
            {
                Information = context
            });
        }

        private string SerializarErrors(object context)
        {
            return Serializar(new
            {
                Errors = context
            });
        }

        private string Serializar(object context)
        {
            return JsonSerializer.SerializeObject(context);
        }

        private int RetornarStatusCode(bool isValid)
        {
            return (int)(isValid ?
                HttpStatusCode.OK :
                HttpStatusCode.BadRequest);
        }
    }
}