namespace ProjetoBancoConsole
{
    public class ContaCorrente : Conta
    {
        private decimal _taxaDeManutencao;

        public decimal TaxaDeManutencao { get { return _taxaDeManutencao; } set { _taxaDeManutencao = value; } }

        public ContaCorrente(TipoConta tipoConta) : base(tipoConta)
        {
            TaxaDeManutencao = 80.00m;
        }

        public ContaCorrente()
        {
            
        }

        public decimal DescontarTaxa(decimal quantia)
        {
            Saldo += quantia;
            if (TaxaDeManutencao > Saldo)
            {
                Saldo -= TaxaDeManutencao;
                Console.WriteLine($"Saldo insuficiente para a cobertura da taxa de manutenção. Sua conta foi negativada. Saldo atual: {Saldo}.");
            }
            else
            {
                Saldo -= TaxaDeManutencao;
                Console.WriteLine($"Taxa de R${TaxaDeManutencao} descontada com sucesso.");
            }

            return Saldo;
        }


        public override void Transferir(decimal quantia)
        {
            Saldo -= DescontarTaxa(quantia);
            base.Transferir(quantia);

        }

        public override void Depositar(decimal quantia)
        {
            base.Depositar(quantia);
            
        }
    }
}