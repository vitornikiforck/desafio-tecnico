namespace Questao5.Application.Queries.Responses
{
    public class BankAccountGetBalanceResponse
    {
        public BankAccountGetBalanceResponse()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// Número da conta corrente
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Titular da conta corrente
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Data da movimentação financeira
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Saldo da conta corrente
        /// </summary>
        public decimal Balance { get; set; }
    }
}
