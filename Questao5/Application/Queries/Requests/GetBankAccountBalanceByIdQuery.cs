using FluentValidation;
using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class GetBankAccountBalanceByIdQuery : IRequest<BankAccountGetBalanceResponse>
    {
        /// <summary>
        /// Id da Conta Corrente
        /// </summary>
        public string Id { get; private set; }

        public GetBankAccountBalanceByIdQuery(string Id)
        {
            this.Id = Id;
        }
    }

    public class GetBankAccountBalanceByIdQueryValidator : AbstractValidator<GetBankAccountBalanceByIdQuery>
    {
        public GetBankAccountBalanceByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Identificador da conta corrente deve ser informado.")
                .Length(1, 37)
                .WithMessage("Identificador da conta corrente não deve ultrapassar 37 caracteres.");
        }
    }
}
