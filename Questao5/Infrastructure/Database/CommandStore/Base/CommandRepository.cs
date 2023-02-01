using Questao5.Domain.Repositories.Command.Base;

namespace Questao5.Infrastructure.Database.CommandStore.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly BankAccountContext _context;

        public CommandRepository(BankAccountContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
