using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Command;
using Questao5.Infrastructure.Database.CommandStore.Base;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class IdempotenceCommandRepository : CommandRepository<Idempotence>, IIdempotenceCommandRepository
    {
        public IdempotenceCommandRepository(BankAccountContext context) : base(context)
        {
        }
    }
}
