using Serilog;

namespace Child.Growth.src.Infra.Exceptions
{
    public class BusinessException : Exception
    {
        string _message;
        public BusinessException(string message) : base(message)
        {
            Log.Error(message);
            _message = message;
        }

        public override string ToString()
        {
            return _message;
        }
    }
}