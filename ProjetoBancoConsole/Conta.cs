namespace ProjetoBancoConsole
{
    public enum TipoConta
    {
        Corrente = 0,
        Poupanca = 1
    }

    public abstract class Conta
    {
        private static int _proximoIdConta = 1;
        private int _contaId;
        private string _numero;
        private decimal _saldo;
        private TipoConta _tipoConta;

        public int ContaId { get { return _contaId; } set { _contaId = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public decimal Saldo { get { return _saldo; } set { _saldo = value; } }
        public TipoConta TipoConta { get { return _tipoConta; } set { _tipoConta = value; } }

        public Conta(TipoConta tipoConta)
        {
            ContaId = _proximoIdConta++;
            Numero = GerarNumeroDaConta();
            TipoConta = tipoConta;
            Saldo = 0;

        }

        public Conta()
        {
            
        }
        public virtual void Transferir(decimal quantia)
        {
            while (true)
            {
                if (quantia > Saldo)
                {
                    Console.WriteLine("Saldo indisponível para a quantia desejada, tente novamente.");
                }
                else if (quantia <= Saldo)
                {
                    Saldo -= quantia;
                    Console.WriteLine($"Transferência concluída com sucesso. Saldo atual da conta: {Saldo}");
                }
                else
                {
                    Console.WriteLine("Digite um valor válido!");
                }
                
                break;
            }
        }

        public virtual void Depositar(decimal quantia)
        {
            while (true)
            {
            if (quantia < 0.01m)
            {
                    Console.WriteLine("Valor mínimo de depósito deve ser de no mínimo R$0,01 tente novamente.");
            }
            else if (quantia <= Saldo)
            {
                    Saldo += quantia;
                    Console.WriteLine($"Transferência concluída com sucesso. Saldo atual da conta: {Saldo}");
            }  
                break;
            }
        }

        public string GerarNumeroDaConta()
        {
            var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //Iniciando um array de 11 caracteres
            var charsNumConta = new char[11];
            Random random = new Random();

            List<string> numerosGerados = new List<string>();

            for (int i = 0; i < charsNumConta.Length; i++)
            {
                //Seleciona um char aleatório de caracteres e o atribui ao índice do array tamanho, utilizando um índice aleatório gerado pelo Random.
                charsNumConta[i] = caracteres[random.Next(caracteres.Length)];
            }
            //Criando uma string a partir do array de caracteres
            string numeroConta = new String(charsNumConta);

            if (numerosGerados.Contains(numeroConta))
            {
                return GerarNumeroDaConta();
            }
            else
            {
                numerosGerados.Add(numeroConta);
                return numeroConta;
            }

        }
    }

}
