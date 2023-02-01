using Questao5.Exceptions;

namespace Questao5.Domain.Exceptions
{
    public class InvalidAccountException : BusinessException
    {
        public InvalidAccountException() : base(Domain.Enumerators.StatusCodes.NotFound, "Conta corrente não encontrada.", "INVALID_ACCOUNT")
        {

        }
    }
}
