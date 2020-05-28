using System.Collections.Generic;
using System.Linq;

namespace TesteTemplate.Domain.Arguments.Base
{
    public abstract class ResponseMessage
    {
        public IEnumerable<string> Errors { get; }

        public IEnumerable<string> Information { get; }

        protected ResponseMessage(IEnumerable<string> messages, bool error = true)
        {
            if (error)
                Errors = messages;
            else
                Information = messages;

        }

        protected ResponseMessage(string message, bool error = true)
        {
            var msg = new List<string> { message };

            if (error)
                Errors = msg;
            else
                Information = msg;
        }

        protected ResponseMessage() { }

        public bool IsValid()
        {
            return Errors == null || !Errors.Any();
        }
    }
}