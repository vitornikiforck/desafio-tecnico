using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Command.Base;

namespace Questao5.Domain.Repositories.Command
{
    public interface IFinancialMovementCommandRepository : ICommandRepository<FinancialMovement>
    {
    }
}
