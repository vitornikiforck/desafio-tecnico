using Questao5.Exceptions;

namespace Questao5.Domain.Exceptions
{
    public class InactiveAccountException : BusinessException
    {
        public InactiveAccountException() : base(Domain.Enumerators.StatusCodes.NotFound, "A conta está inativa.", "INACTIVE_ACCOUNT")
        {

        }
    }
}
