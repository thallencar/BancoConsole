namespace ProjetoBancoConsole
{
    public class ContaPoupanca : Conta
    {
        private decimal _taxaDeRendimento;

        public decimal TaxaDeRendimento { get { return _taxaDeRendimento; } set { _taxaDeRendimento = value; } }

        public ContaPoupanca(TipoConta tipoConta) : base(tipoConta)
        {
            TaxaDeRendimento = 0.08m;
        }

        public ContaPoupanca()
        {

        }


        public decimal AcrescentarRendimento(decimal quantia)
        {
            Saldo += Saldo * TaxaDeRendimento;
            Console.WriteLine($"Taxa acrescida com sucesso. Saldo atual: {Saldo}.");


            return Saldo;
        }


        public override void Transferir(decimal quantia)
        {
            base.Transferir(quantia);
            Saldo += quantia;
            AcrescentarRendimento(quantia);

        }

        public override void Depositar(decimal quantia)
        {
            base.Depositar(quantia);
        }
    }
}