namespace Questao1
{
    public class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial;
        }

        internal void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        internal void Saque(double quantia)
        {
            Saldo -= quantia + Constantes.TaxaSaque;
        }

        public override string ToString()
        {
            return $"Conta {this.Numero}, Títular: {this.Titular}, Saldo: $ {this.Saldo.ToString("F")}";
        }
    }
}
