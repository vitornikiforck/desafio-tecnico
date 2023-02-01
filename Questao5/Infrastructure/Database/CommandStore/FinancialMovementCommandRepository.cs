using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Command;
using Questao5.Infrastructure.Database.CommandStore.Base;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class FinancialMovementCommandRepository : CommandRepository<FinancialMovement>, IFinancialMovementCommandRepository
    {
        public FinancialMovementCommandRepository(BankAccountContext context) : base(context)
        {

        }
    }
}
