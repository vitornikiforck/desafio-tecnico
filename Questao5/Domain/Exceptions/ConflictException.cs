using Questao5.Exceptions;

namespace Questao5.Domain.Exceptions
{
    public class ConflictException : BusinessException
    {
        public ConflictException() : base(Domain.Enumerators.StatusCodes.AlreadyExists, "Requisição já processada.", "REQUEST_IN_PROCESS")
        {
        }
    }
}
