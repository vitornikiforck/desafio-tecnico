using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Query;
using Questao5.Infrastructure.Database.QueryStore.Base;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class IdempotenceQueryRepository : QueryRepository<Idempotence>, IIdempotenceQueryRepository
    {
        protected readonly BankAccountContext _context;

        public IdempotenceQueryRepository(BankAccountContext context)
        {
            _context = context;
        }

        public async Task<Idempotence> Get(string id)
        {
            return await _context.Idempotences.FindAsync(id);
        }
    }
}
