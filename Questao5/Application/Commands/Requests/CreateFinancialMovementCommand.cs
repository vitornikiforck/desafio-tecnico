using FluentValidation;
using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CreateFinancialMovementCommand : IRequest<CreateFinancialMovementResponse>
    {
        /// <summary>
        /// Identificador da requisição
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Identificador da conta corrente
        /// </summary>
        public string BankAccountId { get; set; }
        /// <summary>
        /// Tipo da movimentação financeira 'C' crédito, 'D' débito
        /// </summary>
        public string MovementType { get; set; }
        /// <summary>
        /// Valor da movimentação financeira
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Data da movimentação financeira
        /// </summary>
        public DateTime Date { get; private set; }

        public CreateFinancialMovementCommand()
        {
            RequestId = "";
            BankAccountId = "";
            MovementType = "";
            Date = DateTime.Now;
        }
    }

    public class CreateFinancialMovementCommandValidator : AbstractValidator<CreateFinancialMovementCommand>
    {
        public CreateFinancialMovementCommandValidator()
        {
            RuleFor(x => x.RequestId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Identificador da requisição deve ser informado.")
                .Length(1, 37)
                .WithMessage("Identificador da requisição não deve ultrapassar 37 caracteres.");

            RuleFor(x => x.BankAccountId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Identificador da conta corrente deve ser informado.")
                .Length(1, 37)
                .WithMessage("Identificador da conta corrente não deve ultrapassar 37 caracteres.");

            RuleFor(x => x.MovementType)
                .Must(ValidMovementType)
                .WithMessage("Tipo da movimentação deve ser 'C' para crédito e 'D' para débito.");

            RuleFor(x => x.Value)
                .Must(ValidValue)
                .WithMessage("Valor informado não deve ser negativo.");
        }

        private bool ValidMovementType(string movementType) => movementType == "C" || movementType == "D";
        private bool ValidValue(decimal value) => value >= 0;
    }
}
