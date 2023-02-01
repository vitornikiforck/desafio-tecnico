using MediatR;
using Questao5.Application.Mapper;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Exceptions;
using Questao5.Domain.Repositories.Query;

namespace Questao5.Application.Handlers.QueryHandlers
{
    public class GetBalanceByIdHandler : IRequestHandler<GetBankAccountBalanceByIdQuery, BankAccountGetBalanceResponse>
    {
        private readonly IBankAccountQueryRepository _bankAccountQueryRepository;

        public GetBalanceByIdHandler(IMediator mediator, IBankAccountQueryRepository bankAccountQueryRepository)
        {
            _bankAccountQueryRepository = bankAccountQueryRepository;
        }

        public async Task<BankAccountGetBalanceResponse> Handle(GetBankAccountBalanceByIdQuery request, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountQueryRepository.GetBalanceByIdAsync(request.Id);
            if (bankAccount == null)
                throw new InvalidAccountException();

            if (!bankAccount.Active)
                throw new InactiveAccountException();

            var bankAccountResponse = ApplicationMappers.Mapper.Map<BankAccountGetBalanceResponse>(bankAccount);
            
            return bankAccountResponse;
        }
    }
}
