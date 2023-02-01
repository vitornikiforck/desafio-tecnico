using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Mapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Exceptions;
using Questao5.Domain.Repositories.Command;
using Questao5.Domain.Repositories.Query;
using System.Text.Json;

namespace Questao5.Application.Handlers.CommandHandlers
{
    public class CreateFinancialMovementHandler : IRequestHandler<CreateFinancialMovementCommand, CreateFinancialMovementResponse>
    {
        private readonly IBankAccountQueryRepository _bankAccountQueryRepository;
        private readonly IFinancialMovementCommandRepository _financialMovementCommandRepository;
        private readonly IIdempotenceQueryRepository _idempotenceQueryRepository;
        private readonly IIdempotenceCommandRepository _idempotenceCommandRepository;

        public CreateFinancialMovementHandler(IBankAccountQueryRepository bankAccountQueryRepository,
            IFinancialMovementCommandRepository financialMovementCommandRepository,
            IIdempotenceQueryRepository idempotenceQueryRepository,
            IIdempotenceCommandRepository idempotenceCommandRepository)
        {
            _bankAccountQueryRepository = bankAccountQueryRepository;
            _financialMovementCommandRepository = financialMovementCommandRepository;
            _idempotenceQueryRepository = idempotenceQueryRepository;
            _idempotenceCommandRepository = idempotenceCommandRepository;
        }

        public async Task<CreateFinancialMovementResponse> Handle(CreateFinancialMovementCommand request, CancellationToken cancellationToken)
        {
            var requestId = request.RequestId.ToUpper();
            var idempotence = await _idempotenceQueryRepository.Get(requestId);
            if (idempotence != null)
                throw new ConflictException();

            var bankAccount = await _bankAccountQueryRepository.GetBalanceByIdAsync(request.BankAccountId);
            if (bankAccount == null)
                throw new InvalidAccountException();

            if (!bankAccount.Active)
                throw new InactiveAccountException();

            var financialMovement = ApplicationMappers.Mapper.Map<FinancialMovement>(request);
            if (financialMovement is null)
                throw new ApplicationException("Erro ao mapear requisição.");

            var newFinancialMovement = await _financialMovementCommandRepository.AddAsync(financialMovement);
            var financialMovementResponse = ApplicationMappers.Mapper.Map<CreateFinancialMovementResponse>(newFinancialMovement);

            if (financialMovementResponse is null)
                throw new ApplicationException("Erro ao mapear resposta.");

            if (string.IsNullOrEmpty(financialMovementResponse.Id))
                throw new ApplicationException("Falha ao finalizar movimentação financeira.");

            string jsonRequest = JsonSerializer.Serialize(request);
            string jsonResult = JsonSerializer.Serialize(financialMovementResponse);
            await _idempotenceCommandRepository.AddAsync(new Idempotence(requestId, jsonRequest, jsonResult));

            return financialMovementResponse;
        }
    }
}
