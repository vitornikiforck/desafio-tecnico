namespace Questao5.Domain.Entities
{
    public class BankAccount
    {
        public string? Id { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<FinancialMovement>? FinancialMovements { get; set; }

        public decimal GetBalance()
        {
            var creditBalance = FinancialMovements != null ? FinancialMovements.Where(x => x.MovementType == "C").Sum(x => x.Value) : 0;
            var debitBalance = FinancialMovements != null ? FinancialMovements.Where(x => x.MovementType == "D").Sum(x => x.Value) : 0;

            return creditBalance - debitBalance;
        }
    }
}
