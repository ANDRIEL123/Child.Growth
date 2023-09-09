using System.Text.Json;
using Child.Growth.src.Infra.Responses;

namespace Child.Growth.src.Infra.Exceptions
{
    public class BusinessException : Exception
    {
        private object Content { get; set; }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, object content) : base(message)
        {
            Content = content;
        }

        public override string ToString()
        {
            var responseBody = new ResponseBody
            {
                Code = 200,
                Message = Message,
                Content = Content
            };

            return JsonSerializer.Serialize(responseBody);
        }
    }
}