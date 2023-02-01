namespace Questao5.Domain.Entities
{
    public class FinancialMovement
    {
        public FinancialMovement()
        {
        }

        public string? Id { get; set; }
        public string? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public DateTime Date { get; set; }
        public virtual string? MovementType { get; set; }
        public virtual decimal Value { get; set; }
    }
}
