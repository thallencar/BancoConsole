namespace ProjetoBancoConsole
{
    public class ContaPoupanca : Conta
    {
        private decimal _taxaDeRendimento;

        public decimal TaxaDeRendimento { get { return _taxaDeRendimento; } set { _taxaDeRendimento = value; } }

        public ContaPoupanca(TipoConta tipoConta) :base(tipoConta)
        {
            TaxaDeRendimento = 80.00m;
        }

        public ContaPoupanca()
        {
            
        }


        public decimal AcrescentarRendimento(decimal quantia)
        {
            Saldo += TaxaDeRendimento;
            Console.WriteLine($"Taxa acrescida com sucesso. Saldo atual: {Saldo}.");
            

            return Saldo;
        }


        public override void Transferir(decimal quantia)
        {
            Saldo += AcrescentarRendimento(quantia);
            base.Transferir(quantia);

        }

        public override void Depositar(decimal quantia)
        {
            base.Depositar(quantia);
        }
    }
}