namespace ProjetoBancoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();

            while (true)
            {
                Console.Write(@"----- $ BANCO CONSOLE $ -----

1. Cadastrar nova Conta
2. Transferir Dinheiro
3. Depositar Dinheiro
4. Consultar Saldo
5. Sair

-> ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Cliente novoCliente = new Cliente();

                        Console.WriteLine(@"CADASTRO DE CONTA
Para realizar o seu cadastro informe abaixo os seus seguintes dados: ");

                        do
                        {
                            Console.Write("CPF: ");
                            novoCliente.Cpf = Console.ReadLine();
                        }
                        while (!novoCliente.ValidarCpf());

                        Console.Write("Nome completo: ");
                        novoCliente.Nome = Console.ReadLine();
                        string sobrenome = novoCliente.Nome.Split(' ').Last();

                        Console.Write("Tipo da conta (0 - CORRENTE / 1 - POUPANÇA): ");
                        int tipo;
                        while (!int.TryParse(Console.ReadLine(), out tipo) || (tipo != 0 && tipo != 1))
                        {
                            Console.WriteLine("Valor inválido, digite novamente.");
                        }

                        if (tipo == 0)
                        {
                            novoCliente.Conta = new ContaCorrente(TipoConta.Corrente);
                        }
                        else if (tipo == 1)
                        {
                            novoCliente.Conta = new ContaPoupanca(TipoConta.Poupanca);
                        }

                        novoCliente.TiparCliente();
                        novoCliente.Conta.GerarNumeroDaConta();

                        clientes.Add(novoCliente);

                        Console.WriteLine($@"Conta cadastrada com sucesso.
Sr.(a) {sobrenome}, o Banco Console agradece a preferência.

Número da conta: {novoCliente.Conta.Numero}");
                        break;

                    case "2":
                        Console.Write("Digite o número da conta de origem: ");
                        string numContaOrigem = Console.ReadLine();

                        Console.Write("Digite o número da conta de destino: ");
                        string numContaDestino = Console.ReadLine();

                        Console.Write("Digite a quantia a ser transferida: ");
                        decimal quantia;
                        while (!decimal.TryParse(Console.ReadLine(), out quantia))
                        {
                            Console.WriteLine("Valor inválido, digite novamente.");
                        }

                        Cliente clienteTransferencia = clientes.FirstOrDefault(c => c.Conta.Numero == numContaOrigem);
                        Cliente clienteDestino = clientes.FirstOrDefault(c => c.Conta.Numero == numContaDestino);

                        if (clienteTransferencia != null && clienteDestino != null)
                        {
                            clienteTransferencia.Conta.Transferir(quantia);
                            clienteDestino.Conta.Depositar(quantia);
                            clienteTransferencia.Tipo = clienteTransferencia.TiparCliente();
                        }
                        else
                        {
                            Console.WriteLine("Conta de origem ou destino não encontrada.");
                        }
                        break;

                    case "3":
                        Console.Write("Digite o número da conta de destino: ");
                        numContaDestino = Console.ReadLine();

                        Cliente clienteDeposito = clientes.FirstOrDefault(c => c.Conta.Numero == numContaDestino);

                        if (clienteDeposito == null)
                        {
                            Console.WriteLine("Conta de destino não encontrada.");
                            break;
                        }

                        Console.Write("Digite a quantia a ser depositada: ");
                        while (!decimal.TryParse(Console.ReadLine(), out quantia))
                        {
                            Console.WriteLine("Valor inválido, digite novamente.");
                        }

                        clienteDeposito.Conta.Depositar(quantia);
                        clienteDeposito.Tipo = clienteDeposito.TiparCliente();
                        break;

                    case "4":
                        Console.Write("Digite o número da conta: ");
                        string numConta = Console.ReadLine();

                        Cliente clienteConsulta = clientes.FirstOrDefault(c => c.Conta.Numero == numConta);

                        if (clienteConsulta != null)
                        {
                            clienteConsulta.ConsultarSaldo();
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Sistema finalizado.");
                        return;

                    default:
                        Console.WriteLine("Erro! Digite uma opção válida.");
                        break;
                }
            }
        }
    }
}
