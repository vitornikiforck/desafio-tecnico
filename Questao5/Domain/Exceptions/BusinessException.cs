namespace Questao5.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(Domain.Enumerators.StatusCodes statusCode, string message, string exceptionType) : base(message)
        {
            StatusCodes = statusCode;
            ExceptionType = exceptionType;
        }

        public Domain.Enumerators.StatusCodes StatusCodes { get; }
        public string ExceptionType { get; }
    }
}
